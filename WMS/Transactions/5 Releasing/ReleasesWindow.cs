using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS
{
    public partial class ReleasesWindow : Form
    {

        String now = DateTime.Now.ToString();
        public ReleasesWindow()
        {
            InitializeComponent();
        }

        Dictionary<String, DataTable> dt_list = new Dictionary<String, DataTable>();
        String release_id = "";
        String current_order = "";


        DataTable ordersDT = null;
        DataTable itemsDT = null;

        private String GetCurrentOrder()
        {
            foreach (DataRow row in ordersDT.Rows)
                if (row["status"].ToString() == "RELEASING")
                    return row["Order"].ToString();
            return "FINISHED";
        }

        private void LoadData()
        {
            ordersDT = DataSupport.RunDataSet(@"SELECT RD.ORDER_ID[Order], RD.drop_sequence[Drop], RD.Status, RO.status [Order Status], CASE WHEN RO.holding_transaction IS NULL  THEN 'YES' ELSE 'NO' END [Forced]
                                                FROM ReleaseDetails RD 
                                                LEFT OUTER JOIN ReleaseOrders RO ON RO.order_id = RD.order_id
                                                WHERE RD.release = @release_id 
											    AND RO.status = 'FOR RELEASING'
                                                ORDER BY RD.drop_sequence", "release_id", release_id).Tables[0];
            current_order = GetCurrentOrder();
            if (current_order == "FINISHED")
            {
                var ordersDT = FAQ.GetReleasedOrders(release_id);
                // Update OMS
                {
                    DataSupport oms_dh = new DataSupport(String.Format(@"Initial Catalog={0};Data Source= {1};User Id = {2}; Password = {3}", Utils.DBConnection["OMS"]["DBNAME"], Utils.DBConnection["OMS"]["SERVER"], Utils.DBConnection["OMS"]["USERNAME"], Utils.DBConnection["OMS"]["PASSWORD"]));
                   
                    String sql = "";
                    foreach (DataRow order_row in ordersDT.Rows)
                    {
                        String order_id = order_row["order_id"].ToString();
                        sql += " UPDATE OutgoingShipmentRequests SET status='FOR DELIVERY' WHERE out_shipment_id='"+order_id+"'; ";
                    }
                    oms_dh.ExecuteNonQuery(sql, IsolationLevel.ReadCommitted);
                }

                // Update TMS
                {
                    DataSupport tms_dh = new DataSupport(String.Format("Initial Catalog={0};Data Source= {1};User Id = {2}; Password = {3}", Utils.DBConnection["TMS"]["DBNAME"], Utils.DBConnection["TMS"]["SERVER"], Utils.DBConnection["TMS"]["USERNAME"], Utils.DBConnection["TMS"]["PASSWORD"]));

                    String sql = "";
                    foreach (DataRow order_row in ordersDT.Rows)
                    {
                        String order_id = order_row["order_id"].ToString();
                        sql += " UPDATE TripOrders SET status='FOR DELIVERY' WHERE order_id='" + order_id + "'; ";
                    }
                    sql += String.Format("UPDATE [ReleaseTrips] SET releaseto='{0}' WHERE trip_id='{1}';",txtreleaseto.Text, txtTrip.Text);
                    tms_dh.ExecuteNonQuery(sql, IsolationLevel.ReadCommitted);
                }

                // Update WMS
                {

                    String sql = "";
                    foreach (DataRow order_row in ordersDT.Rows)
                    {
                        String order_id = order_row["order_id"].ToString();
                        sql += " UPDATE ReleaseOrders SET status='RELEASED' WHERE order_id='" + order_id + "'; ";
                    }
                    DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
                }

                PrintReleaseDocument dialog = new PrintReleaseDocument();
                dialog.release_id = release_id;
                dialog.ShowDialog();
                DialogResult = DialogResult.OK;
                return;
            }

            itemsDT = DataSupport.RunDataSet("SELECT order_id[Order], Product, Expiry, lot_no[Lot No], order_qty[Order Qty], Uom, Scanned_qty[Scanned Qty], scanned_on [Scanned On] FROM ReleaseDetailItems WHERE release = @release AND order_id = @order_id", "release", release_id, "order_id", current_order).Tables[0];

            orders_grid.DataSource = ordersDT;
            items_grid.DataSource = itemsDT;
        }


        private void ReleasesWindow_Load(object sender, EventArgs e)
        {
            release_id = FAQ.GetReleaseID(txtTrip.Text);
            LoadData();            
        }

        
        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var product_row = BarcodeSupport.GetProductFromBarcode(txtScan.Text);
                if (product_row == null)
                {
                    MessageBox.Show("Barcode Not Recognized");
                    return;
                }
                String product = product_row["PRODUCT"].ToString();
                String uom = product_row["MATCHED_UOM"].ToString();

                DataTable dt = DataSupport.RunDataSet("SELECT order_id[Order], Product, Expiry, lot_no[Lot No], order_qty[Order Qty], Uom, Scanned_qty[Scanned Qty], scanned_on [Scanned On] FROM ReleaseDetailItems WHERE release = @release AND order_id = @order_id AND product=@product AND @uom = @uom", "release", release_id, "order_id", current_order, "product", product, "uom", uom).Tables[0];

                SelectGridWindow dialog = new SelectGridWindow();
                dialog.dataGridView1.DataSource = dt;
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                var selected_row = dialog.dataGridView1.SelectedRows[0];

                String expiry = selected_row.Cells["Expiry"].Value.ToString();
                String lot_no = selected_row.Cells["Lot No"].Value.ToString();


                String sql = "";

                sql += " UPDATE ReleaseDetailItems SET Scanned_qty = Scanned_qty +1 WHERE release = '"+release_id+"' AND order_id = '"+current_order+"' AND product='"+product+"' AND uom = '"+uom+"' AND expiry = '"+expiry+ "' AND lot_no='" + lot_no + "'  ";


                // Update Transaction Ledger
                {
                    // Out with the location
                    DataTable outsDT = LedgerSupport.GetLocationLedgerDT();

                    outsDT.Rows.Add("STAGING-OUT", now, "OUT", "RELEASE", release_id);

                    sql += LedgerSupport.UpdateLocationLedger(outsDT);

                    // In with both Staging out and for resolution
                   DataTable insDT = LedgerSupport.GetLocationLedgerDT();

                    insDT.Rows.Add("RELEASED", now, "IN", "PICKLIST_DECLARE_COMPLETE", release_id);
                    sql += LedgerSupport.UpdateLocationLedger(insDT);
                }
                // Update Location Products Ledger
                {
                    // Out with the staging out 
                    DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();                  
                    outsDT.Rows.Add("STAGING-OUT", product,  -1, uom, lot_no, expiry);
                    sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);

                    DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();
                    insDT.Rows.Add("RELEASED", product, 1, uom, lot_no, expiry);
                    sql += LedgerSupport.UpdateLocationProductsLedger(insDT);


                    //insDT = LedgerSupport.GetLocationBinProductsLedgerDT();
                    //insDT.Rows.Add("RELEASED", product, 1, uom, lot_no, expiry);
                    //sql += LedgerSupport.UpdateLocationProductsLedger(insDT);
                }

                DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);

                SynchroSupport.UpdateOrderStatus(release_id);
                LoadData();
            }
        }
     

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save and Print Releasing Report")
            {

            }
        }

        private void SaveData()
        {

        }

        private void txtScan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
