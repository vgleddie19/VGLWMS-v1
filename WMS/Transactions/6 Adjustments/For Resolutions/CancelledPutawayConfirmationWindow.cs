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
    public partial class CancelledPutawayConfirmationWindow : Form
    {
        public CancelledPalletPutawayWindow parent = null;
        public CancelledPutawayConfirmationWindow()
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
            DateTime now = DateTime.Now;
            String putaway_id = DataSupport.GetNextMenuCodeInt("PA");

            // Save Transaction
            String sql = DataSupport.GetInsert("Putaways", Utils.ToDict(
                "putaway_id", putaway_id
               , "container", "CANCELLED_PALLET"
               , "encoded_on", now
               , "completed", now
                ));

            foreach (DataGridViewRow row in parent.items_grid.Rows)
            {
                sql += DataSupport.GetInsert("PutawayDetails", Utils.ToDict(
                      "putaway", putaway_id
                     , "product", row.Cells["Product"].Value.ToString()
                     , "expected_qty", row.Cells["Qty"].Value.ToString()
                     , "uom", row.Cells["Uom"].Value.ToString()
                     , "lot_no", row.Cells["Lot No"].Value.ToString()
                     , "expiry", row.Cells["Expiry"].Value.ToString()
                     , "location", row.Cells["Putaway To"].Value.ToString()
                     , "actual_qty", row.Cells["Qty"].Value.ToString()
                    ));
            }



            // Update Transaction Ledger
            {
                // Out with the cancelled pallet
                DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
                outsDT.Rows.Add("CANCELLED_PALLET", now, "OUT", "CANCELLED_PUTAWAY", putaway_id);

                sql += LedgerSupport.UpdateLocationLedger(outsDT);


                // In with the location
                DataTable insDT = LedgerSupport.GetLocationLedgerDT();
                foreach (DataGridViewRow row in parent.items_grid.Rows)
                    insDT.Rows.Add(row.Cells["Putaway To"].Value.ToString(), now, "IN", "CANCELLED_PUTAWAY", putaway_id);
                sql += LedgerSupport.UpdateLocationLedger(insDT);

            }

            // Update Location Products Ledger
            {
                // Out with the cancelled pallet
                DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataGridViewRow row in parent.items_grid.Rows)
                    outsDT.Rows.Add("CANCELLED_PALLET", row.Cells["Product"].Value, int.Parse(row.Cells["Qty"].Value.ToString()) * -1, row.Cells["Uom"].Value, row.Cells["Lot No"].Value, row.Cells["Expiry"].Value);
                sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);


                // In with the location
                DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataGridViewRow row in parent.items_grid.Rows)
                    insDT.Rows.Add(row.Cells["Putaway To"].Value.ToString(), row.Cells["Product"].Value, row.Cells["Qty"].Value, row.Cells["Uom"].Value, row.Cells["Lot No"].Value, row.Cells["Expiry"].Value);
                sql += LedgerSupport.UpdateLocationProductsLedger(insDT);

            }



            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");

            webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", putaway_id);
            btnPrintPreview.Text = "Print";
            btnCancel.Text = "Closed";
            
        }


        private void NewReceiptConfirmationWindow_Load(object sender, EventArgs e)
        {

            btnPrintPreview.Select();

            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table'>");

            sb.Append("<thead>");
            sb.Append("<tr>");

            {
                foreach (DataGridViewColumn col in parent.items_grid.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(col.HeaderText);
                    sb.Append("</th>");
                }
            }

            sb.Append("</tr>");
            sb.Append("</thead>");

            foreach (DataGridViewRow row in parent.items_grid.Rows)
            {
                sb.Append("<tr>");
                foreach (DataGridViewColumn col in parent.items_grid.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(row.Cells[col.Name].Value.ToString());
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");



            webBrowser1.DocumentText = Properties.Resources.putaway_report
                .Replace("[container_id]", "CANCELLED_PALLET")
                .Replace("[container_type]", "CANCELLED_PALLET")
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
