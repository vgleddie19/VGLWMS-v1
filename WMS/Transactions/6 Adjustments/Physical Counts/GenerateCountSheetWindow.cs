using CrystalDecisions.CrystalReports.Engine;
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

             dt = DataSupport.RunDataSet(@"SELECT '(issued on save)'[pcid]
	                                          ,l.product
                                              ,p.description[desc]
                                              ,0
                                              ,l.uom
                                              ,lot_no[lot]
	                                          ,expiry 
                                              ,location
                                              ,qty[expected_qty]
                                        FROM LocationProductsLedger l join products p on l.product = p.product_id
                                        WHERE location IN(" + location_str+ ") AND qty >0 ").Tables[0];

            foreach (DataRow row in dt.Rows)
                row["Expiry"] = DateTime.Parse(row["Expiry"].ToString()).ToShortDateString();


            List<String> empty_location = new List<string>();
            foreach (String location in locations)
            {
                Boolean is_found = false;
                foreach (DataRow row in dt.Rows)
                    if (row["Location"].ToString() == location.Replace("'", ""))
                        is_found = true;
                if (!is_found)
                    empty_location.Add(location.Replace("'", ""));
            }

            foreach (String location in empty_location)
            {
                dt.Rows.Add("(issued on save)", null,"EMPTY",null,null,null,null,location,null);
            }

            ReportDocument rviewer = new ReportDocument();
            rviewer = new crtphysicalcount();
            rviewer.SetDataSource(dt);
            if (parent.txtCountedBy.Text.Trim().Length >= 1)
                rviewer.SetParameterValue("performby", parent.txtCountedBy.Text);
            else
                rviewer.SetParameterValue("performby", " ");
            viewer.ReportSource = rviewer;
            viewer.Zoom(110);



            //StringBuilder sb = new StringBuilder();

            //sb.Append("<table class='table'>");

            //sb.Append("<thead>");
            //sb.Append("<tr>");

            //{
            //    foreach (DataColumn col in dt.Columns)
            //    {
            //        if (col.ColumnName == "qty")
            //            continue;
            //        sb.Append("<th>");
            //        sb.Append(col.ColumnName);
            //        sb.Append("</th>");
            //    }
            //}

            //sb.Append("</tr>");
            //sb.Append("</thead>");

            //foreach (DataRow row in dt.Rows)
            //{
            //    sb.Append("<tr>");
            //    foreach (DataColumn col in dt.Columns)
            //    {
            //        if (col.ColumnName == "qty")
            //            continue;
            //        sb.Append("<td>");
            //        sb.Append(row[col].ToString());
            //        sb.Append("</td>");
            //    }
            //    sb.Append("</tr>");
            //}
            //sb.Append("</table>");
            //webBrowser1.DocumentText = Properties.Resources.physical_count_report
            //    .Replace("[counted_by]", parent.txtCountedBy.Text)
            //    .Replace("[cycle]", parent.txtCycle.Value.ToString() + "-" + parent.txtYear.Text)
            //    .Replace("[run_datetime]", DateTime.Now.ToString())
            //    .Replace("[items_grid]", sb.ToString())
            //    ;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (btnPrintPreview.Text != "Print")
                SaveData();
            else
            {
                viewer.PrintReport();
                //webBrowser1.ShowPrintPreviewDialog();
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
                        , "lot_no", row["Lot"]
                        , "expiry", row["Expiry"]
                        , "expected_qty", row["expected_qty"]
                        , "line", dt.Rows.IndexOf(row) + 1
                       ));
            }


            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");

            foreach (DataRow row in dt.Rows)
            {
                if(row["Expiry"] != DBNull.Value)
                    row["Expiry"] = DateTime.Parse(row["Expiry"].ToString()).ToShortDateString();
            }

            List<String> empty_location = new List<string>();
            foreach (String location in locations)
            {
                Boolean is_found = false;
                foreach (DataRow row in dt.Rows)
                    if (row["Location"].ToString() == location.Replace("'", ""))
                        is_found = true;
                if (!is_found)
                    empty_location.Add(location.Replace("'", ""));
            }

            foreach (String location in empty_location)
            {
                dt.Rows.Add("(issued on save)", null, "EMPTY", null, null, null, null, location, null);
            }

            //dt.Columns.Add("putawayid");
            //dt.Columns.Add("containerid");
            //dt.Columns.Add("product");
            //dt.Columns.Add("desc");
            //dt.Columns.Add("qty");
            //dt.Columns.Add("uom");
            //dt.Columns.Add("lot");
            //dt.Columns.Add("expiry");
            //dt.Columns.Add("location");
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            DataColumn bar = new DataColumn("putawaybarcode", System.Type.GetType("System.Byte[]"));
            bar.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, id), System.Drawing.Imaging.ImageFormat.Jpeg);
            dt.Columns.Add(bar);
            dt.Columns.Remove("pcid");
            DataColumn dc = new DataColumn("pcid");
            dc.DefaultValue = id;
            dt.Columns.Add(dc);


            ReportDocument rviewer = new ReportDocument();
            rviewer = new crtphysicalcount();
            rviewer.SetDataSource(dt);
            if (parent.txtCountedBy.Text.Trim().Length >= 1)
                rviewer.SetParameterValue("performby", parent.txtCountedBy.Text);
            else
                rviewer.SetParameterValue("performby", " ");
            viewer.ReportSource = rviewer;

            //webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", id);
            btnPrintPreview.Text = "Print";
            btnCancel.Text = "Close";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
