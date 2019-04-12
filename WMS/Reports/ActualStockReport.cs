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
    public partial class ActualStockReport : Form
    {
        WebBrowser webBrowser1 = new WebBrowser();
        public ActualStockReport()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTable dt = DataSupport.RunDataSet(@"SELECT Location, Product,Description, Uom,Qty, lot_no[Lot No], Expiry
                            FROM LocationProductsLedger l JOIN products p on l.product = p.product_id
                            WHERE  qty >0 AND location !='RELEASED'
                            ORDER BY expiry ").Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                DateTime expiry = DateTime.Parse(row["Expiry"].ToString());
                DateTime today = DateTime.Parse(DateTime.Now.ToShortDateString());
                var total_days = ((int)expiry.Subtract(today).TotalDays).ToString();

                if (double.Parse(total_days) <= 0)
                    total_days = "EXPIRED";

                //if (row["expiry_status"].ToString() != "")
                //    total_days = row["expiry_status"].ToString();


                row["Expiry"] = DateTime.Parse(row["Expiry"].ToString()).ToShortDateString();
                //row["Days To Expiry"] = total_days;
            }
            //dt.Columns.Remove("expiry_status");
            header_grid.DataSource = dt;
        }

        private void ActualStockReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDeclareExpiredStocks_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table'>");

            sb.Append("<thead>");
            sb.Append("<tr>");

            {
                foreach (DataGridViewColumn col in header_grid.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(col.HeaderText);
                    sb.Append("</th>");
                }
            }

            sb.Append("</tr>");
            sb.Append("</thead>");

            foreach (DataGridViewRow row in header_grid.Rows)
            {
                sb.Append("<tr>");
                foreach (DataGridViewColumn col in header_grid.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(row.Cells[header_grid.Columns.IndexOf(col)].Value);
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");



            webBrowser1.DocumentText = Properties.Resources.actualstockreport
                .Replace("[run_datetime]", DateTime.Now.ToString())
                .Replace("[stocks_table]", sb.ToString())

                ;
            webBrowser1.ShowPrintPreviewDialog();
        }
    }
}
