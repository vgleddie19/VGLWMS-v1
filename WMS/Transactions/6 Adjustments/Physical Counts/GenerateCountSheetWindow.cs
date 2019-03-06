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
    public partial class GenerateCountSheetWindow : Form
    {


        public NewPhysicalCountWindow parent = null;
        public GenerateCountSheetWindow()
        {
            InitializeComponent();
        }

        DataTable dt = null;
        List<String> locations = null;

        private void GenerateCountSheetWindow_Load(object sender, EventArgs e)
        {
            btnPrintPreview.Select();

             locations = new List<string>();
            foreach (DataGridViewRow row in parent.header_grid.Rows)
                if (Boolean.Parse(row.Cells[0].Value.ToString()) == true)
                    locations.Add("'"+row.Cells[1].Value.ToString()+"'");

            var location_str =  String.Join(",", locations.ToArray());

             dt = DataSupport.RunDataSet(@"SELECT location[Location]
	                                          ,product[Product] 
	                                          ,expiry[Expiry] 
	                                          ,lot_no[Lot No] 
	                                          ,uom[Uom] 
	                                          , ' ' [Actual Qty]
                                              , qty
                                        FROM LocationProductsLedger 
                                        WHERE location IN("+location_str+ ") AND qty >0 ").Tables[0];



            foreach (DataRow row in dt.Rows)
                row["Expiry"] = DateTime.Parse(row["Expiry"].ToString()).ToShortDateString();


            List<String> empty_location = new List<string>();
            foreach (String location in locations)
            {
                Boolean is_found = false;
                foreach (DataRow row in dt.Rows)
                    if (row["Location"].ToString() == location.Replace("'",""))
                        is_found = true;
                if (!is_found)
                    empty_location.Add(location.Replace("'", ""));
            }

            foreach (String location in empty_location)
            {
                dt.Rows.Add(location, "EMPTY");
            }


            StringBuilder sb = new StringBuilder();

            sb.Append("<table class='table'>");

            sb.Append("<thead>");
            sb.Append("<tr>");

            {
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName == "qty")
                        continue;
                    sb.Append("<th>");
                    sb.Append(col.ColumnName);
                    sb.Append("</th>");
                }
            }

            sb.Append("</tr>");
            sb.Append("</thead>");

            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn col in dt.Columns)
                {

                    if (col.ColumnName == "qty")
                        continue;
                    sb.Append("<td>");
                    sb.Append(row[col].ToString());
                    sb.Append("</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");


            webBrowser1.DocumentText = Properties.Resources.physical_count_report
                .Replace("[counted_by]", parent.txtCountedBy.Text)
                .Replace("[cycle]", parent.txtCycle.Value.ToString() + "-" + parent.txtYear.Text)
                .Replace("[run_datetime]", DateTime.Now.ToString())
                .Replace("[items_grid]", sb.ToString())

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
            String id = DataSupport.GetNextMenuCodeInt("PC");

            // Save Transaction
            String sql = DataSupport.GetInsert("PhysicalCounts", Utils.ToDict(
                "phcount_id", id
               , "created_on", DateTime.Now
               , "cycle", parent.txtCycle.Value.ToString()
               , "cycle_year", parent.txtYear.Text
               , "counted_by", parent.txtCountedBy.Text
                ));

            foreach (String location in locations)
            {
                sql += DataSupport.GetInsert("PhysicalCountDetails", Utils.ToDict(
                       "phcount", id
                      , "location", location.Replace("'","")
                     ));
            }

            foreach (DataRow row in dt.Rows)
            {
                sql += DataSupport.GetInsert("PhysicalCountDetailItems", Utils.ToDict(
                     "phcount", id
                    , "location", row["Location"]
                    , "product", row["Product"]
                    , "uom", row["Uom"]
                    , "lot_no", row["Lot No"]
                    , "expiry", row["Expiry"]
                    , "expected_qty", row["qty"]
                    , "line", dt.Rows.IndexOf(row) +1
                   ));

            }


            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");

            webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", id);
            btnPrintPreview.Text = "Print";
            btnCancel.Visible = false;
        }


    }
}
