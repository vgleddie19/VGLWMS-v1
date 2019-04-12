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
    public partial class CaseBreakPickListConfirmation : Form
    {
        public BinReplishmentWindow parent = null;
        public string reportname = null;
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
                           existing_row["Location"].ToString() == row.Cells["gridcolloc"].Value.ToString()
                        && existing_row["Product"].ToString() == row.Cells["gridcolprod"].Value.ToString()
                        && existing_row["Lot no"].ToString() == row.Cells["gridcollot"].Value.ToString()
                        && existing_row["Uom"].ToString() == row.Cells["gridcoluom"].Value.ToString()
                        && DateTime.Parse(existing_row["Expiry"].ToString()).ToShortDateString() == DateTime.Parse(row.Cells["gridcolexpiry"].Value.ToString()).ToShortDateString()
                        )
                    {
                        existing_row["Qty"] = int.Parse(row.Cells["gridcolqty"].Value.ToString()) + int.Parse(existing_row["Qty"].ToString());
                        is_found = true;
                        break;
                    }

                }
                if (!is_found)
                {
                    dt.Rows.Add(row.Cells["gridcolloc"].Value.ToString()
                                , row.Cells["gridcolprod"].Value.ToString()
                                , row.Cells["gridcoluom"].Value.ToString()
                                , row.Cells["gridcollot"].Value.ToString()
                                , DateTime.Parse(row.Cells["gridcolexpiry"].Value.ToString()).ToShortDateString()
                                , row.Cells["gridcolqty"].Value.ToString()
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



            webBrowser1.DocumentText = Properties.Resources.case_break_report
                .Replace("[run_datetime]", DateTime.Now.ToString())
                .Replace("[orders_table]", order_builder.ToString())
                .Replace("[casebreak_table]", picklist_builder.ToString())
                ;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (btnPrintPreview.Text != "Print")
            {
                if(reportname == "picklist")
                    SavePicklistData();
                else if(reportname == "casebreak")
                    SaveCaseBreakData();
                else if (reportname == "putaway")
                    SavePutAwayData();
            }
            else
            {
                webBrowser1.ShowPrintPreviewDialog();
            }
        }

        private void SavePicklistData()
        {
            String id = DataSupport.GetNextMenuCodeInt("PL");


            // Save Transaction
            String sql = DataSupport.GetInsert("Picklists", Utils.ToDict(
                "picklist_id", id
               , "status", "TO BE PICKED"
                ));

            foreach (DataGridViewRow row in parent.genpickgrid.Rows)
            {
                sql += DataSupport.GetInsert("CaseBreakDetails", Utils.ToDict(
                      "picklist", id
                     , "line", parent.genpickgrid.Rows.IndexOf(row) + 1
                     , "order_id", row.Cells["order_id"].Value.ToString()
                     , "product", row.Cells["product"].Value.ToString()
                     , "qty", row.Cells["qty"].Value.ToString()
                     , "uom", row.Cells["uom"].Value.ToString()
                     , "lot_no", row.Cells["lot_no"].Value.ToString()
                     , "expiry", row.Cells["expiry"].Value.ToString()
                     , "location", row.Cells["location"].Value.ToString()
                    ));
            }

            foreach (DataGridViewRow row in parent.genpickgrid.Rows)
            {
                sql += " UPDATE LocationProductsLedger SET to_be_picked_qty = to_be_picked_qty + " + row.Cells["qty"].Value.ToString() + " WHERE location='" + row.Cells["location"].Value.ToString() + "' AND product='" + row.Cells["product"].Value.ToString() + "' AND uom='" + row.Cells["uom"].Value.ToString() + "' AND lot_no='" + row.Cells["lot_no"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "'; ";
            }
            foreach (DataGridViewRow row in parent.genpickgrid.Rows)
            {
                sql += " UPDATE ReleaseOrders SET status='FOR PICKING' WHERE order_id='" + row.Cells["order_id"].Value.ToString() + "'; ";
            }

            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");

            webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", id);
            btnPrintPreview.Text = "Print";
            btnCancel.Visible = false;
        }

        private void SaveCaseBreakData()
        {

        }

        private void SavePutAwayData()
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
