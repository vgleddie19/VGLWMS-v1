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
    public partial class NewCaseBreakConfirm : Form
    {
        public NewCaseBreakWindow parent = null;
        public NewCaseBreakConfirm()
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
            String id = DataSupport.GetNextMenuCodeInt("CBPL");

            // Save Transaction
            String sql = DataSupport.GetInsert("CaseBreak", Utils.ToDict(
                "casebreak_id", id
                , "approved_on", parent.txtReceivedOn.Value.ToShortDateString()
                , "encoded_on", DateTime.Now
                , "approved_by", parent.cboReceivedBy .SelectedValue
               , "status", "TO BE PICKED"
                ));

            foreach (DataGridViewRow row in parent.picklist_grid.Rows)
            {
                sql += DataSupport.GetInsert("CaseBreakDetails", Utils.ToDict(
                      "casebreak", id
                     , "line", parent.picklist_grid.Rows.IndexOf(row) + 1
                     , "product", row.Cells["product"].Value.ToString()
                     , "qty", row.Cells["qty"].Value.ToString()
                     , "uom", row.Cells["uom"].Value.ToString()
                     , "lot_no", row.Cells["lot_no"].Value.ToString()
                     , "expiry", row.Cells["expiry"].Value.ToString()
                     , "location", row.Cells["location"].Value.ToString()
                     , "breakto_uom", row.Cells["breakto_uom"].Value.ToString()
                    ));
            }

            foreach (DataGridViewRow row in parent.picklist_grid.Rows)
            {
                sql += " UPDATE LocationProductsLedger SET [reserved_qty] = [reserved_qty] + "+ row.Cells["qty"].Value.ToString() + ", to_be_picked_qty =  to_be_picked_qty + " + row.Cells["qty"].Value.ToString() + "  WHERE location='" + row.Cells["location"].Value.ToString() + "' AND product='" + row.Cells["product"].Value.ToString() + "' AND uom='" + row.Cells["uom"].Value.ToString() + "' AND lot_no='" + row.Cells["lot_no"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "'; ";
            }


            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");

            webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", id);
            btnPrintPreview.Text = "Print";
            btnCancel.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void NewBreakCaseConfirm_Load(object sender, EventArgs e)
        {
            StringBuilder picklist_builder = new StringBuilder();

            DataTable dt = new DataTable();
            dt.Columns.Add("Location");
            dt.Columns.Add("Product");
            dt.Columns.Add("Uom");
            dt.Columns.Add("Lot no");
            dt.Columns.Add("Expiry");
            dt.Columns.Add("Qty");

            foreach (DataGridViewRow row in parent.picklist_grid.Rows)
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

                if (!is_found)
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
                foreach (DataGridViewColumn col in parent.grid.Columns)
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

            foreach (DataGridViewRow row in parent.grid.Rows)
            {
                if (row.Index == parent.grid.RowCount - 1)
                    break;
                order_builder.Append("<tr>");
                foreach (DataGridViewColumn col in parent.grid.Columns)
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
                .Replace("[approved_from]", parent.cboReceivedBy.SelectedValue.ToString())
                .Replace("[approved_on]", DateTime.Now.ToString())
                .Replace("[orders_table]", order_builder.ToString())
                .Replace("[casebreak_table]", picklist_builder.ToString())
                ;
        }
    }
}
