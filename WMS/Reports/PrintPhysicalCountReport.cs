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
    public partial class PrintPhysicalCountReport : Form
    {
        public PhysicalCountCalendarReport parent = null;

        public PrintPhysicalCountReport()
        {
            InitializeComponent();
        }

        private void PrintPhysicalCountReport_Load(object sender, EventArgs e)
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

            foreach (DataGridViewRow row in parent.header_grid.Rows)
            {
                sb.Append("<tr>");
                foreach (DataGridViewColumn col in parent.header_grid.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(row.Cells[parent.header_grid.Columns.IndexOf(col)].Value);
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");



            webBrowser1.DocumentText = Properties.Resources.pc_calendar
                .Replace("[run_datetime]", DateTime.Now.ToString())
                .Replace("[header_table]", sb.ToString())

                ;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
