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
    public partial class NewReceiptConfirmationWindow : Form
    {
        public NewReceiptsWindow parent = null;
        DataTable receivingreport = null;
        public NewReceiptConfirmationWindow()
        {
            InitializeComponent();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (btnPrintPreview.Text != "Print")
                SaveData();
            else
            {
                viewer.PrintReport();
            }
        }

        private void SaveData()
        {
            String id = DataSupport.GetNextMenuCodeInt("RC");

            // Save Transaction
            String sql = DataSupport.GetInsert("Receipts", Utils.ToDict(
                "receipt_id", id
               , "received_from", parent.txtReceivedFrom.Text
               , "received_on", parent.txtReceivedOn.Value.ToShortDateString()
               , "received_by", parent.cboReceivedBy.Text
               , "encoded_on", DateTime.Now
                ));

            foreach (DataGridViewRow row in parent.headerGrid.Rows)
            {
                sql += DataSupport.GetInsert("ReceiptDetails", Utils.ToDict(
                      "receipt", id
                     , "line", parent.headerGrid.Rows.IndexOf(row) + 1
                     , "product", row.Cells["product_id"].Value.ToString()
                     , "qty", row.Cells["Quantity"].Value.ToString()
                     , "uom", row.Cells["uom"].Value.ToString()
                     , "lot_no", row.Cells["lot"].Value.ToString()
                     , "expiry", row.Cells["expiry"].Value.ToString()
                     , "remarks", row.Cells["remarks"].Value.ToString()
                    ));
            }


            // Update Location Ledger
            sql += DataSupport.GetInsert("LocationLedger", Utils.ToDict(
                "location", "STAGING-IN"
               , "transaction_datetime", parent.txtReceivedOn.Value.ToShortDateString()
               , "transaction_type", "IN"
               , "transaction_name", "RECEIPT"
               , "transaction_id", id
                ));

            // Update Location Products Ledger
            foreach (DataGridViewRow row in parent.headerGrid.Rows)
            {

                if (FAQ.IsNewLine("STAGING-IN", row.Cells["product_id"].Value.ToString(), row.Cells["uom"].Value.ToString(), row.Cells["lot"].Value.ToString(), row.Cells["expiry"].Value.ToString()))
                {
                    sql += "UPDATE LocationProductsLedger SET qty = qty + " + row.Cells["Quantity"].Value.ToString() + " WHERE location = '" + "STAGING-IN" + "' AND product='" + row.Cells["product_id"].Value.ToString() + "' AND uom ='" + row.Cells["uom"].Value.ToString() + "' AND lot_no = '" + row.Cells["lot"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "'";
                }
                else
                {
                    sql += DataSupport.GetInsert("LocationProductsLedger", Utils.ToDict(
                          "location", "STAGING-IN"
                         , "product", row.Cells["product_id"].Value.ToString()
                         , "qty", row.Cells["Quantity"].Value.ToString()
                         , "uom", row.Cells["uom"].Value.ToString()
                         , "lot_no", row.Cells["lot"].Value.ToString()
                         , "expiry", row.Cells["expiry"].Value.ToString()
                        ));
                }
            }



            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);


            if (parent.oms_shipment_id != "")
            {
                DataSupport oms_dh = new DataSupport(String.Format(@"Initial Catalog={0};Data Source= {1};User Id = {2}; Password = {3}", Utils.DBConnection["OMS"]["DBNAME"], Utils.DBConnection["OMS"]["SERVER"], Utils.DBConnection["OMS"]["USERNAME"], Utils.DBConnection["OMS"]["PASSWORD"]));
                StringBuilder oms_sql = new StringBuilder("UPDATE IncomingShipmentRequests SET status = 'RECEIVED', received_on = '" + DateTime.Now + "' WHERE shipment_id = '" + parent.oms_shipment_id + "'; ");

                foreach (DataGridViewRow row in parent.headerGrid.Rows)
                {
                    oms_sql.Append("UPDATE IncomingShipmentRequestDetails SET received_qty = '" + row.Cells["Quantity"].Value.ToString() + "' WHERE shipment = '" + parent.oms_shipment_id + "' AND product = '" + row.Cells["product_id"].Value.ToString() + "' AND uom = '" + row.Cells["uom"].Value.ToString() + "' AND lot_no='" + row.Cells["lot"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "';");
                }

                oms_dh.ExecuteNonQuery(oms_sql.ToString());


            }
            MessageBox.Show("Success");

            receivingreport.Columns.Remove("receivedid");
            DataColumn dc = new DataColumn("receivedid");
            dc.DefaultValue = id;
            receivingreport.Columns.Add(dc);
            CrystalDecisions.CrystalReports.Engine.ReportDocument rviewer = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rviewer = new crtreceivingreport();
            rviewer.SetDataSource(receivingreport);

            viewer.ReportSource = rviewer;
            viewer.RefreshReport();
            btnPrintPreview.Text = "Print";
            btnCancel.Text = "Close";
        }

       
        private void NewReceiptConfirmationWindow_Load(object sender, EventArgs e)
        {

            btnPrintPreview.Select();

            receivingreport = new DataTable();
            receivingreport.Columns.Add("receivedid");
            receivingreport.Columns.Add("receivedby");
            receivingreport.Columns.Add("receivedon");
            receivingreport.Columns.Add("receivedfrom");
            receivingreport.Columns.Add("refno");
            receivingreport.Columns.Add("Product");
            receivingreport.Columns.Add("desc");
            receivingreport.Columns.Add("Qty");
            receivingreport.Columns.Add("Uom");
            receivingreport.Columns.Add("Lot");
            receivingreport.Columns.Add("Expiry");
            receivingreport.Columns.Add("remarks");

            foreach (DataGridViewRow row in parent.headerGrid.Rows)
            {
                receivingreport.Rows.Add("(issued on save)",parent.cboReceivedBy.Text,parent.txtReceivedOn.Value.ToShortDateString(),parent.txtReceivedFrom.Text,parent.txtReferenceDocument.Text
                                         ,row.Cells["product_id"].Value, row.Cells["product"].Value, row.Cells["uom"].Value, row.Cells["quantity"].Value
                                         , row.Cells["lot"].Value, Convert.ToDateTime(row.Cells["expiry"].Value).ToShortDateString(), row.Cells["remarks"].Value);
            }

            CrystalDecisions.CrystalReports.Engine.ReportDocument rviewer = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rviewer = new crtreceivingreport();
            rviewer.SetDataSource(receivingreport);

            viewer.ReportSource = rviewer;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewReceiptConfirmationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (btnPrintPreview.Text == "Print")
                DialogResult = DialogResult.OK;
        }
    }
}
