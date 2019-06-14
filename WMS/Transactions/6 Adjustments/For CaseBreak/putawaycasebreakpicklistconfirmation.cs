using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{ 
    public partial class putawaycasebreakpicklistconfirmation : Form
    {
        DataTable producttopick = null;
        DataTable casebreak = null;
        DataTable putaway = null;
        public NewCaseBreak parent = null;
        public String[] ids = null;
        bool isneedconfirm = false;
        public putawaycasebreakpicklistconfirmation()
        {
            InitializeComponent();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            

            if (parent.grd.Rows.Count >= 1 || parent.grd.Rows.Count >= 1 ||
                parent.grd.Rows.Count >= 1)
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

                        if (!isneedconfirm)
                            confirm_picklistcasebreakputaway(ids[0], ids[1], ids[2]);
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

            foreach (DataGridViewRow row in parent.grd.Rows)
            {
                sql += DataSupport.GetInsert("PicklistDetails", Utils.ToDict(
                      "picklist", id
                     , "line", parent.grd.Rows.IndexOf(row) + 1
                     , "order_id", "0"
                     , "product", row.Cells["product"].Value.ToString()
                     , "qty", row.Cells["locoriginqty"].Value.ToString()
                     , "uom", row.Cells["uom"].Value.ToString()
                     , "lot_no", row.Cells["lot"].Value.ToString()
                     , "expiry", row.Cells["expiry"].Value.ToString()
                     , "location", row.Cells["locationorigin"].Value.ToString()
                    ));
            }

            foreach (DataGridViewRow row in parent.grd.Rows)
            {
                sql += " UPDATE LocationProductsLedger SET to_be_picked_qty = to_be_picked_qty + " + row.Cells["locoriginqty"].Value.ToString() + ", [reserved_qty] = [reserved_qty] + " + row.Cells["locoriginqty"].Value.ToString() + " WHERE location='" + row.Cells["locationorigin"].Value.ToString() + "' AND product='" + row.Cells["product"].Value.ToString() + "' AND uom='" + row.Cells["uom"].Value.ToString() + "' AND lot_no='" + row.Cells["lot"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "'; ";
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

            foreach (DataGridViewRow row in parent.grd.Rows)
            {
                sql += DataSupport.GetInsert("CaseBreakDetails", Utils.ToDict(
                      "casebreak", id
                     , "line", parent.grd.Rows.IndexOf(row) + 1
                     , "product", row.Cells["product"].Value.ToString()
                     , "qty", row.Cells["locoriginqty"].Value.ToString()
                     , "uom", row.Cells["uom"].Value.ToString()
                     , "lot_no", row.Cells["lot"].Value.ToString()
                     , "expiry", row.Cells["expiry"].Value.ToString()
                     , "location", row.Cells["translocation"].Value.ToString()
                     , "breakto_uom", "PC"
                     , "expected_qty", row.Cells["transfer_qty"].Value.ToString()
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

            foreach (DataGridViewRow row in parent.grd.Rows)
            {
                sql += DataSupport.GetInsert("PutawayDetails", Utils.ToDict(
                      "putaway", putaway_id
                     , "product", row.Cells["product"].Value.ToString()
                     , "expected_qty", row.Cells["transfer_qty"].Value.ToString()
                     , "uom", "PC"
                     , "lot_no", row.Cells["lot"].Value.ToString()
                     , "expiry", row.Cells["expiry"].Value.ToString()
                     , "location", row.Cells["translocation"].Value.ToString()
                    ));
            }

            return sql;
        }

        private void confirm_picklistcasebreakputaway(String picklist_id, String casebreak_id, String putaway_id)
        {
            DataTable picklistdetails = DataSupport.RunDataSet(String.Format("SELECT * FROM [PicklistDetails] WHERE picklist = '{0}'", picklist_id)).Tables[0];
            DataTable casebreakdetails = DataSupport.RunDataSet(String.Format("SELECT * FROM [CaseBreakDetails] WHERE casebreak = '{0}'", casebreak_id)).Tables[0];
            DataTable putawaydetails = DataSupport.RunDataSet(String.Format("SELECT * FROM [PutawayDetails] WHERE putaway = '{0}'", putaway_id)).Tables[0];
            Dictionary<String, DataRow> binreplenishment = Utils.BuildIndex("SELECT *,([Location]+[product]+[uom]+[lot_no]+convert(nvarchar(30), expiry, 101))[search] FROM [wms_db].[dbo].BinProductLedger", "search");
            StringBuilder sql = new StringBuilder();
            //picklist
            if (picklistdetails.Rows.Count >= 1)
            {
                // Update Picklist
                sql.Append(String.Format("UPDATE Picklists SET status = 'DECLARED COMPLETE' WHERE picklist_id= '{0}'; ", picklist_id));
                // Update Transaction Ledger
                {
                    DataTable insDT = LedgerSupport.GetLocationLedgerDT();

                    insDT.Rows.Add("STOCKS-P", DateTime.Now, "IN", "PICKLIST_DECLARE_COMPLETE", picklist_id);
                    sql.Append(LedgerSupport.UpdateLocationLedger(insDT));


                    DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
                    foreach (DataRow row in picklistdetails.Rows)
                        outsDT.Rows.Add(row["location"], DateTime.Now, "OUT", "PICKLIST_DECLARE_COMPLETE", picklist_id);

                    sql.Append(LedgerSupport.UpdateLocationLedger(outsDT));
                }

                // Update Location Products Ledger
                {
                    DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

                    foreach (DataRow row in picklistdetails.Rows)
                        insDT.Rows.Add("STOCKS-P", row["product"], row["qty"], row["uom"], row["lot_no"], row["expiry"]);
                    sql.Append(LedgerSupport.UpdateLocationProductsLedger(insDT));

                    DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();
                    foreach (DataRow row in picklistdetails.Rows)
                        outsDT.Rows.Add(row["location"], row["product"], int.Parse(row["qty"].ToString()) * -1, row["uom"], row["lot_no"], row["expiry"], int.Parse(row["qty"].ToString()) * -1, int.Parse(row["qty"].ToString()) * -1);
                    sql.Append(LedgerSupport.UpdateLocationProductsLedger(outsDT));
                }
                try
                {
                    DataSupport.RunNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            //breakcase
            if (casebreakdetails.Rows.Count >= 1)
            {
                sql = new StringBuilder();
                sql.Append(String.Format("UPDATE CaseBreak SET status = 'DECLARED COMPLETE' WHERE casebreak_id= '{0}'; ", casebreak_id));
                sql.Append(String.Format("DELETE FROM pendingCaseBreak WHERE casebreakid= '{0}'; ", casebreak_id));
                // Update Transaction Ledger
                {
                    DataTable insDT = LedgerSupport.GetLocationLedgerDT();
                    foreach (DataRow row in picklistdetails.Rows)
                        insDT.Rows.Add(row["location"], DateTime.Now.AddSeconds(1), "IN", "CASEBREAK_DECLARE_COMPLETE", casebreak_id);
                    sql.Append(LedgerSupport.UpdateLocationLedger(insDT));


                    DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
                    foreach (DataRow row in picklistdetails.Rows)
                        outsDT.Rows.Add(row["location"], DateTime.Now.AddSeconds(1), "OUT", "CASEBREAK_DECLARE_COMPLETE", casebreak_id);

                    sql.Append(LedgerSupport.UpdateLocationLedger(outsDT));
                }

                {
                    DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

                    foreach (DataRow row in casebreakdetails.Rows)
                        insDT.Rows.Add(row["location"], row["product"], row["expected_qty"], row["breakto_uom"], row["lot_no"], row["expiry"]);
                    sql.Append(LedgerSupport.UpdateLocationProductsLedger(insDT));

                    DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();
                    foreach (DataRow row in picklistdetails.Rows)
                        outsDT.Rows.Add(row["location"], row["product"], int.Parse(row["qty"].ToString()) * -1, row["uom"], row["lot_no"], row["expiry"], 0, 0);
                    sql.Append(LedgerSupport.UpdateLocationProductsLedger(outsDT));
                }
                try
                {
                    DataSupport.RunNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            //putaway
            if (putawaydetails.Rows.Count >= 1)
            {
                sql = new StringBuilder();
                sql.Append(String.Format("UPDATE PUTAWAYS SET completed_on = '{1}' WHERE putaway_id= '{0}'; ", putaway_id, DateTime.Now));
                // Update Transaction Ledger
                {
                    DataTable insDT = LedgerSupport.GetLocationLedgerDT();
                    foreach (DataRow row in putawaydetails.Rows)
                        insDT.Rows.Add(row["location"], DateTime.Now.AddSeconds(2), "IN", "PUTAWAY_DECLARE_COMPLETE", putaway_id);
                    sql.Append(LedgerSupport.UpdateLocationLedger(insDT));

                    DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
                    foreach (DataRow row in casebreakdetails.Rows)
                        outsDT.Rows.Add(row["location"], DateTime.Now.AddSeconds(2), "OUT", "PUTAWAY_DECLARE_COMPLETE", putaway_id);

                    sql.Append(LedgerSupport.UpdateLocationLedger(outsDT));
                }

                {
                    DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

                    foreach (DataRow row in putawaydetails.Rows)
                    {
                        insDT.Rows.Add(row["location"], row["product"], row["expected_qty"], row["uom"], row["lot_no"], row["expiry"]);

                        string search = String.Format("{0}{1}{2}{3}{4}", row["Location"], row["product"], row["uom"], row["lot_no"], Convert.ToDateTime(row["expiry"]).ToString("MM/dd/yyyy"));
                        DataRow search_row = null;
                        if (binreplenishment.TryGetValue(search, out search_row))
                        {
                            sql.Append(DataSupport.GetUpdate("BinProductLedger", Utils.ToDict(
                                      "location", row["location"].ToString()
                                     , "product", row["product"].ToString()
                                     , "actualqty", Convert.ToInt32(search_row["actualqty"]) + Convert.ToInt32(row["expected_qty"])
                                     , "uom", row["uom"].ToString()
                                     , "lot_no", row["lot_no"].ToString()
                                     , "expiry", row["expiry"].ToString()
                                     , "qty_to_replenished", 0
                                    ), new List<string> { "location", "product", "uom", "lot_no", "expiry" }));
                        }
                        String S = String.Format(@"UPDATE LocationProductsLedger SET casebreak_qty = casebreak_qty - {0} WHERE product = '{1}' and location = '{2}' and lot_no = '{3}' and expiry ='{4}' and uom = '{5}'"
                        , int.Parse(row["expected_qty"].ToString()), row["product"], row["location"], row["lot_no"], row["expiry"], row["uom"]);
                        sql.Append(S);
                    }
                    sql.Append(LedgerSupport.UpdateLocationProductsLedger(insDT));

                    DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();
                    foreach (DataRow row in casebreakdetails.Rows)
                    {
                        outsDT.Rows.Add(row["location"], row["product"], int.Parse(row["expected_qty"].ToString()) * -1, row["breakto_uom"], row["lot_no"], row["expiry"], 0, 0);
                    }
                    sql.Append(LedgerSupport.UpdateLocationProductsLedger(outsDT));
                }
                try
                {

                    DataSupport.RunNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);
                    MessageBox.Show("Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void putawaycasebreakpicklistconfirmation_Load(object sender, EventArgs e)
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
                if (parent.grd.Rows.Count >= 1)
                {
                    foreach (DataGridViewRow row in parent.grd.Rows)
                    {
                        Boolean is_found = false;
                        foreach (DataRow existing_row in producttopick.Rows)
                        {
                            if (
                                   existing_row["Location"].ToString() == row.Cells["locationorigin"].Value.ToString()
                                && existing_row["Product"].ToString() == row.Cells["product"].Value.ToString()
                                && existing_row["Lot no"].ToString() == row.Cells["lot"].Value.ToString()
                                && existing_row["Uom1"].ToString() == row.Cells["uom"].Value.ToString()
                                && DateTime.Parse(existing_row["Expiry"].ToString()).ToShortDateString() == DateTime.Parse(row.Cells["expiry"].Value.ToString()).ToShortDateString()
                                )
                            {
                                existing_row["Qty1"] = int.Parse(row.Cells["locoriginqty"].Value.ToString()) + int.Parse(existing_row["Qty1"].ToString());
                                is_found = true;
                                break;
                            }
                        }
                        if (!is_found)
                        {
                            producttopick.Rows.Add(row.Cells["locationorigin"].Value.ToString()
                                        , row.Cells["product"].Value.ToString()
                                        , row.Cells["description"].Value.ToString()
                                        , row.Cells["locoriginqty"].Value.ToString()
                                        , row.Cells["uom"].Value.ToString()
                                        , row.Cells["lot"].Value.ToString()
                                        , DateTime.Parse(row.Cells["expiry"].Value.ToString()).ToShortDateString()
                                        , "(issued on save)"
                                        , "(issued on save)"
                                        , "(issued on save)"
                                      );
                        }

                        if (row.Cells["locationorigin"].Value.ToString() != row.Cells["translocation"].Value.ToString())
                            isneedconfirm = true;
                    }
                }
                //Casebreak
                if (parent.grd.Rows.Count >= 1)
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
                    foreach (DataGridViewRow row in parent.grd.Rows)
                    {
                        casebreak.Rows.Add(row.Cells["product"].Value.ToString()
                                    , row.Cells["description"].Value.ToString()
                                    , row.Cells["locoriginqty"].Value.ToString()
                                    , row.Cells["uom"].Value.ToString()
                                    , row.Cells["transfer_qty"].Value.ToString()
                                    , "PC"
                                    , row.Cells["lot"].Value.ToString()
                                    , DateTime.Parse(row.Cells["expiry"].Value.ToString()).ToShortDateString()
                                    , "(issued on save)"
                                    , "(issued on save)"
                                    , "(issued on save)"
                                    );
                    }
                }
                //Put Away
                if (parent.grd.Rows.Count >= 1)
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
                    foreach (DataGridViewRow row in parent.grd.Rows)
                    {
                        putaway.Rows.Add(row.Cells["product"].Value.ToString()
                                              , row.Cells["description"].Value.ToString()
                                              , row.Cells["transfer_qty"].Value.ToString()
                                              , "PC"
                                              , row.Cells["lot"].Value.ToString()
                                              , DateTime.Parse(row.Cells["expiry"].Value.ToString()).ToShortDateString()
                                              , row.Cells["translocation"].Value.ToString()
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
    }
}
