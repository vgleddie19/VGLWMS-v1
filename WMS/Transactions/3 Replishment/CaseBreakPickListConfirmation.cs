using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.Transactions._3_Replishment
{
    public partial class CaseBreakPickListConfirmation : Form
    {
        public BinReplishmentWindow parent = null;
        public CaseBreakPickListConfirmation()
        {
            InitializeComponent();
        }

        private void CaseBreakPickListConfirmation_Load(object sender, EventArgs e)
        {
            StringBuilder picklist_builder = new StringBuilder();

            DataTable dt = new DataTable();
            dt.Columns.Add("Location");
            dt.Columns.Add("Product");
            dt.Columns.Add("Uom");
            dt.Columns.Add("Lot no");
            dt.Columns.Add("Expiry");
            dt.Columns.Add("Qty");
            foreach (DataGridViewRow row in parent.genpickgrid.Rows)
            {
                Boolean is_found = false;
                foreach (DataRow existing_row in dt.Rows)
                {
                    if (
                           existing_row["Location"].ToString() == row.Cells["Location"].Value.ToString()
                        && existing_row["Product"].ToString() == row.Cells["Product"].Value.ToString()
                        && existing_row["Lot no"].ToString() == row.Cells["lot_no"].Value.ToString()
                        && existing_row["Uom"].ToString() == row.Cells["uom"].Value.ToString()
                        && DateTime.Parse(existing_row["Expiry"].ToString()).ToShortDateString() == DateTime.Parse(row.Cells["expiry"].Value.ToString()).ToShortDateString()
                        )
                    {
                        existing_row["Qty"] = int.Parse(row.Cells["qty"].Value.ToString()) + int.Parse(existing_row["Qty"].ToString());
                        is_found = true;
                        break;
                    }

                }
                if (is_found)
                {
                    dt.Rows.Add(row.Cells["Location"].Value.ToString()
                                , row.Cells["Product"].Value.ToString()
                                , row.Cells["uom"].Value.ToString()
                                , row.Cells["lot_no"].Value.ToString()
                                , DateTime.Parse(row.Cells["expiry"].Value.ToString()).ToShortDateString()
                                , row.Cells["qty"].Value.ToString()
                                );
                }
            }
            picklist_builder.Append("<table class='table'>");

            picklist_builder.Append("<thead>");
            picklist_builder.Append("<tr>");

            {
                foreach (DataColumn col in dt.Columns)
                {
                    picklist_builder.Append("<th>");
                    picklist_builder.Append(col.ColumnName);
                    picklist_builder.Append("</th>");
                }
            }

            picklist_builder.Append("</tr>");
            picklist_builder.Append("</thead>");

            foreach (DataRow row in dt.Rows)
            {
                picklist_builder.Append("<tr>");
                foreach (DataColumn col in dt.Columns)
                {

                    picklist_builder.Append("<td>");
                    picklist_builder.Append(row[col].ToString());
                    picklist_builder.Append("</td>");
                }

                picklist_builder.Append("</tr>");
            }

            picklist_builder.Append("</table>");


            StringBuilder order_builder = new StringBuilder();
            order_builder.Append("<table class='table'>");

            order_builder.Append("<thead>");
            order_builder.Append("<tr>");

            {
                foreach (DataGridViewColumn col in parent.gencasebreakgrid.Columns)
                {
                    if (col.HeaderText.ToUpper() == "ORDER ID")
                        continue;
                    order_builder.Append("<th>");
                    order_builder.Append(col.HeaderText);
                    order_builder.Append("</th>");

                }
            }

            order_builder.Append("</tr>");
            order_builder.Append("</thead>");

            foreach (DataGridViewRow row in parent.gencasebreakgrid.Rows)
            {
                order_builder.Append("<tr>");
                foreach (DataGridViewColumn col in parent.gencasebreakgrid.Columns)
                {
                    if (col.HeaderText.ToUpper() == "ORDER ID")
                        continue;
                    order_builder.Append("<td>");
                    order_builder.Append(row.Cells[col.Name].Value.ToString());
                    order_builder.Append("</td>");
                }

                order_builder.Append("</tr>");
            }

            order_builder.Append("</table>");



            webBrowser1.DocumentText = Properties.Resources.picklist_report
                .Replace("[run_datetime]", DateTime.Now.ToString())
                .Replace("[orders_table]", order_builder.ToString())
                .Replace("[picklist_table]", picklist_builder.ToString())
                ;
        }
    }
}
