using CrystalDecisions.CrystalReports.Engine;
using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS
{
    public partial class NewPutawayConfirmationWindow : Form
    {
        public NewPutawayWindow parent = null;

        public NewPutawayConfirmationWindow()
        {
            InitializeComponent();
        }

        private void NewPutawayConfirmationWindow_Load(object sender, EventArgs e)
        {
            btnPrintPreview.Select();           
            DataTable dt = new DataTable();
            dt.Columns.Add("putawayid");
            dt.Columns.Add("containerid");
            dt.Columns.Add("product");
            dt.Columns.Add("desc");
            dt.Columns.Add("qty");
            dt.Columns.Add("uom");
            dt.Columns.Add("lot");
            dt.Columns.Add("expiry");
            dt.Columns.Add("location");
            foreach (DataGridViewRow row in parent.headerGrid.Rows)
            {

                dt.Rows.Add("(issued on save)", "(issued on save)"
                    , row.Cells["product"].Value.ToString()
                    , row.Cells["description"].Value.ToString()
                    , row.Cells["quantity"].Value.ToString()
                    , row.Cells["uom"].Value.ToString()
                    , row.Cells["lot"].Value.ToString()
                    , row.Cells["expiry"].Value.ToString()
                    , row.Cells["location"].Value.ToString()
                    );
            }

            ReportDocument rviewer = new ReportDocument();
            rviewer = new crtputaway();
            rviewer.SetDataSource(dt);
            viewer.ReportSource = rviewer;
            viewer.Zoom(110);
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
            String putaway_id = DataSupport.GetNextMenuCodeInt("PA");
            DateTime now = DateTime.Now;

            // Save Transaction
            String sql = DataSupport.GetInsert("Putaways", Utils.ToDict(
                "putaway_id", putaway_id
               , "container", parent.cboContainer.SelectedValue.ToStringNull()
               , "encoded_on", now
                ));

            foreach (DataGridViewRow row in parent.headerGrid.Rows)
            {
                sql += DataSupport.GetInsert("PutawayDetails", Utils.ToDict(
                      "putaway", putaway_id
                     , "product", row.Cells["product"].Value.ToString()
                     , "expected_qty", row.Cells["Quantity"].Value.ToString()
                     , "uom", row.Cells["uom"].Value.ToString()
                     , "lot_no", row.Cells["lot"].Value.ToString()
                     , "expiry", row.Cells["expiry"].Value.ToString()
                     , "location", row.Cells["location"].Value.ToString()
                    ));
            }


            // Update Transaction Ledger
            {
                // Out with the staging in
                DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
                outsDT.Rows.Add("STAGING-IN", now, "OUT", "PUTAWAY", putaway_id);

                sql += LedgerSupport.UpdateLocationLedger(outsDT);


                // In with the container
                DataTable insDT = LedgerSupport.GetLocationLedgerDT();
                foreach (DataGridViewRow row in parent.headerGrid.Rows)
                    insDT.Rows.Add(parent.cboContainer.SelectedValue.ToStringNull(), now, "IN", "PUTAWAY", putaway_id);
                sql += LedgerSupport.UpdateLocationLedger(insDT);

            }

            // Update Location Products Ledger
            {
                // Out with the staging in
                DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataGridViewRow row in parent.headerGrid.Rows)
                    outsDT.Rows.Add("STAGING-IN", row.Cells["product"].Value, int.Parse(row.Cells["Quantity"].Value.ToString()) * -1, row.Cells["uom"].Value, row.Cells["lot"].Value, row.Cells["expiry"].Value);
                sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);


                // In with the container
                DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataGridViewRow row in parent.headerGrid.Rows)
                    insDT.Rows.Add(parent.cboContainer.SelectedValue.ToStringNull(), row.Cells["product"].Value, row.Cells["Quantity"].Value, row.Cells["uom"].Value, row.Cells["lot"].Value, row.Cells["expiry"].Value);
                sql += LedgerSupport.UpdateLocationProductsLedger(insDT);

            }         

            try
            {
                DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);

                DataTable dt = new DataTable();
                dt.Columns.Add("putawayid");
                dt.Columns.Add("containerid");
                dt.Columns.Add("product");
                dt.Columns.Add("desc");
                dt.Columns.Add("qty");
                dt.Columns.Add("uom");
                dt.Columns.Add("lot");
                dt.Columns.Add("expiry");
                dt.Columns.Add("location");
                dt.Columns.Add("putawaybarcode", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("containerbarcode", System.Type.GetType("System.Byte[]"));

                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
                barcode.BarWidth = 5;

                foreach (DataGridViewRow row in parent.headerGrid.Rows)
                {

                    dt.Rows.Add(putaway_id, parent.cboContainer.SelectedValue.ToStringNull()
                        , row.Cells["product"].Value.ToString()
                        , row.Cells["description"].Value.ToString()
                        , row.Cells["quantity"].Value.ToString()
                        , row.Cells["uom"].Value.ToString()
                        , row.Cells["lot"].Value.ToString()
                        , row.Cells["expiry"].Value.ToString()
                        , row.Cells["location"].Value.ToString()
                        , Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, putaway_id), System.Drawing.Imaging.ImageFormat.Jpeg)
                        , Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, parent.cboContainer.SelectedValue.ToStringNull()), System.Drawing.Imaging.ImageFormat.Jpeg)
                        );
                }

                ReportDocument rviewer = new ReportDocument();
                rviewer = new crtputaway();
                rviewer.SetDataSource(dt);
                viewer.ReportSource = rviewer;
                viewer.RefreshReport();
                viewer.Zoom(110);

                MessageBox.Show("Success");
                btnPrintPreview.Text = "Print";
                btnCancel.Text = "Close";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewPutawayConfirmationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (btnPrintPreview.Text == "Print")
                this.DialogResult = DialogResult.OK;
        }
    }
}
