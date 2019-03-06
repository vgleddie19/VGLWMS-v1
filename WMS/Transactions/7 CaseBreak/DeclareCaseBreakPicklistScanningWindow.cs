using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS
{
    public partial class DeclareCaseBreakPicklistScanningWindow : Form
    {
        public DataTable casebreak_detailscan = new DataTable();
        public DeclareCaseBreakPicklistScanningWindow()
        {
            InitializeComponent();

            casebreak_detailscan.Columns.Add("product");
            casebreak_detailscan.Columns.Add("lotno");
            casebreak_detailscan.Columns.Add("expiry");
            casebreak_detailscan.Columns.Add("location");
            casebreak_detailscan.Columns.Add("uom");
            casebreak_detailscan.Columns.Add("qty");
        }

        private void DeclareCaseBreakPicklistScanningWindow_Load(object sender, EventArgs e)
        {
            DataTable dt = DataSupport.RunDataSet("SELECT Product, qty[Quantity], Uom, lot_no [Lot No], Expiry , Location,breakto_uom[Break To]  FROM CaseBreakDetails WHERE casebreak = '" + txtPicklist.Text + "'").Tables[0];
            picklist_details_grid.DataSource = dt;
        }

        private void SyncSaveButton()
        {
            if (picklist_details_grid.Rows.Count > 0)
                btnSave.Text = "Declare Incomplete";
            else
                btnSave.Text = "Declare Complete";
        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataRow products_row = BarcodeSupport.GetProductFromBarcode(txtScan.Text);
                if (products_row == null)
                {
                    MessageBox.Show("Barcode Not Recognized!");
                    return;
                }

                String product = products_row["PRODUCT"].ToString();
                String uom = products_row["MATCHED_UOM"].ToString();
                
                DataTable lotsDt = new DataTable();
                lotsDt.Columns.Add("Lot No");
                lotsDt.Columns.Add("Expiry");
                lotsDt.Columns.Add("Location");

                foreach (DataGridViewRow row in picklist_details_grid.Rows)
                {
                    if (row.Cells["product"].Value.ToString() == product
                        && row.Cells["uom"].Value.ToString().Replace("PIECES", "PCS") == uom.Replace("PIECES", "PCS")
                        && int.Parse(row.Cells["Quantity"].Value.ToString()) > 0
                        )
                    {
                        lotsDt.Rows.Add(row.Cells["Lot No"].Value.ToString(), row.Cells["Expiry"].Value.ToString(), row.Cells["Location"].Value.ToString());
                    }
                }

                if (lotsDt.Rows.Count == 0)
                {
                    MessageBox.Show("Scanned item not recognized!");
                    return;
                }
                SelectGridWindow select_dialog = new SelectGridWindow();
                select_dialog.dataGridView1.DataSource = lotsDt;
                if (select_dialog.ShowDialog() == DialogResult.OK)
                {
                    DeclareCaseBreakPCS cbpcs_dialog = new DeclareCaseBreakPCS();
                    cbpcs_dialog.lblProduct.Text = product;
                    Dictionary<String, String> productbreakdetails = getProductSupportDetail(product, uom, select_dialog.dataGridView1.SelectedRows[0]);
                    cbpcs_dialog.lblUOM.Text = productbreakdetails["breakto"];
                    cbpcs_dialog.productsupportdetail = productbreakdetails;
                    cbpcs_dialog.parent = this;

                    if (cbpcs_dialog.ShowDialog() == DialogResult.OK)
                    {
                        var selected_row = select_dialog.dataGridView1.SelectedRows[0];

                        List<DataGridViewRow> for_deletion = new List<DataGridViewRow>();
                        foreach (DataGridViewRow row in picklist_details_grid.Rows)
                        {
                            if (row.Cells["product"].Value.ToString() == product
                                && row.Cells["uom"].Value.ToString().Replace("PIECES", "PCS") == uom.Replace("PIECES", "PCS")
                                && row.Cells["Lot No"].Value.ToString() == selected_row.Cells["Lot No"].Value.ToString()
                                && row.Cells["Expiry"].Value.ToString() == selected_row.Cells["Expiry"].Value.ToString()
                                && row.Cells["Location"].Value.ToString() == selected_row.Cells["Location"].Value.ToString()
                                )
                            {
                                row.Cells["Quantity"].Value = int.Parse(row.Cells["Quantity"].Value.ToString()) - 1;
                                if (int.Parse(row.Cells["Quantity"].Value.ToString()) <= 0)
                                    for_deletion.Add(row);

                                Boolean is_existing = false;
                                foreach (DataGridViewRow scanned_row in scanned_grid.Rows)
                                {
                                    if (scanned_row.Cells["product"].Value.ToString() == product
                                && scanned_row.Cells["uom"].Value.ToString().Replace("PIECES", "PCS") == uom.Replace("PIECES", "PCS")
                                && scanned_row.Cells["lot_no"].Value.ToString() == selected_row.Cells["Lot No"].Value.ToString()
                                && scanned_row.Cells["expiry"].Value.ToString() == selected_row.Cells["Expiry"].Value.ToString()
                                && scanned_row.Cells["original_location"].Value.ToString() == selected_row.Cells["Location"].Value.ToString()
                                        )
                                    {
                                        scanned_row.Cells["qty"].Value = int.Parse(scanned_row.Cells["qty"].Value.ToString()) + 1;
                                        is_existing = true;
                                    }
                                }

                                if (!is_existing)
                                {
                                    scanned_grid.Rows.Add(product, 1, uom, selected_row.Cells["Lot No"].Value.ToString(), selected_row.Cells["Expiry"].Value.ToString(), "STAGING-OUT", selected_row.Cells["Location"].Value.ToString());
                                }
                                break;

                            }
                        }
                        scanned_grid_details.Rows.Clear();
                        foreach (DataRow dRow in casebreak_detailscan.Rows)
                        {
                            scanned_grid_details.Rows.Add(dRow["product"], dRow["qty"], dRow["uom"], dRow["lotno"], dRow["expiry"], dRow["location"]);
                        }

                        foreach (DataGridViewRow row in for_deletion)
                        {
                            picklist_details_grid.Rows.Remove(row);
                        }

                        txtScan.Text = "";
                        txtScan.Focus();
                        SyncSaveButton();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Declare Complete")
                DeclareComplete();
            else
                DeclareIncomplete();
        }

        private void DeclareComplete()
        {
            //MessageBox.Show("Under Construction...");
            //return;

            StringBuilder sql = new StringBuilder();
            String picklist_id = txtPicklist.Text;
            DateTime now = DateTime.Now;



            //// Update Picklist
            sql.Append("UPDATE Picklists SET status = 'DECLARED COMPLETE' WHERE picklist_id= '" + picklist_id + "'; ");

            // Update Transaction Ledger
            {
            DataTable insDT = LedgerSupport.GetLocationLedgerDT();

            insDT.Rows.Add("STAGING-OUT", now, "IN", "CASEBREAK_PICKLIST_DECLARE_COMPLETE", picklist_id);
            foreach (DataGridViewRow row in scanned_grid_details.Rows)
                insDT.Rows.Add("STAGING-IN", now, "IN", "CASEBREAK_PICKLIST_DECLARE_COMPLETE", picklist_id);

            sql.Append(LedgerSupport.UpdateLocationLedger(insDT));

            DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
            foreach (DataGridViewRow row in scanned_grid.Rows)
                outsDT.Rows.Add(row.Cells["original_location"].Value, now, "OUT", "CASEBREAK_PICKLIST_DECLARE_COMPLETE", picklist_id);

            sql.Append(LedgerSupport.UpdateLocationLedger(outsDT));
            }

            //// Update Location Products Ledger
            {
                DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataGridViewRow row in scanned_grid_details.Rows)
                    insDT.Rows.Add("STAGING-IN", row.Cells["product"].Value, row.Cells["qty"].Value, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value);

                foreach (DataGridViewRow row in scanned_grid.Rows)
                    insDT.Rows.Add("STAGING-OUT", row.Cells["product"].Value, row.Cells["qty"].Value, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value);
                sql.Append(LedgerSupport.UpdateLocationProductsLedger(insDT));

                DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataGridViewRow row in scanned_grid.Rows)
                    outsDT.Rows.Add(row.Cells["original_location"].Value, row.Cells["product"].Value, int.Parse(row.Cells["qty"].Value.ToString()) * -1, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value, int.Parse(row.Cells["qty"].Value.ToString()) * -1, int.Parse(row.Cells["qty"].Value.ToString()) * -1);
                sql.Append(LedgerSupport.UpdateLocationProductsLedger(outsDT));
            }

            DataSupport.RunNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");
            //this.Close();

        }

        private void DeclareIncomplete()
        {
            MessageBox.Show("Under Construction...");
            //String sql = "";
            //String picklist_id = txtPicklist.Text;
            //String now = DateTime.Now.ToString();

            //// Flags if user chooses missing / bad stocks for order resolution updating
            //Boolean has_missing = false;
            //Boolean has_bad_stocks = false;


            //DataTable BadStockDT = new DataTable();
            //BadStockDT.Columns.Add("Location");
            //BadStockDT.Columns.Add("Product");
            //BadStockDT.Columns.Add("Uom");
            //BadStockDT.Columns.Add("Lot No");
            //BadStockDT.Columns.Add("Expiry");
            //BadStockDT.Columns.Add("Qty");
            //BadStockDT.Columns.Add("Reason");
            //BadStockDT.Columns.Add("Bad Stock Storage");


            //// Update Picklist
            //sql += "UPDATE Picklists SET status = 'DECLARED INCOMPLETE' WHERE picklist_id= '" + picklist_id + "'; ";


            //DataTable order_ids = FAQ.GetOrdersFromPicklist(picklist_id);

            //// Update Order Status
            //foreach (DataRow row in order_ids.Rows)
            //    sql += " UPDATE ReleaseOrders SET status='FOR RELEASING' WHERE order_id= '" + row["order_id"] + "' ";


            //// Good Stocks
            //// Move from Storage to Staging out

            //// Update Transaction Ledger
            //{
            //    DataTable insDT = LedgerSupport.GetLocationLedgerDT();

            //    insDT.Rows.Add("STAGING-OUT", now, "IN", "PICKLIST_DECLARE_INCOMPLETE", picklist_id);

            //    sql += LedgerSupport.UpdateLocationLedger(insDT);


            //    DataTable outsDT = LedgerSupport.GetLocationLedgerDT();

            //    foreach (DataGridViewRow row in scanned_grid.Rows)
            //        outsDT.Rows.Add(row.Cells["original_location"].Value, now, "OUT", "PICKLIST_DECLARE_INCOMPLETE", picklist_id);

            //    sql += LedgerSupport.UpdateLocationLedger(outsDT);
            //}




            //// Update Location Products Ledger
            //{
            //    DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

            //    foreach (DataGridViewRow row in scanned_grid.Rows)
            //        insDT.Rows.Add("STAGING-OUT", row.Cells["product"].Value, row.Cells["qty"].Value, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value);
            //    sql += LedgerSupport.UpdateLocationProductsLedger(insDT);

            //    DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();

            //    foreach (DataGridViewRow row in scanned_grid.Rows)
            //        outsDT.Rows.Add(row.Cells["original_location"].Value, row.Cells["product"].Value, int.Parse(row.Cells["qty"].Value.ToString()) * -1, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value, int.Parse(row.Cells["qty"].Value.ToString()) * -1, int.Parse(row.Cells["qty"].Value.ToString()) * -1);
            //    sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);
            //}




            //// Missing / Bad Stocks



            //// Specify if it's missing or bad
            //MissingOrBadGridWindow dialog = new MissingOrBadGridWindow();


            //foreach (DataGridViewRow row in picklist_details_grid.Rows)
            //{
            //    int qty = int.Parse(row.Cells["Quantity"].Value.ToString());

            //    for (int i = 0; i < qty; i++)
            //    {
            //        int index = dialog.header_grid.Rows.Add(
            //             row.Cells["Product"].Value.ToString()
            //           , row.Cells["Uom"].Value.ToString()
            //           , row.Cells["Lot No"].Value.ToString()
            //           , row.Cells["Expiry"].Value.ToString()
            //           , row.Cells["Location"].Value.ToString()
            //           , "1"
            //           );
            //        var new_row = dialog.header_grid.Rows[index];

            //    }

            //}


            //if (dialog.ShowDialog() != DialogResult.OK)
            //    return;


            //// For missing, Subtract from location and add a for resolutions - SHORTAGE


            //foreach (DataGridViewRow row in dialog.header_grid.Rows)
            //{
            //    if (row.Cells["what_happened"].Value.ToString() == "MISSING")
            //    {
            //        has_missing = true;

            //        // Update Transaction Ledger
            //        {
            //            DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
            //            outsDT.Rows.Add(row.Cells["location"].Value, now, "OUT", "PICKLIST_DECLARE_INCOMPLETE", picklist_id);
            //            sql += LedgerSupport.UpdateLocationLedger(outsDT);
            //        }

            //        // Update Location Products Ledger
            //        {
            //            DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();
            //            outsDT.Rows.Add(row.Cells["location"].Value, row.Cells["product"].Value, int.Parse(row.Cells["qty"].Value.ToString()) * -1, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value, int.Parse(row.Cells["qty"].Value.ToString()) * -1, int.Parse(row.Cells["qty"].Value.ToString()) * -1);
            //            sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);
            //        }

            //        // Update For Resolution
            //        sql += DataSupport.GetInsert("ForResolutions", Utils.ToDict(
            //              "trans_source", "PICKLIST_DECLARE_INCOMPLETE"
            //            , "trans_id", picklist_id
            //            , "detected_on", now
            //            , "product", row.Cells["product"].Value
            //            , "uom", row.Cells["uom"].Value
            //            , "lot_no", row.Cells["lot_no"].Value
            //            , "expiry", row.Cells["expiry"].Value
            //            , "location", row.Cells["location"].Value.ToString()
            //            , "variance_type", "SHORTAGE"
            //            , "variance_qty", row.Cells["qty"].Value
            //            , "status", "FOR RESOLUTION"
            //            , "line", dialog.header_grid.Rows.IndexOf(row) + 1
            //            ));
            //    }
            //}

            //// For bad stocks, Move it to bad stock storage and add a for resolutions - BAD STOCK
            //// Add a for resolutions - ORDERS
            //{
            //    ChooseBadStockLocationWindow grid_dialog = new ChooseBadStockLocationWindow();

            //    foreach (DataGridViewRow row in dialog.header_grid.Rows)
            //    {
            //        if (row.Cells["what_happened"].Value.ToString() == "BAD STOCKS")
            //        {
            //            has_bad_stocks = true;
            //            int index = grid_dialog.header_grid.Rows.Add(
            //                   row.Cells["Product"].Value.ToString()
            //                 , row.Cells["Uom"].Value.ToString()
            //                 , row.Cells["lot_no"].Value.ToString()
            //                 , row.Cells["Expiry"].Value.ToString()
            //                 , row.Cells["Location"].Value.ToString()
            //                 , "1"
            //                 );
            //        }
            //    }


            //    if (grid_dialog.header_grid.Rows.Count > 0)
            //    {
            //        if (grid_dialog.ShowDialog() != DialogResult.OK)
            //        {
            //            return;
            //        }


            //        foreach (DataGridViewRow row in grid_dialog.header_grid.Rows)
            //        {
            //            // Update the Printout
            //            BadStockDT.Rows.Add(
            //                  row.Cells["location"].Value.ToString()
            //                , row.Cells["product"].Value.ToString()
            //                , row.Cells["uom"].Value.ToString()
            //                , row.Cells["lot_no"].Value.ToString()
            //                , row.Cells["expiry"].Value.ToString()
            //                , row.Cells["qty"].Value.ToString()
            //                , row.Cells["reason"].Value.ToString()
            //                , row.Cells["bad_stock_location"].Value.ToString()
            //                );


            //            // Update Transaction Ledger
            //            {
            //                DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
            //                outsDT.Rows.Add(row.Cells["location"].Value, now, "OUT", "PICKLIST_DECLARE_INCOMPLETE", picklist_id);
            //                sql += LedgerSupport.UpdateLocationLedger(outsDT);

            //                DataTable insDT = LedgerSupport.GetLocationLedgerDT();
            //                insDT.Rows.Add(row.Cells["bad_stock_location"].Value, now, "IN", "PICKLIST_DECLARE_INCOMPLETE", picklist_id);
            //                sql += LedgerSupport.UpdateLocationLedger(insDT);
            //            }

            //            // Update Location Products Ledger
            //            {
            //                DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();
            //                outsDT.Rows.Add(row.Cells["location"].Value, row.Cells["product"].Value, int.Parse(row.Cells["qty"].Value.ToString()) * -1, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value, int.Parse(row.Cells["qty"].Value.ToString()) * -1, int.Parse(row.Cells["qty"].Value.ToString()) * -1);
            //                sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);


            //                DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();
            //                insDT.Rows.Add(row.Cells["bad_stock_location"].Value, row.Cells["product"].Value, int.Parse(row.Cells["qty"].Value.ToString()) * 1, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value);
            //                sql += LedgerSupport.UpdateLocationProductsLedger(insDT);
            //            }

            //            // Update For Resolution
            //            sql += DataSupport.GetInsert("ForResolutions", Utils.ToDict(
            //                  "trans_source", "PICKLIST_DECLARE_INCOMPLETE"
            //                , "trans_id", picklist_id
            //                , "detected_on", now
            //                , "product", row.Cells["product"].Value
            //                , "uom", row.Cells["uom"].Value
            //                , "lot_no", row.Cells["lot_no"].Value
            //                , "expiry", row.Cells["expiry"].Value
            //                , "location", row.Cells["location"].Value.ToString()
            //                , "variance_type", "BAD STOCKS"
            //                , "variance_qty", row.Cells["qty"].Value
            //                , "status", "FOR RESOLUTION"
            //                , "line", dialog.header_grid.Rows.IndexOf(row) + 1
            //                ));
            //        }
            //    }
            //}



            //{
            //    OrderHoldingWindow order_dialog = new OrderHoldingWindow();
            //    order_dialog.BadStockDT = BadStockDT;
            //    order_dialog.parent = this;

            //    foreach (DataGridViewRow row in picklist_details_grid.Rows)
            //    {
            //        order_dialog.products_grid.Rows.Add(
            //              row.Cells["product"].Value.ToString()
            //            , row.Cells["Uom"].Value.ToString()
            //            , row.Cells["expiry"].Value.ToString()
            //            , row.Cells["Lot No"].Value.ToString()
            //            , row.Cells["Quantity"].Value.ToString()
            //            , "0"
            //            );
            //    }

            //    foreach (DataGridViewRow scanned_row in scanned_grid.Rows)
            //    {
            //        foreach (DataGridViewRow row in order_dialog.products_grid.Rows)
            //        {
            //            if (row.Cells["product"].Value.ToString() == scanned_row.Cells["product"].Value.ToString()
            //             && row.Cells["uom"].Value.ToString() == scanned_row.Cells["uom"].Value.ToString()
            //             && row.Cells["expiry"].Value.ToString() == scanned_row.Cells["expiry"].Value.ToString()
            //             && row.Cells["lot_no"].Value.ToString() == scanned_row.Cells["lot_no"].Value.ToString()

            //                )
            //            {
            //                row.Cells["qty_ordered"].Value = int.Parse(row.Cells["qty_ordered"].Value.ToString()) + int.Parse(scanned_row.Cells["qty"].Value.ToString());
            //                row.Cells["qty_picked"].Value = scanned_row.Cells["qty"].Value.ToString();
            //            }
            //        }
            //    }


            //    if (order_dialog.ShowDialog() != DialogResult.OK)
            //        return;

            //    // Update Order Status for Orders put on hold
            //    DataTable order_compromisedDT = GetMergedOrders(order_dialog);

            //    foreach (DataRow row in order_compromisedDT.Rows)
            //        if (row["Status"].ToString() == "HOLD")
            //        {
            //            String reason = "";
            //            if (has_bad_stocks && has_missing)
            //                reason = "MISSING, BAD STOCK";
            //            else if (has_missing)
            //                reason = "MISSING";
            //            else if (has_bad_stocks)
            //                reason = "BAD STOCK";

            //            sql += " UPDATE ReleaseOrders SET status='FOR RESOLUTION', holding_transaction='" + picklist_id + "', holding_datetime='" + now + "', holding_reason='" + reason + "' WHERE order_id= '" + row["Order ID"] + "' ";
            //        }


            //}

            //DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            //MessageBox.Show("Success");
            //this.Close();

        }

        private Dictionary<String, String> getProductSupportDetail(String product, String uom, DataGridViewRow selected_row)
        {
            Dictionary<String, String>  result = new Dictionary<String, String>();
            foreach (DataGridViewRow row in picklist_details_grid.Rows)
            {
                if (row.Cells["product"].Value.ToString() == product
                    && row.Cells["uom"].Value.ToString().Replace("PIECES", "PCS") == uom.Replace("PIECES", "PCS")
                    && row.Cells["Lot No"].Value.ToString() == selected_row.Cells["Lot No"].Value.ToString()
                    && row.Cells["Expiry"].Value.ToString() == selected_row.Cells["Expiry"].Value.ToString()
                    && row.Cells["Location"].Value.ToString() == selected_row.Cells["Location"].Value.ToString()
                    )
                {
                    result .Add("lotno", row.Cells["Lot No"].Value.ToString());
                    result.Add("expiry", row.Cells["Expiry"].Value.ToString());
                    result.Add("breakto", row.Cells["Break To"].Value.ToString());
                    break;
                }
            }
            return result;
        }

        private DataTable GetMergedOrders(OrderHoldingWindow dialog)
        {
            DataTable result = new DataTable();

            result.Columns.Add("Order ID");
            result.Columns.Add("Total Invoice Amount");
            result.Columns.Add("Client");
            result.Columns.Add("Customer");
            result.Columns.Add("Qty Ordered");
            result.Columns.Add("Status");

            foreach (String key in dialog.orders_dict.Keys.ToList())
            {
                DataTable dt = dialog.orders_dict[key];
                foreach (DataRow row in dt.Rows)
                {
                    Boolean is_existing = false;
                    foreach (DataRow existing_row in result.Rows)
                    {
                        if (existing_row["Order ID"].ToString() == row["Order ID"].ToString())
                        {
                            is_existing = true;
                            break;
                        }
                    }
                    if (!is_existing)
                        result.Rows.Add(row.ItemArray);
                }
            }
            return result;
        }
    }
}
