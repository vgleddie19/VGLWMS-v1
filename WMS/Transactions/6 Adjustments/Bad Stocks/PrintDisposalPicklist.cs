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
    public partial class PrintDisposalPicklist : Form
    {

        public StocksAgeReport parent = null;

        public PrintDisposalPicklist()
        {
            InitializeComponent();
        }

        private void PrintDisposalPicklist_Load(object sender, EventArgs e)
        {
            btnPrintPreview.Select();

            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table'>");

            sb.Append("<thead>");
            sb.Append("<tr>");

            {
                foreach (DataGridViewColumn col in parent.header_grid.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(col.HeaderText);
                    sb.Append("</th>");
                }
            }

            sb.Append("</tr>");
            sb.Append("</thead>");

            foreach (DataGridViewRow row in parent.header_grid.SelectedRows)
            {
                sb.Append("<tr>");
                foreach (DataGridViewColumn col in parent.header_grid.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(row.Cells[col.Name].Value.ToString());
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");



            webBrowser1.DocumentText = Properties.Resources.dispose_picklist_report
                .Replace("[run_datetime]", DateTime.Now.ToString())
                .Replace("[picklist_table]", sb.ToString())

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
            
            String id = DataSupport.GetNextMenuCodeInt("PL");
            DateTime now = DateTime.Now;


            // Save Transaction
            String sql = "";

            foreach (DataGridViewRow row in parent.header_grid.SelectedRows)
            {
                sql += DataSupport.GetInsert("ForDisposals", Utils.ToDict(
                      "trans_id", id
                     , "product", row.Cells["Product"].Value.ToString()
                     , "qty", row.Cells["Qty"].Value.ToString()
                     , "uom", row.Cells["Uom"].Value.ToString()
                     , "lot_no", row.Cells["Lot No"].Value.ToString()
                     , "expiry", row.Cells["Expiry"].Value.ToString()
                     , "reason", row.Cells["Days To Expiry"].Value.ToString()
                    ));



                // Update Transaction Ledger
                {
                    DataTable insDT = LedgerSupport.GetLocationLedgerDT();
                    insDT.Rows.Add("STAGING-OUT", now, "IN", "CANCEL_ORDER", id);
                    sql += LedgerSupport.UpdateLocationLedger(insDT);


                    DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
                    outsDT.Rows.Add(row.Cells["Location"].Value.ToString(), now, "OUT", "CANCEL_ORDER", id);
                    sql += LedgerSupport.UpdateLocationLedger(outsDT);
                }




                // Update Location Products Ledger
                {
                    DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();
                    insDT.Rows.Add("STAGING-OUT", row.Cells["Product"].Value, row.Cells["Qty"].Value, row.Cells["Uom"].Value, row.Cells["Lot No"].Value, row.Cells["Expiry"].Value);
                    sql += LedgerSupport.UpdateLocationProductsLedger(insDT);

                    DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();
                    outsDT.Rows.Add(row.Cells["Location"].Value.ToString(), row.Cells["Product"].Value, int.Parse(row.Cells["Qty"].Value.ToString()) * -1, row.Cells["Uom"].Value, row.Cells["Lot No"].Value, row.Cells["Expiry"].Value, int.Parse(row.Cells["qty"].Value.ToString()) * -1, int.Parse(row.Cells["Qty"].Value.ToString()) * -1);
                    sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);
                }

            }

            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");

            webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", id);
            btnPrintPreview.Text = "Print";
            btnCancel.Visible = false;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
