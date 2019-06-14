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
        DataTable producttopick = null;
        DataTable casebreak = null;
        DataTable putaway = null;
        public BinReplishmentWindow parent = null;
        public String[] ids = null;
        public CaseBreakPickListConfirmation()
        {
            InitializeComponent();
        }

        private void CaseBreakPickListConfirmation_Load(object sender, EventArgs e)
        {

            {
                //picklist
                StringBuilder picklist_builder = new StringBuilder();

                producttopick = new DataTable();
                producttopick.Columns.Add("Location");
                producttopick.Columns.Add("Product");
                producttopick.Columns.Add("Description");
                producttopick.Columns.Add("Qty1");
                producttopick.Columns.Add("Uom1");
                producttopick.Columns.Add("Lot no");
                producttopick.Columns.Add("Expiry");
                producttopick.Columns.Add("putawayid");
                producttopick.Columns.Add("casebreakid");
                producttopick.Columns.Add("picklistid");
                if (parent.genpickgrid.Rows.Count >= 1)
                {
                    foreach (DataGridViewRow row in parent.genpickgrid.Rows)
                    {
                        Boolean is_found = false;
                        foreach (DataRow existing_row in producttopick.Rows)
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
                            producttopick.Rows.Add(row.Cells["gridcolloc"].Value.ToString()
                                        , row.Cells["gridcolprod"].Value.ToString()
                                        , row.Cells["gridcoldesc"].Value.ToString()
                                        , row.Cells["gridcolqty"].Value.ToString()
                                        , row.Cells["gridcoluom"].Value.ToString()
                                        , row.Cells["gridcollot"].Value.ToString()
                                        , DateTime.Parse(row.Cells["gridcolexpiry"].Value.ToString()).ToShortDateString()
                                        , "(issued on save)"
                                        , "(issued on save)"
                                        , "(issued on save)"
                                      );
                        }
                    }
                }
                //Casebreak
                if (parent.gencasebreakgrid.Rows.Count >= 1)
                {
                    picklist_builder = new StringBuilder();

                    casebreak = new DataTable();
                    casebreak.Columns.Add("Product");
                    casebreak.Columns.Add("Description");
                    casebreak.Columns.Add("Qty1");
                    casebreak.Columns.Add("Uom1");
                    casebreak.Columns.Add("Qty2");
                    casebreak.Columns.Add("Uom2");
                    casebreak.Columns.Add("Lot no");
                    casebreak.Columns.Add("Expiry");
                    casebreak.Columns.Add("putawayid");
                    casebreak.Columns.Add("casebreakid");
                    casebreak.Columns.Add("picklistid");
                    foreach (DataGridViewRow row in parent.gencasebreakgrid.Rows)
                    {
                        casebreak.Rows.Add(row.Cells["gridcolcasebreak_prod"].Value.ToString()
                                    , row.Cells["gridcolcasebreak_desc"].Value.ToString()
                                    , row.Cells["gridcolcasebreak_locqty"].Value.ToString()
                                    , row.Cells["gridcolcasebreak_locuom"].Value.ToString()
                                    , row.Cells["gridcolcasebreak_binqty"].Value.ToString()
                                    , row.Cells["gridcolcasebreak_binuom"].Value.ToString()
                                    , row.Cells["gridcolcasebreak_lot"].Value.ToString()
                                    , DateTime.Parse(row.Cells["gridcolcasebreak_expiry"].Value.ToString()).ToShortDateString()
                                    , "(issued on save)"
                                    , "(issued on save)"
                                    , "(issued on save)"
                                    );
                    }
                }
                //Put Away
                if (parent.putawaygrid.Rows.Count >= 1)
                {
                    picklist_builder = new StringBuilder();

                    putaway = new DataTable();
                    putaway.Columns.Add("Product");
                    putaway.Columns.Add("Description");
                    putaway.Columns.Add("Qty2");
                    putaway.Columns.Add("Uom2");
                    putaway.Columns.Add("Lot no");
                    putaway.Columns.Add("Expiry");
                    putaway.Columns.Add("Location");
                    putaway.Columns.Add("putawayid");
                    putaway.Columns.Add("casebreakid");
                    putaway.Columns.Add("picklistid");
                    foreach (DataGridViewRow row in parent.putawaygrid.Rows)
                    {
                        putaway.Rows.Add(row.Cells["gridcolputaway_prod"].Value.ToString()
                                              , row.Cells["gridcolputaway_desc"].Value.ToString()
                                              , row.Cells["gridcolputaway_qty"].Value.ToString()
                                              , row.Cells["gridcolputaway_binuom"].Value.ToString()
                                              , row.Cells["gridcolputaway_lot"].Value.ToString()
                                              , DateTime.Parse(row.Cells["gridcolputaway_expiry"].Value.ToString()).ToShortDateString()
                                              , row.Cells["gridcolputaway_bin"].Value.ToString()
                                              , "(issued on save)"
                                              , "(issued on save)"
                                              , "(issued on save)"
                                              );

                    }
                }
                CrystalDecisions.CrystalReports.Engine.ReportDocument rviewer = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rviewer = new WMS.crtpicklistforcasebreak();
                rviewer.SetDataSource(producttopick);
                rviewer.Subreports["crtcasebreak.rpt"].SetDataSource(casebreak);
                rviewer.Subreports["crtputawaycasebreak.rpt"].SetDataSource(putaway);

                viewer.ReportSource = rviewer;
                viewer.Zoom(110);
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

                        CrystalDecisions.CrystalReports.Engine.ReportDocument rviewer = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rviewer = new WMS.crtpicklistforcasebreak();

                        BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
                        barcode.BarWidth = 5;
                        DataColumn pick = new DataColumn("picklistbarcode", System.Type.GetType("System.Byte[]"));
                        pick.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, ids[0]), System.Drawing.Imaging.ImageFormat.Jpeg);
                        DataColumn caseb = new DataColumn("casebreakbarcode", System.Type.GetType("System.Byte[]"));
                        caseb.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, ids[1]), System.Drawing.Imaging.ImageFormat.Jpeg);
                        DataColumn putbar = new DataColumn("putawaybarcode", System.Type.GetType("System.Byte[]"));
                        putbar.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, ids[2]), System.Drawing.Imaging.ImageFormat.Jpeg);
                        producttopick.Columns.Add(pick);
                        producttopick.Columns.Add(caseb);
                        producttopick.Columns.Add(putbar);

                        pick = new DataColumn("picklistbarcode", System.Type.GetType("System.Byte[]"));
                        pick.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, ids[0]), System.Drawing.Imaging.ImageFormat.Jpeg);
                        caseb = new DataColumn("casebreakbarcode", System.Type.GetType("System.Byte[]"));
                        caseb.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, ids[1]), System.Drawing.Imaging.ImageFormat.Jpeg);
                        putbar = new DataColumn("putawaybarcode", System.Type.GetType("System.Byte[]"));
                        putbar.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, ids[2]), System.Drawing.Imaging.ImageFormat.Jpeg);
                        casebreak.Columns.Add(pick);
                        casebreak.Columns.Add(caseb);
                        casebreak.Columns.Add(putbar);

                        pick = new DataColumn("picklistbarcode", System.Type.GetType("System.Byte[]"));
                        pick.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, ids[0]), System.Drawing.Imaging.ImageFormat.Jpeg);
                        caseb = new DataColumn("casebreakbarcode", System.Type.GetType("System.Byte[]"));
                        caseb.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, ids[1]), System.Drawing.Imaging.ImageFormat.Jpeg);
                        putbar = new DataColumn("putawaybarcode", System.Type.GetType("System.Byte[]"));
                        putbar.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, ids[2]), System.Drawing.Imaging.ImageFormat.Jpeg);
                        putaway.Columns.Add(pick);
                        putaway.Columns.Add(caseb);
                        putaway.Columns.Add(putbar);

                        producttopick.Columns.Remove("picklistid");
                        producttopick.Columns.Remove("casebreakid");
                        producttopick.Columns.Remove("putawayid");
                        DataColumn dc = new DataColumn("picklistid");
                        dc.DefaultValue = ids[0];
                        producttopick.Columns.Add(dc);
                        dc = new DataColumn("casebreakid");
                        dc.DefaultValue = ids[1];
                        producttopick.Columns.Add(dc);
                        dc = new DataColumn("putawayid");
                        dc.DefaultValue = ids[2];
                        producttopick.Columns.Add(dc);
                        rviewer.SetDataSource(producttopick);

                        casebreak.Columns.Remove("picklistid");
                        casebreak.Columns.Remove("casebreakid");
                        casebreak.Columns.Remove("putawayid");
                        dc = new DataColumn("picklistid");
                        dc.DefaultValue = ids[0];
                        casebreak.Columns.Add(dc);
                        dc = new DataColumn("casebreakid");
                        dc.DefaultValue = ids[1];
                        casebreak.Columns.Add(dc);
                        dc = new DataColumn("putawayid");
                        dc.DefaultValue = ids[2];
                        casebreak.Columns.Add(dc);
                        rviewer.Subreports["crtcasebreak.rpt"].SetDataSource(casebreak);

                        putaway.Columns.Remove("picklistid");
                        putaway.Columns.Remove("casebreakid");
                        putaway.Columns.Remove("putawayid");
                        dc = new DataColumn("picklistid");
                        dc.DefaultValue = ids[0];
                        putaway.Columns.Add(dc);
                        dc = new DataColumn("casebreakid");
                        dc.DefaultValue = ids[1];
                        putaway.Columns.Add(dc);
                        dc = new DataColumn("putawayid");
                        dc.DefaultValue = ids[2];
                        putaway.Columns.Add(dc);
                        rviewer.Subreports["crtputawaycasebreak.rpt"].SetDataSource(putaway);

                        viewer.ReportSource = rviewer;
                        viewer.Zoom(110);


                        btnPrintPreview.Text = "Print";
                        btnCancel.Text = "Close";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    viewer.PrintReport();
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
               , "container", "BTN1-BIN"
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
