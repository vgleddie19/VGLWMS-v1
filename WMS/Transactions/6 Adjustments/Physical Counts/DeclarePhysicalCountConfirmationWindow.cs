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
    public partial class DeclarePhysicalCountConfirmationWindow : Form
    {
        public DeclarePhysicalCountWindow parent = null;

        public DeclarePhysicalCountConfirmationWindow()
        {
            InitializeComponent();
        }

        private void DeclarePhysicalCountConfirmationWindow_Load(object sender, EventArgs e)
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
                    sb.Append(row.Cells[col.Name].Value.ToString());
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");



            webBrowser1.DocumentText = Properties.Resources.declare_physical_count_report
                .Replace("(issued on save)", parent.phcount_id)
                .Replace("[counted_by]", parent.phcount_header_row["counted_by"].ToString())
                .Replace("[cycle]", parent.phcount_header_row["cycle"] + "-" + parent.phcount_header_row["cycle_year"].ToString())
                .Replace("[counted_on]", DateTime.Now.ToString())
                .Replace("[items_grid]", sb.ToString())

                ;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            String now = DateTime.Now.ToString();
            String phcount = parent.phcount_id;

            RollbackDataSupport ds = new RollbackDataSupport();


            // Save to Transaction Tables
            String sql = "";

            sql += " UPDATE PhysicalCounts SET finished_on = '"+now+"' WHERE phcount_id='"+ phcount + "'; ";

            DataTable dt = ds.RunDataSet("SELECT * FROM PhysicalCountDetailItems WHERE phcount='" + phcount + "'").Tables[0];

            foreach (DataGridViewRow item_row in parent.header_grid.Rows)
            {
                if (item_row.Cells["expected"].Value.ToString() == "NO")
                {
                    sql += DataSupport.GetUpsert("PhysicalCountDetails", Utils.ToDict(
                            "phcount", phcount
                           , "location", item_row.Cells["location"].Value.ToString()
                           , "status", "ACTIVE"
                          ), "phcount", "location");

                    sql += DataSupport.GetInsert("PhysicalCountDetailItems", Utils.ToDict(
                            "phcount", phcount
                           , "location", item_row.Cells["location"].Value.ToString()
                           , "product", item_row.Cells["product"].Value.ToString()
                           , "uom", item_row.Cells["uom"].Value.ToString()
                           , "lot_no", item_row.Cells["lot_no"].Value.ToString()
                           , "expiry", item_row.Cells["Expiry"].Value.ToString()
                           , "expected_qty", 0
                           , "actual_qty", item_row.Cells["actual_qty"].Value.ToString()
                           , "line", dt.Rows.Count +1
                          ));

                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        // Skip if expected is empty
                        if (row["product"].ToString() == "EMPTY")
                            continue;

                        if (row["location"].ToString() == item_row.Cells["location"].Value.ToString()
                          && row["product"].ToString() == item_row.Cells["product"].Value.ToString()
                          && row["uom"].ToString() == item_row.Cells["uom"].Value.ToString()
                          && row["lot_no"].ToString() == item_row.Cells["lot_no"].Value.ToString()
                          && DateTime.Parse(row["expiry"].ToString()).ToShortDateString() == item_row.Cells["Expiry"].Value.ToString()
                            )
                        {
                            sql += @"UPDATE PhysicalCountDetailItems SET actual_qty = '" + item_row.Cells["actual_qty"].Value.ToString() + @"'
                                    WHERE phcount = '" + phcount + @"'
                                      AND location = '" + row["location"].ToString() + @"'
                                      AND line = '" + row["line"].ToString() + @"'
                                    ";
                            break;
                        }
                    }
                }
            }

            

           ds.RunNonQuery(sql);

            // Update Ledgers
            String update_sql = "";
            {
                DataTable details_dt = ds.RunDataSet("SELECT * FROM PhysicalCountDetailItems WHERE phcount='" + phcount + "'").Tables[0];
                foreach (DataRow item_row in details_dt.Rows)
                {

                    if (item_row["shortage"].ToString() != "0")
                    {
                        // Update Transaction Ledger
                        {
                            // Out with the location
                            DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
                            outsDT.Rows.Add(item_row["location"].ToString(), now, "OUT", "PHYSICAL_COUNT", phcount);
                            update_sql += LedgerSupport.UpdateLocationLedger(outsDT);
                        }


                        // Update Location Products Ledger
                        {
                            // Out with the location
                            DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();
                            outsDT.Rows.Add(item_row["location"].ToString(), item_row["product"].ToString(), int.Parse(item_row["shortage"].ToString()) * -1, item_row["uom"].ToString(), item_row["lot_no"].ToString(), item_row["expiry"].ToString());
                            update_sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);
                        }

                        // Update For Resolution
                        update_sql += DataSupport.GetInsert("ForResolutions", Utils.ToDict(
                              "trans_source", "PHYSICAL_COUNT"
                            , "trans_id", phcount
                            , "detected_on", now
                            , "product", item_row["product"].ToString()
                            , "uom", item_row["uom"].ToString()
                            , "lot_no", item_row["lot_no"].ToString()
                            , "expiry", item_row["expiry"].ToString()
                            , "location", item_row["location"].ToString()
                            , "variance_type", "SHORTAGE"
                            , "variance_qty", item_row["shortage"].ToString()
                            , "status", "FOR RESOLUTION"
                            , "line", details_dt.Rows.IndexOf(item_row) + 1
                            ));


                    }
                    else if (item_row["overage"].ToString() != "0")
                    {
                        // Update Transaction Ledger
                        {
                            // In with the "found" location
                            DataTable insDT = LedgerSupport.GetLocationLedgerDT();
                            insDT.Rows.Add(item_row["location"].ToString(), now, "IN", "PHYSICAL_COUNT", phcount);
                            update_sql += LedgerSupport.UpdateLocationLedger(insDT);
                        }


                        // Update Location Products Ledger
                        {
                            // In with the "found" location
                            DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();
                            insDT.Rows.Add(item_row["location"].ToString(), item_row["product"].ToString(), item_row["overage"].ToString(), item_row["uom"].ToString(), item_row["lot_no"].ToString(), item_row["expiry"].ToString());
                            update_sql += LedgerSupport.UpdateLocationProductsLedger(insDT);
                        }

                        // Update For Resolution
                        update_sql += DataSupport.GetInsert("ForResolutions", Utils.ToDict(
                              "trans_source", "PHYSICAL_COUNT"
                            , "trans_id", phcount
                            , "detected_on", now
                            , "product", item_row["product"].ToString()
                            , "uom", item_row["uom"].ToString()
                            , "lot_no", item_row["lot_no"].ToString()
                            , "expiry", item_row["expiry"].ToString()
                            , "location", item_row["location"].ToString()
                            , "variance_type", "OVERAGE"
                            , "variance_qty", item_row["overage"].ToString()
                            , "status", "FOR RESOLUTION"
                            , "line", details_dt.Rows.IndexOf(item_row) + 1
                            ));
                    }
                }

            }

            if(update_sql!="")
                ds.RunNonQuery(update_sql);

            ds.CommitData();

           MessageBox.Show("Success");

            //  webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", id);
            btnPrintPreview.Text = "Print";
            btnCancel.Text = "Closed";
        }
    }
}
