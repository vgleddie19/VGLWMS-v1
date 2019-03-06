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
    public partial class DeclarePicklistIncompleteConfirmationWindow : Form
    {

        public OrderHoldingWindow parent = null;

        public DeclarePicklistIncompleteConfirmationWindow()
        {
            InitializeComponent();
        }

        private void DeclarePicklistIncompleteConfirmationWindow_Load(object sender, EventArgs e)
        {

            var grandparent = parent.parent;

            btnPrintPreview.Select();

            StringBuilder products_sb = new StringBuilder();
            {
                products_sb.Append("<table class='table'>");

                products_sb.Append("<thead>");
                products_sb.Append("<tr>");

                {
                    foreach (DataGridViewColumn col in parent.products_grid.Columns)
                    {
                        products_sb.Append("<th>");
                        products_sb.Append(col.HeaderText);
                        products_sb.Append("</th>");
                    }
                }

                products_sb.Append("</tr>");
                products_sb.Append("</thead>");

                foreach (DataGridViewRow row in parent.products_grid.Rows)
                {
                    products_sb.Append("<tr>");
                    foreach (DataGridViewColumn col in parent.products_grid.Columns)
                    {
                        products_sb.Append("<td>");
                        products_sb.Append(row.Cells[col.Name].Value.ToString());
                        products_sb.Append("</td>");
                    }

                    products_sb.Append("</tr>");
                }

                products_sb.Append("</table>");
            }


            StringBuilder bad_stocks_sb = new StringBuilder();
            {
                bad_stocks_sb.Append("<table class='table'>");

                bad_stocks_sb.Append("<thead>");
                bad_stocks_sb.Append("<tr>");

                {
                    foreach (DataColumn col in parent.BadStockDT.Columns)
                    {
                        bad_stocks_sb.Append("<th>");
                        bad_stocks_sb.Append(col.ColumnName);
                        bad_stocks_sb.Append("</th>");
                    }
                }

                bad_stocks_sb.Append("</tr>");
                bad_stocks_sb.Append("</thead>");

                foreach (DataRow row in parent.BadStockDT.Rows)
                {
                    bad_stocks_sb.Append("<tr>");
                    foreach (DataColumn col in parent.BadStockDT.Columns)
                    {
                        bad_stocks_sb.Append("<td>");
                        bad_stocks_sb.Append(row[col.ColumnName].ToString());
                        bad_stocks_sb.Append("</td>");
                    }

                    bad_stocks_sb.Append("</tr>");
                }

                bad_stocks_sb.Append("</table>");
            }



            StringBuilder picklist_sb = new StringBuilder();
            {
                picklist_sb.Append("<table class='table'>");

                picklist_sb.Append("<thead>");
                picklist_sb.Append("<tr>");

                {
                    foreach (DataGridViewColumn col in grandparent.scanned_grid.Columns)
                    {
                        picklist_sb.Append("<th>");
                        picklist_sb.Append(col.HeaderText);
                        picklist_sb.Append("</th>");
                    }
                }

                picklist_sb.Append("</tr>");
                picklist_sb.Append("</thead>");

                foreach (DataGridViewRow row in grandparent.scanned_grid.Rows)
                {
                    picklist_sb.Append("<tr>");
                    foreach (DataGridViewColumn col in grandparent.scanned_grid.Columns)
                    {
                        picklist_sb.Append("<td>");
                        picklist_sb.Append(row.Cells[col.Name].Value.ToString());
                        picklist_sb.Append("</td>");
                    }

                    picklist_sb.Append("</tr>");
                }

                picklist_sb.Append("</table>");
            }



            StringBuilder orders_sb = new StringBuilder();
            DataTable mergedDT = GetMergedOrders();

            {
                orders_sb.Append("<table class='table'>");

                orders_sb.Append("<thead>");
                orders_sb.Append("<tr>");

                {
                    foreach (DataColumn col in mergedDT.Columns)
                    {
                        orders_sb.Append("<th>");
                        orders_sb.Append(col.ColumnName);
                        orders_sb.Append("</th>");
                    }
                }

                orders_sb.Append("</tr>");
                orders_sb.Append("</thead>");

                foreach (DataRow row in mergedDT.Rows)
                {
                    orders_sb.Append("<tr>");
                    foreach (DataColumn col in mergedDT.Columns)
                    {
                        orders_sb.Append("<td>");
                        orders_sb.Append(row[col.ColumnName].ToString());
                        orders_sb.Append("</td>");
                    }

                    orders_sb.Append("</tr>");
                }

                orders_sb.Append("</table>");
            }








            webBrowser1.DocumentText = Properties.Resources.incomplete_picklist_report
                .Replace("[run_datetime]", DateTime.Now.ToString())
                .Replace("[products_table]", products_sb.ToString())
                .Replace("[bad_stocks_table]", bad_stocks_sb.ToString())
                .Replace("[picklist_table]", picklist_sb.ToString())
                .Replace("[orders_table]", orders_sb.ToString())
                ;
        }

        private DataTable GetMergedOrders()
        {
            DataTable result = new DataTable();
            

            result.Columns.Add("Order ID");
            result.Columns.Add("Total Invoice Amount");
            result.Columns.Add("Client");
            result.Columns.Add("Customer");
            result.Columns.Add("Qty Ordered");
            result.Columns.Add("Status");


            foreach (String key in parent.orders_dict.Keys.ToList())
            {
                DataTable dt = parent.orders_dict[key];
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
                    if(!is_existing)
                        result.Rows.Add(row.ItemArray);
                }
            }



            return result;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
