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
                webBrowser1.ShowPrintPreviewDialog();
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

            webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", id);
            btnPrintPreview.Text = "Print";
            btnCancel.Visible = false;
        }

       
        private void NewReceiptConfirmationWindow_Load(object sender, EventArgs e)
        {

            btnPrintPreview.Select();

            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table'>");

            sb.Append("<thead>");
            sb.Append("<tr>");

            {
                foreach (DataGridViewColumn col in parent.headerGrid.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(col.HeaderText);
                    sb.Append("</th>");
                }
            }

            sb.Append("</tr>");
            sb.Append("</thead>");

            foreach (DataGridViewRow row in parent.headerGrid.Rows)
            {
                sb.Append("<tr>");
                foreach (DataGridViewColumn col in parent.headerGrid.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(row.Cells[col.Name].Value.ToString());
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");



            webBrowser1.DocumentText = Properties.Resources.receiving_report
                .Replace("[received_from]",parent.txtReceivedFrom.Text)
                .Replace("[received_on]", parent.txtReceivedOn.Value.ToShortDateString())
                .Replace("[reference_document]", parent.txtReferenceDocument.Text)
                .Replace("[received_by]", parent.cboReceivedBy.Text)
                .Replace("[run_datetime]", DateTime.Now.ToString())
                .Replace("[header_table]", sb.ToString())
                ;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
