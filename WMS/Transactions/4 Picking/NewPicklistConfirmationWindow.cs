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
    public partial class NewPicklistConfirmationWindow : Form
    {
        public NewPicklistWindow parent = null;
        public NewPicklistConfirmationWindow()
        {
            InitializeComponent();
        }

        private void NewPicklistConfirmationWindow_Load(object sender, EventArgs e)
        {
            DataTable pick = new DataTable();
            pick.Columns.Add("Location");
            pick.Columns.Add("Product");
            pick.Columns.Add("desc");
            pick.Columns.Add("Uom");
            pick.Columns.Add("Lot");
            pick.Columns.Add("Expiry",typeof(DateTime));
            pick.Columns.Add("Qty");

            foreach (DataGridViewRow row in parent.picklist_grid.Rows)
            {
                //MessageBox.Show(row.Cells["expiry"].Value.ToString());
                pick.Rows.Add(row.Cells["location"].Value, row.Cells["product"].Value, row.Cells["descp"].Value, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value, row.Cells["qty"].Value);
            }
            DataTable order = new DataTable();
            order.Columns.Add("picklistid");
            order.Columns.Add("client");
            order.Columns.Add("refdoc");
            order.Columns.Add("recipient");
            //order.Columns.Add("picklistbarcode", System.Type.GetType("System.Byte[]"));
            foreach (DataGridViewRow row in parent.order_details_grid.Rows)
                order.Rows.Add("(issue on save)",row.Cells["client"].Value, row.Cells["DOCUMENT REF ID"].Value, row.Cells["RECIPIENT"].Value);

            ReportDocument rviewer = new ReportDocument();
            rviewer = new crtpicklist();
            rviewer.SetDataSource(order);
            rviewer.Subreports[0].SetDataSource(pick);
            viewer.ReportSource = rviewer;
            viewer.RefreshReport();

            //MessageBox.Show("Success");
            //btnPrintPreview.Text = "Print";
            //btnCancel.Text = "Close";

            //StringBuilder picklist_builder = new StringBuilder();

            //DataTable dt = new DataTable();
            //dt.Columns.Add("Location");
            //dt.Columns.Add("Product");
            //dt.Columns.Add("Uom");
            //dt.Columns.Add("Lot no");
            //dt.Columns.Add("Expiry");
            //dt.Columns.Add("Qty");

            //foreach (DataGridViewRow row in parent.picklist_grid.Rows)
            //{
            //    Boolean is_found = false;
            //    foreach (DataRow existing_row in dt.Rows)
            //    {
            //        if (
            //               existing_row["Location"].ToString() == row.Cells["Location"].Value.ToString()
            //            && existing_row["Product"].ToString() == row.Cells["Product"].Value.ToString()
            //            && existing_row["Lot no"].ToString() == row.Cells["lot_no"].Value.ToString()
            //            && existing_row["Uom"].ToString() == row.Cells["uom"].Value.ToString()
            //            && DateTime.Parse( existing_row["Expiry"].ToString()).ToShortDateString() ==  DateTime.Parse( row.Cells["expiry"].Value.ToString()).ToShortDateString()
            //            )
            //        {
            //            existing_row["Qty"] = int.Parse(row.Cells["qty"].Value.ToString()) + int.Parse(existing_row["Qty"].ToString());
            //            is_found = true;
            //            break;
            //        }

            //    }

            //    if (!is_found)
            //    {
            //        dt.Rows.Add(row.Cells["Location"].Value.ToString()
            //            , row.Cells["Product"].Value.ToString()
            //            , row.Cells["uom"].Value.ToString()
            //            , row.Cells["lot_no"].Value.ToString()
            //            , DateTime.Parse( row.Cells["expiry"].Value.ToString()).ToShortDateString()
            //            , row.Cells["qty"].Value.ToString()
            //            );
            //    }
            //}

            //picklist_builder.Append("<table class='table'>");

            //picklist_builder.Append("<thead>");
            //picklist_builder.Append("<tr>");

            //{
            //    foreach (DataColumn col in dt.Columns)
            //    {
            //        picklist_builder.Append("<th>");
            //        picklist_builder.Append(col.ColumnName);
            //        picklist_builder.Append("</th>");
            //    }
            //}

            //picklist_builder.Append("</tr>");
            //picklist_builder.Append("</thead>");

            //foreach (DataRow row in dt.Rows)
            //{
            //    picklist_builder.Append("<tr>");
            //    foreach (DataColumn col in dt.Columns)
            //    {

            //        picklist_builder.Append("<td>");
            //        picklist_builder.Append(row[col].ToString());
            //        picklist_builder.Append("</td>");
            //    }

            //    picklist_builder.Append("</tr>");
            //}

            //picklist_builder.Append("</table>");



            //StringBuilder order_builder = new StringBuilder();
            //order_builder.Append("<table class='table'>");

            //order_builder.Append("<thead>");
            //order_builder.Append("<tr>");

            //{
            //    foreach (DataGridViewColumn col in parent.order_details_grid.Columns)
            //    {
            //        if (col.HeaderText.ToUpper() == "ORDER ID")
            //            continue;
            //        order_builder.Append("<th>");
            //        order_builder.Append(col.HeaderText);
            //        order_builder.Append("</th>");
            //    }
            //}

            //order_builder.Append("</tr>");
            //order_builder.Append("</thead>");

            //foreach (DataGridViewRow row in parent.order_details_grid.Rows)
            //{
            //    order_builder.Append("<tr>");
            //    foreach (DataGridViewColumn col in parent.order_details_grid.Columns)
            //    {
            //        if (col.HeaderText.ToUpper() == "ORDER ID")
            //            continue;
            //        order_builder.Append("<td>");
            //        order_builder.Append(row.Cells[col.Name].Value.ToString());
            //        order_builder.Append("</td>");
            //    }

            //    order_builder.Append("</tr>");
            //}

            //order_builder.Append("</table>");



            //webBrowser1.DocumentText = Properties.Resources.picklist_report
            //    .Replace("[run_datetime]", DateTime.Now.ToString())
            //    .Replace("[orders_table]", order_builder.ToString())
            //    .Replace("[picklist_table]", picklist_builder.ToString())

            //    ;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (btnPrintPreview.Text != "Print")
                SaveData();

            viewer.PrintReport();
        }

        private void SaveData()
        {
            String id = DataSupport.GetNextMenuCodeInt("PL");

            // Save Transaction
            String sql = DataSupport.GetInsert("Picklists", Utils.ToDict(
                "picklist_id", id
               , "status", "TO BE PICKED"
                ));

            foreach (DataGridViewRow row in parent.picklist_grid.Rows)
            {
                sql += DataSupport.GetInsert("PicklistDetails", Utils.ToDict(
                      "picklist", id
                     , "line", parent.picklist_grid.Rows.IndexOf(row) + 1
                     , "order_id", row.Cells["order_id"].Value.ToString()
                     , "product", row.Cells["product"].Value.ToString()
                     , "qty", row.Cells["qty"].Value.ToString()
                     , "uom", row.Cells["uom"].Value.ToString()
                     , "lot_no", row.Cells["lot_no"].Value.ToString()
                     , "expiry", row.Cells["expiry"].Value.ToString()
                     , "location", row.Cells["location"].Value.ToString()
                    ));
            }


            foreach (DataGridViewRow row in parent.picklist_grid.Rows)
            {
                sql += " UPDATE LocationProductsLedger SET to_be_picked_qty = to_be_picked_qty + " + row.Cells["qty"].Value.ToString() + " WHERE location='" + row.Cells["location"].Value.ToString() + "' AND product='" + row.Cells["product"].Value.ToString() + "' AND uom='" + row.Cells["uom"].Value.ToString() + "' AND lot_no='" + row.Cells["lot_no"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "'; ";
            }
            foreach (DataGridViewRow row in parent.picklist_grid.Rows)
            {
                sql += " UPDATE ReleaseOrders SET status='FOR PICKING CONFIRM' WHERE order_id='" + row.Cells["order_id"].Value.ToString() + "'; ";
            }


            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            DataTable pick = new DataTable();
            pick.Columns.Add("Location");
            pick.Columns.Add("Product");
            pick.Columns.Add("desc");
            pick.Columns.Add("Uom");
            pick.Columns.Add("Lot");
            pick.Columns.Add("Expiry", typeof(DateTime));
            pick.Columns.Add("Qty");

            foreach (DataGridViewRow row in parent.picklist_grid.Rows)
            {
                //MessageBox.Show(row.Cells["expiry"].Value.ToString());
                pick.Rows.Add(row.Cells["location"].Value, row.Cells["product"].Value, row.Cells["descp"].Value, row.Cells["uom"].Value, row.Cells["lot_no"].Value, row.Cells["expiry"].Value, row.Cells["qty"].Value);
            }
            DataTable order = new DataTable();
            order.Columns.Add("picklistid");
            order.Columns.Add("client");
            order.Columns.Add("refdoc");
            order.Columns.Add("recipient");
            foreach (DataGridViewRow row in parent.order_details_grid.Rows)
                order.Rows.Add(id, row.Cells["client"].Value, row.Cells["DOCUMENT REF ID"].Value, row.Cells["RECIPIENT"].Value);

            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            barcode.BarWidth = 5;
            DataColumn pickid = new DataColumn("picklistbarcode", System.Type.GetType("System.Byte[]"));
            pickid.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, id), System.Drawing.Imaging.ImageFormat.Jpeg);
            order.Columns.Add(pickid);



            ReportDocument rviewer = new ReportDocument();
            rviewer = new crtpicklist();
            rviewer.SetDataSource(order);
            rviewer.Subreports[0].SetDataSource(pick);
            viewer.ReportSource = rviewer;
            viewer.RefreshReport();
            MessageBox.Show("Success");

            //webBrowser1.DocumentText = webBrowser1.DocumentText.Replace("(issued on save)", id);
            btnPrintPreview.Text = "Print";
            btnCancel.Text = "Close";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewPicklistConfirmationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (btnPrintPreview.Text == "Print")
                this.DialogResult = DialogResult.OK;
        }
    }
}
