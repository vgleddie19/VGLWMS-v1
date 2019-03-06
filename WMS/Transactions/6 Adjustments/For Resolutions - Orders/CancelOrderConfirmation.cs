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
    public partial class CancelOrderConfirmation : Form
    {

        public OrdersForResolutionsWindow parent = null;

        public CancelOrderConfirmation()
        {
            InitializeComponent();
        }

        private void CancelOrderConfirmation_Load(object sender, EventArgs e)
        {

            String reason = parent.dialog.txtReason.Text.EscapeString();
            String cancelled_by = parent.dialog.txtCancelled.Text.EscapeString();

            var selected_row = parent.header_grid.SelectedRows[0];
            String order_id = selected_row.Cells["Order ID"].Value.ToString();

            DataTable pickedDT = FAQ.GetPickedItems(FAQ.GetPicklistID(order_id), order_id);

            btnPrintPreview.Select();


            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table'>");

            sb.Append("<thead>");
            sb.Append("<tr>");

            {
                foreach (DataColumn col in pickedDT.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(col.ColumnName);
                    sb.Append("</th>");
                }
            }

            sb.Append("</tr>");
            sb.Append("</thead>");

            foreach (DataRow row in pickedDT.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn col in pickedDT.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(row[col].ToString());
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");



            webBrowser1.DocumentText = Properties.Resources.order_cancel
                .Replace("[cancelled_on]", DateTime.Now.ToString())
                .Replace("[order_id]", selected_row.Cells["Order ID"].Value.ToString())
                .Replace("[client]", selected_row.Cells["Client"].Value.ToString())
                .Replace("[customer]", selected_row.Cells["Customer"].Value.ToString())
                .Replace("[invoice_amount]", selected_row.Cells["Invoice Value"].Value.ToString())
                .Replace("[reason]", reason)
                .Replace("[cancelled_by]", cancelled_by)
                .Replace("[products_table]", sb.ToString())
                ;

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
            // Inform OMS
            var selected_row = parent.header_grid.SelectedRows[0];
            String order_id = selected_row.Cells["Order ID"].Value.ToString();
            DateTime now = DateTime.Now;
            String id = DataSupport.GetNextMenuCodeInt("ORC");



            // Get Reason
            String reason = parent.dialog.txtReason.Text.EscapeString();

            String sql = "";
            sql += " UPDATE ReleaseOrders SET status='CANCELLED',cancel_id='"+id+"', cancel_reason ='" + reason + "', cancel_datetime='" + now + "', cancel_by='" + parent.dialog.txtCancelled.Text.EscapeString() + "'  WHERE order_id= '" + order_id + "'; ";

            // Get Picked Items
            DataTable pickedDT = FAQ.GetPickedItems(FAQ.GetPicklistID(order_id), order_id);


            // Good Stocks
            // Move from Staging out to Cancelled Pallet

            // Update Transaction Ledger
            {
                DataTable insDT = LedgerSupport.GetLocationLedgerDT();

                insDT.Rows.Add("CANCELLED_PALLET", now, "IN", "CANCEL_ORDER", order_id);

                sql += LedgerSupport.UpdateLocationLedger(insDT);


                DataTable outsDT = LedgerSupport.GetLocationLedgerDT();

                outsDT.Rows.Add("STAGING-OUT", now, "OUT", "CANCEL_ORDER", order_id);

                sql += LedgerSupport.UpdateLocationLedger(outsDT);
            }




            // Update Location Products Ledger
            {
                DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataRow row in pickedDT.Rows)
                    insDT.Rows.Add("CANCELLED_PALLET", row["product"], row["qty"], row["uom"], row["lot_no"], row["expiry"]);
                sql += LedgerSupport.UpdateLocationProductsLedger(insDT);

                DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataRow row in pickedDT.Rows)
                    outsDT.Rows.Add("STAGING-OUT", row["product"], int.Parse(row["qty"].ToString()) * -1, row["uom"], row["lot_no"], row["expiry"], int.Parse(row["qty"].ToString()) * -1, int.Parse(row["qty"].ToString()) * -1);
                sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);
            }





            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");

            webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", id);
            btnPrintPreview.Text = "Print";
            btnCancel.Visible = false;
        }
    }
}
