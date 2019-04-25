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
        public String[] ids = null;
        public CaseBreakPickListConfirmation()
        {
            InitializeComponent();
        }

        private void CaseBreakPickListConfirmation_Load(object sender, EventArgs e)
        {
            //picklist

            StringBuilder picklist_builder = new StringBuilder();

            DataTable dt = new DataTable();
            dt.Columns.Add("Location");
            dt.Columns.Add("Product");
            dt.Columns.Add("Description");
            dt.Columns.Add("Qty1");
            dt.Columns.Add("Uom1");
            dt.Columns.Add("Lot no");
            dt.Columns.Add("Expiry");
            if (parent.genpickgrid.Rows.Count >= 1)
            {
                foreach (DataGridViewRow row in parent.genpickgrid.Rows)
                {
                    Boolean is_found = false;
                    foreach (DataRow existing_row in dt.Rows)
                    {
                        if (
                               existing_row["Location"].ToString() == row.Cells["gridcolloc"].Value.ToString()
                            && existing_row["Product"].ToString() == row.Cells["gridcolprod"].Value.ToString()
                            && existing_row["Lot no"].ToString() == row.Cells["gridcollot"].Value.ToString()
                            && existing_row["Uom1"].ToString() == row.Cells["gridcoluom"].Value.ToString()
                            && DateTime.Parse(existing_row["Expiry"].ToString()).ToShortDateString() == DateTime.Parse(row.Cells["gridcolexpiry"].Value.ToString()).ToShortDateString()
                            )
                        {
                            existing_row["Qty1"] = int.Parse(row.Cells["gridcolqty"].Value.ToString()) + int.Parse(existing_row["Qty1"].ToString());
                            is_found = true;
                            break;
                        }
                    }
                    if (!is_found)
                    {
                        dt.Rows.Add(row.Cells["gridcolloc"].Value.ToString()
                                    , row.Cells["gridcolprod"].Value.ToString()
                                    , row.Cells["gridcoldesc"].Value.ToString()
                                    , row.Cells["gridcolqty"].Value.ToString()
                                    , row.Cells["gridcoluom"].Value.ToString()
                                    , row.Cells["gridcollot"].Value.ToString()
                                    , DateTime.Parse(row.Cells["gridcolexpiry"].Value.ToString()).ToShortDateString()
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

                webBrowser1.DocumentText = Properties.Resources.case_break_picklist
                    .Replace("[run_datetime]", DateTime.Now.ToString())
                    .Replace("[casebreak_table]", picklist_builder.ToString())
                    ;
            }
            //Casebreak
            if (parent.gencasebreakgrid.Rows.Count >= 1)
            {               
                picklist_builder = new StringBuilder();

                dt = new DataTable();
                dt.Columns.Add("Product");
                dt.Columns.Add("Description");
                dt.Columns.Add("Qty1");
                dt.Columns.Add("Uom1");
                dt.Columns.Add("Qty2");
                dt.Columns.Add("Uom2");
                dt.Columns.Add("Lot no");
                dt.Columns.Add("Expiry");
                foreach (DataGridViewRow row in parent.gencasebreakgrid.Rows)
                {
                    dt.Rows.Add(row.Cells["gridcolcasebreak_prod"].Value.ToString()
                                , row.Cells["gridcolcasebreak_desc"].Value.ToString()
                                , row.Cells["gridcolcasebreak_locqty"].Value.ToString()
                                , row.Cells["gridcolcasebreak_locuom"].Value.ToString()
                                , row.Cells["gridcolcasebreak_binqty"].Value.ToString()
                                , row.Cells["gridcolcasebreak_binuom"].Value.ToString()
                                , row.Cells["gridcolcasebreak_lot"].Value.ToString()
                                , DateTime.Parse(row.Cells["gridcolcasebreak_expiry"].Value.ToString()).ToShortDateString()
                                );
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

                webBrowser2.DocumentText = Properties.Resources.case_break_report
                    .Replace("[run_datetime]", DateTime.Now.ToString())
                    .Replace("[casebreak_table]", picklist_builder.ToString())
                    ;
            }
            //Put Away
            if (parent.putawaygrid.Rows.Count >= 1)
            {
                picklist_builder = new StringBuilder();

                dt = new DataTable();
                dt.Columns.Add("Product");
                dt.Columns.Add("Description");
                dt.Columns.Add("Qty2");
                dt.Columns.Add("Uom2");
                dt.Columns.Add("Lot no");
                dt.Columns.Add("Expiry");
                dt.Columns.Add("Location/Bin");
                foreach (DataGridViewRow row in parent.putawaygrid.Rows)
                {
                    dt.Rows.Add(row.Cells["gridcolputaway_prod"].Value.ToString()
                                          , row.Cells["gridcolputaway_desc"].Value.ToString()
                                          , row.Cells["gridcolputaway_qty"].Value.ToString()
                                          , row.Cells["gridcolputaway_binuom"].Value.ToString()
                                          , row.Cells["gridcolputaway_lot"].Value.ToString()
                                          , DateTime.Parse(row.Cells["gridcolputaway_expiry"].Value.ToString()).ToShortDateString()
                                          , row.Cells["gridcolputaway_bin"].Value.ToString()
                                          );

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

                webBrowser3.DocumentText = Properties.Resources.case_break_putaway
                    .Replace("[run_datetime]", DateTime.Now.ToString())
                    .Replace("[casebreak_table]", picklist_builder.ToString())
                    ;
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (parent.putawaygrid.Rows.Count >= 1 || parent.gencasebreakgrid.Rows.Count >= 1 ||
                parent.genpickgrid.Rows.Count >= 1)
            {
                if (btnPrintPreview.Text != "Print")
                {
                    StringBuilder sql = new StringBuilder();
                    ids = new string[3];
                    sql.Append(SavePicklistData());
                    sql.Append(SaveCaseBreakData());
                    sql.Append(SavePutAwayData());
                    sql.Append(String.Format("UPDATE Picklists SET casebreak_id = '{0}', putaway_id = '{1}' WHERE picklist_id ='{2}';", ids[1], ids[2], ids[0]));
                    sql.Append(String.Format("UPDATE casebreak SET putaway_id = '{0}', picklist_id = '{1}' WHERE casebreak_id ='{2}';", ids[2], ids[0], ids[1]));
                    sql.Append(String.Format("UPDATE putaways SET casebreak_id = '{0}', picklist_id = '{1}' WHERE putaway_id ='{2}';", ids[1], ids[0], ids[2]));
                    try
                    {
                        DataSupport.RunNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);

                        MessageBox.Show("Success");
                        webBrowser1.DocumentText = webBrowser1.DocumentText
                                                  .Replace("(issued on save bin putaway)", ids[2])
                                                  .Replace("(issued on save casebreak)", ids[1])
                                                  .Replace("(issued on save)", ids[0]);

                        webBrowser2.DocumentText = webBrowser2.DocumentText
                                                  .Replace("(issued on save bin putaway)", ids[2])
                                                  .Replace("(issued on save picklist)", ids[0])
                                                  .Replace("(issued on save)", ids[1]);

                        webBrowser3.DocumentText = webBrowser3.DocumentText
                                                  .Replace("(issued on save bin picklist)", ids[0])
                                                  .Replace("(issued on save casebreak)", ids[1])
                                                  .Replace("(issued on save)", ids[2]);

                        btnPrintPreview.Text = "Print";
                        btnCancel.Text = "Closed";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    webBrowser1.Print();
                    webBrowser2.Print();
                    webBrowser3.Print();
                }
            }
        }

        private String SavePicklistData()
        {
            String id = DataSupport.GetNextMenuCodeInt("PL");
            ids[0] = id;
            // Save Transaction
            String sql = DataSupport.GetInsert("Picklists", Utils.ToDict(
                "picklist_id", id
               , "status", "TO BE PICKED"
                ));

            foreach (DataGridViewRow row in parent.genpickgrid.Rows)
            {
                sql += DataSupport.GetInsert("PicklistDetails", Utils.ToDict(
                      "picklist", id
                     , "line", parent.genpickgrid.Rows.IndexOf(row) + 1
                     , "order_id", "0"
                     , "product", row.Cells["gridcolprod"].Value.ToString()
                     , "qty", row.Cells["gridcolqty"].Value.ToString()
                     , "uom", row.Cells["gridcoluom"].Value.ToString()
                     , "lot_no", row.Cells["gridcollot"].Value.ToString()
                     , "expiry", row.Cells["gridcolexpiry"].Value.ToString()
                     , "location", row.Cells["gridcolloc"].Value.ToString()
                    ));
            }

            foreach (DataGridViewRow row in parent.genpickgrid.Rows)
            {
                sql += " UPDATE LocationProductsLedger SET to_be_picked_qty = to_be_picked_qty + " + row.Cells["gridcolqty"].Value.ToString() + ", [reserved_qty] = [reserved_qty] + " + row.Cells["gridcolqty"].Value.ToString() + " WHERE location='" + row.Cells["gridcolloc"].Value.ToString() + "' AND product='" + row.Cells["gridcolprod"].Value.ToString() + "' AND uom='" + row.Cells["gridcoluom"].Value.ToString() + "' AND lot_no='" + row.Cells["gridcollot"].Value.ToString() + "' AND expiry='" + row.Cells["gridcolexpiry"].Value.ToString() + "'; ";
            }
            return sql;
        }

        private string SaveCaseBreakData()
        {
            String id = DataSupport.GetNextMenuCodeInt("CBPL");
            ids[1] = id;
            // Save Transaction
            String sql = DataSupport.GetInsert("CaseBreak", Utils.ToDict(
                "casebreak_id", id
                , "approved_on", DateTime.Now.ToShortDateString()
                , "encoded_on", DateTime.Now
                , "approved_by", RegistrationSupport.username
               , "status", "TO BE PICKED"
                ));

            foreach (DataGridViewRow row in parent.gencasebreakgrid.Rows)
            {
                sql += DataSupport.GetInsert("CaseBreakDetails", Utils.ToDict(
                      "casebreak", id
                     , "line", parent.gencasebreakgrid.Rows.IndexOf(row) + 1
                     , "product", row.Cells["gridcolcasebreak_prod"].Value.ToString()
                     , "qty", row.Cells["gridcolcasebreak_locqty"].Value.ToString()
                     , "uom", row.Cells["gridcolcasebreak_locuom"].Value.ToString()
                     , "lot_no", row.Cells["gridcolcasebreak_lot"].Value.ToString()
                     , "expiry", row.Cells["gridcolcasebreak_expiry"].Value.ToString()
                     , "location", "STOCKS-P2"
                     , "breakto_uom", row.Cells["gridcolcasebreak_binuom"].Value.ToString()
                     , "expected_qty", row.Cells["gridcolcasebreak_binqty"].Value.ToString()
                    ));
            }            
            return sql;
        }

        private string SavePutAwayData()
        {
            String putaway_id = DataSupport.GetNextMenuCodeInt("PA");
            ids[2] = putaway_id;
            DateTime now = DateTime.Now;

            // Save Transaction
            String sql = DataSupport.GetInsert("Putaways", Utils.ToDict(
                "putaway_id", putaway_id
               , "container", "CEB1-BIN"
               , "encoded_on", now
                ));

            foreach (DataGridViewRow row in parent.putawaygrid.Rows)
            {
                sql += DataSupport.GetInsert("PutawayDetails", Utils.ToDict(
                      "putaway", putaway_id
                     , "product", row.Cells["gridcolputaway_prod"].Value.ToString()
                     , "expected_qty", row.Cells["gridcolputaway_qty"].Value.ToString()
                     , "uom", row.Cells["gridcolputaway_binuom"].Value.ToString()
                     , "lot_no", row.Cells["gridcolputaway_lot"].Value.ToString()
                     , "expiry", row.Cells["gridcolputaway_expiry"].Value.ToString()
                     , "location", row.Cells["gridcolputaway_bin"].Value.ToString()
                    ));
            }

            return sql;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
