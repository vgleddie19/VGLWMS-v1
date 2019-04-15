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
            dt.Columns.Add("Uom");
            dt.Columns.Add("Lot no");
            dt.Columns.Add("Expiry");
            dt.Columns.Add("Qty");
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

                webBrowser1.DocumentText = Properties.Resources.case_break_picklist
                    .Replace("[run_datetime]", DateTime.Now.ToString())
                    .Replace("[casebreak_table]", picklist_builder.ToString())
                    ;
            }
            //Casebreak
            {
                picklist_builder = new StringBuilder();

                dt = new DataTable();
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

                webBrowser2.DocumentText = Properties.Resources.case_break_report
                    .Replace("[run_datetime]", DateTime.Now.ToString())
                    .Replace("[casebreak_table]", picklist_builder.ToString())
                    ;
            }
            //Put Away
            {
                picklist_builder = new StringBuilder();

                dt = new DataTable();
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

                webBrowser3.DocumentText = Properties.Resources.case_break_putaway
                    .Replace("[run_datetime]", DateTime.Now.ToString())
                    .Replace("[casebreak_table]", picklist_builder.ToString())
                    ;
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (btnPrintPreview.Text != "Print")
            {
                ids = new string[3];
                SavePicklistData();
                SaveCaseBreakData();
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
                     , "order_id", row.Cells["binid"].Value.ToString()
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

            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");

            webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", id);
            webBrowser2.DocumentText = webBrowser2.DocumentText.Replace("(issued on save picklist)", id);
            webBrowser3.DocumentText = webBrowser3.DocumentText.Replace("(issued on save picklist)", ids[1]);

            btnPrintPreview.Text = "Print";
            btnCancel.Visible = false;
        }

        private void SaveCaseBreakData()
        {
            String id = DataSupport.GetNextMenuCodeInt("CBPL");
            ids[1] = id;
            // Save Transaction
            String sql = DataSupport.GetInsert("CaseBreak", Utils.ToDict(
                "casebreak_id", id
                , "picklist_id", ids[0]
                , "approved_on", DateTime.Now.ToShortDateString()
                , "encoded_on", DateTime.Now
                , "approved_by", ""
               , "status", "TO BE PICKED"
                ));

            foreach (DataGridViewRow row in parent.gencasebreakgrid.Rows)
            {
                sql += DataSupport.GetInsert("CaseBreakDetails", Utils.ToDict(
                      "casebreak", id
                     , "line", parent.gencasebreakgrid.Rows.IndexOf(row) + 1
                     , "product", row.Cells["product"].Value.ToString()
                     , "qty", row.Cells["qty"].Value.ToString()
                     , "uom", row.Cells["uom"].Value.ToString()
                     , "lot_no", row.Cells["lot_no"].Value.ToString()
                     , "expiry", row.Cells["expiry"].Value.ToString()
                     , "location", row.Cells["location"].Value.ToString()
                     , "breakto_uom", row.Cells["breakto_uom"].Value.ToString()
                    ));
            }

            sql += " UPDATE Picklists SET casebreak_id = '" + ids[1]  + "' WHERE picklist_id ='" + ids[0] + "'; ";

            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");

            webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save casebreak)", ids[1]);
            webBrowser2.DocumentText = webBrowser2.DocumentText.Replace("(issued on save)", id);
            webBrowser3.DocumentText = webBrowser3.DocumentText.Replace("(issued on save casebreak)", ids[1]);
            btnPrintPreview.Text = "Print";
            btnCancel.Visible = false;

        }

        private void SavePutAwayData()
        {
            //String putaway_id = DataSupport.GetNextMenuCodeInt("PA");
            //ids[2] = putaway_id;
            //DateTime now = DateTime.Now;

            //// Save Transaction
            //String sql = DataSupport.GetInsert("Putaways", Utils.ToDict(
            //    "putaway_id", putaway_id
            //   , "container", "CEB1-BIN"
            //   , "encoded_on", now
            //    ));

            //foreach (DataGridViewRow row in parent.headerGrid.Rows)
            //{
            //    sql += DataSupport.GetInsert("PutawayDetails", Utils.ToDict(
            //          "putaway", putaway_id
            //         , "product", row.Cells["product"].Value.ToString()
            //         , "expected_qty", row.Cells["Quantity"].Value.ToString()
            //         , "uom", row.Cells["uom"].Value.ToString()
            //         , "lot_no", row.Cells["lot"].Value.ToString()
            //         , "expiry", row.Cells["expiry"].Value.ToString()
            //         , "location", row.Cells["location"].Value.ToString()
            //        ));
            //}


            //// Update Transaction Ledger
            //{
            //    // Out with the staging in
            //    DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
            //    outsDT.Rows.Add("STAGING-IN", now, "OUT", "PUTAWAY", putaway_id);

            //    sql += LedgerSupport.UpdateLocationLedger(outsDT);


            //    // In with the container
            //    DataTable insDT = LedgerSupport.GetLocationLedgerDT();
            //    foreach (DataGridViewRow row in parent.headerGrid.Rows)
            //        insDT.Rows.Add(parent.cboContainer.SelectedValue.ToStringNull(), now, "IN", "PUTAWAY", putaway_id);
            //    sql += LedgerSupport.UpdateLocationLedger(insDT);

            //}

            //// Update Location Products Ledger
            //{
            //    // Out with the staging in
            //    DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();

            //    foreach (DataGridViewRow row in parent.headerGrid.Rows)
            //        outsDT.Rows.Add("STAGING-IN", row.Cells["product"].Value, int.Parse(row.Cells["Quantity"].Value.ToString()) * -1, row.Cells["uom"].Value, row.Cells["lot"].Value, row.Cells["expiry"].Value);
            //    sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);


            //    // In with the container
            //    DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

            //    foreach (DataGridViewRow row in parent.headerGrid.Rows)
            //        insDT.Rows.Add(parent.cboContainer.SelectedValue.ToStringNull(), row.Cells["product"].Value, row.Cells["Quantity"].Value, row.Cells["uom"].Value, row.Cells["lot"].Value, row.Cells["expiry"].Value);
            //    sql += LedgerSupport.UpdateLocationProductsLedger(insDT);

            //}

            //try
            //{
            //    DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);

            //    MessageBox.Show("Success");

            //    webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", putaway_id);
            //    btnPrintPreview.Text = "Print";
            //    btnCancel.Visible = false;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
