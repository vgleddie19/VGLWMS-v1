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
    public partial class NewPutawayConfirmationWindow : Form
    {
        public NewPutawayWindow parent = null;

        public NewPutawayConfirmationWindow()
        {
            InitializeComponent();
        }

        private void NewPutawayConfirmationWindow_Load(object sender, EventArgs e)
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



            webBrowser1.DocumentText = Properties.Resources.putaway_report
                .Replace("[container_type]", parent.cboContainer.Text)
                .Replace("[container_id]", parent.cboContainer.SelectedValue.ToStringNull())
                .Replace("[run_datetime]", DateTime.Now.ToString())
                .Replace("[header_table]", sb.ToString())

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
            String putaway_id = DataSupport.GetNextMenuCodeInt("PA");
            DateTime now = DateTime.Now;

            // Save Transaction
            String sql = DataSupport.GetInsert("Putaways", Utils.ToDict(
                "putaway_id", putaway_id
               , "container", parent.cboContainer.SelectedValue.ToStringNull()
               , "encoded_on", now
                ));

            foreach (DataGridViewRow row in parent.headerGrid.Rows)
            {
                sql += DataSupport.GetInsert("PutawayDetails", Utils.ToDict(
                      "putaway", putaway_id
                     , "product", row.Cells["product"].Value.ToString()
                     , "expected_qty", row.Cells["Quantity"].Value.ToString()
                     , "uom", row.Cells["uom"].Value.ToString()
                     , "lot_no", row.Cells["lot"].Value.ToString()
                     , "expiry", row.Cells["expiry"].Value.ToString()
                     , "location", row.Cells["location"].Value.ToString()
                    ));
            }


            // Update Transaction Ledger
            {
                // Out with the staging in
                DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
                outsDT.Rows.Add("STAGING-IN", now, "OUT", "PUTAWAY", putaway_id);

                sql += LedgerSupport.UpdateLocationLedger(outsDT);


                // In with the container
                DataTable insDT = LedgerSupport.GetLocationLedgerDT();
                foreach (DataGridViewRow row in parent.headerGrid.Rows)
                    insDT.Rows.Add(parent.cboContainer.SelectedValue.ToStringNull(), now, "IN", "PUTAWAY", putaway_id);
                sql += LedgerSupport.UpdateLocationLedger(insDT);

            }

            // Update Location Products Ledger
            {
                // Out with the staging in
                DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataGridViewRow row in parent.headerGrid.Rows)
                    outsDT.Rows.Add("STAGING-IN", row.Cells["product"].Value, int.Parse(row.Cells["Quantity"].Value.ToString()) * -1, row.Cells["uom"].Value, row.Cells["lot"].Value, row.Cells["expiry"].Value);
                sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);


                // In with the container
                DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataGridViewRow row in parent.headerGrid.Rows)
                    insDT.Rows.Add(parent.cboContainer.SelectedValue.ToStringNull(), row.Cells["product"].Value, row.Cells["Quantity"].Value, row.Cells["uom"].Value, row.Cells["lot"].Value, row.Cells["expiry"].Value);
                sql += LedgerSupport.UpdateLocationProductsLedger(insDT);

            }         

            try
            {
                DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);

                MessageBox.Show("Success");

                webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", putaway_id);
                btnPrintPreview.Text = "Print";
                btnCancel.Text = "Closed";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewPutawayConfirmationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (btnPrintPreview.Text == "Print")
                this.DialogResult = DialogResult.OK;
        }
    }
}
