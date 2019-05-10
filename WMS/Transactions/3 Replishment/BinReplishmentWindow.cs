using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Rendering;
using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VGLHelper;
using WMS.Utilities;

namespace WMS
{
    public partial class BinReplishmentWindow : Form
    {
        public List<String> process_bin { get; set; }
        Dictionary<String, DataRow> products = Utils.BuildIndex("SELECT * FROM Products", "product_id");
        #region Form Initialization
        public BinReplishmentWindow()
        {
            InitializeComponent();
            UISetter.SetGridAppearance(genpickgrid, headerGrid, gencasebreakgrid,putawaygrid, grdreplenishmentconfirm);
        }

        private void BinReplishmentWindow_Load(object sender, EventArgs e)
        {
            loadreplenishment();
            //Etcetera.modify_coltype(headerGrid, "button", DataGridViewAutoSizeColumnMode.DisplayedCells, 200, "btn", "Action",headerGrid.Columns.Count-1);
            UISetter.SetLabelAppearance(label1, label2, label3);
        }
        private void loadreplenishment()
        {
            DataTable dt = DataSupport.RunDataSet("SELECT [Location], [Product], [uom], [lot_no], convert(varchar, [expiry], 101)[expiry], [actualqty], [min_qty], [max_qty], [qty_to_replenished], [status] FROM binproductledger").Tables[0];
            if (dt.Rows.Count == 0)
                return;

            headerGrid.DataSource = dt;
            headerGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            headerGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            headerGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerGrid.Columns["uom"].HeaderText = "UOM";
            headerGrid.Columns["lot_no"].HeaderText = "Lot Number";
            headerGrid.Columns["expiry"].HeaderText = "Expiry Date";
            headerGrid.Columns["actualqty"].HeaderText = "Actual Qty.";
            headerGrid.Columns["min_qty"].HeaderText = "Minimum Qty.";
            headerGrid.Columns["max_qty"].HeaderText = "Maximum Qty.";
            headerGrid.Columns["qty_to_replenished"].HeaderText = "Qty. to Replenished";
            headerGrid.Columns["status"].HeaderText = "Status";

            dt = DataSupport.RunDataSet("SELECT casebreak_id,picklist_id,putaway_id,status,'Confirm'[btn] FROM [CaseBreak] WHERE status != 'DECLARED COMPLETE'").Tables[0];
            grdreplenishmentconfirm.DataSource = dt;
            grdreplenishmentconfirm.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdreplenishmentconfirm.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grdreplenishmentconfirm.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grdreplenishmentconfirm.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdreplenishmentconfirm.Columns["casebreak_id"].HeaderText = "CASE BREAK ID";
            grdreplenishmentconfirm.Columns["picklist_id"].HeaderText = "PICKLIST ID";
            grdreplenishmentconfirm.Columns["putaway_id"].HeaderText = "PUT-AWAY ID";
            grdreplenishmentconfirm.Columns["status"].HeaderText = "Status";
            if (dt.Rows.Count == 0)
            {
                //grdreplenishmentconfirm.Columns["btn"].Visible = false;
                return;
            }
                Etcetera.modify_coltype(grdreplenishmentconfirm, "button", DataGridViewAutoSizeColumnMode.None, 250, "btn", "Action", headerGrid.Columns.Count - 1);
        }
        private void utabControl1_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            genpickgrid.Rows.Clear();
            gencasebreakgrid.Rows.Clear();
            putawaygrid.Rows.Clear();
            e.Tab.Visible = false;
            e.Cancel = true;
        }
        #endregion

        #region Generate Replenishment and Controls
        private void btnaddprod_Click(object sender, EventArgs e)
        {
            //SearchProductStocks sp = new SearchProductStocks();
            //sp.Icon = this.Icon;
            //sp.StartPosition = FormStartPosition.CenterScreen;
            //sp.parentform = this;
            //if (sp.ShowDialog() == DialogResult.OK)
            //{

            //}
        }
        #endregion

        private void btngendocs_Click(object sender, EventArgs e)
        {
            CaseBreakPickListConfirmation dialog = new CaseBreakPickListConfirmation();
            dialog.parent = this;
            dialog.ShowDialog();
            loadreplenishment();
            genpickgrid.Rows.Clear();
            gencasebreakgrid.Rows.Clear();
            putawaygrid.Rows.Clear();
            tabcontrol.Tabs["tabgenpick"].Visible = false;
            tabcontrol.SelectedTabIndex = 1;
        }

        private void headerGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void btnNewPutaway_Click(object sender, EventArgs e)
        {
            genpickgrid.Rows.Clear();
            putawaygrid.Rows.Clear();
            gencasebreakgrid.Rows.Clear();
            foreach (DataRow dRow in FAQ.Whatareproductstobereplenish().Rows)
            {
                genpickgrid.Rows.Add(dRow["location"], dRow["product"], products[dRow["product"].ToString()]["description"], dRow["qty"], dRow["uom"], dRow["lot"], dRow["expiry"]);
                putawaygrid.Rows.Add(dRow["product"], products[dRow["product"].ToString()]["description"], (Convert.ToDecimal(dRow["qty"]) * Convert.ToDecimal(dRow["locuomconv"])) / Convert.ToDecimal(dRow["binuomconv"]), dRow["binuom"], dRow["lot"], dRow["expiry"],dRow["binid"]);
                if (dRow["uom"].ToString() == "CS" || dRow["uom"].ToString() == "CASES")
                {
                    gencasebreakgrid.Rows.Add(dRow["product"], products[dRow["product"].ToString()]["description"], dRow["qty"], dRow["uom"], (Convert.ToDecimal(dRow["qty"]) * Convert.ToDecimal(dRow["locuomconv"])) / Convert.ToDecimal(dRow["binuomconv"]), dRow["binuom"], dRow["lot"], dRow["expiry"]);
                }
            }
            tabcontrol.Tabs["tabgenpick"].Visible = true;
            tabcontrol.SelectedTabIndex = 2;
        }

        private void grdreplenishmentconfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grdreplenishmentconfirm.Columns["btn-x"].Index)
            {
                declarebincomplete picklist = new declarebincomplete();
                picklist.type = "pick";
                if (picklist.ShowDialog() != DialogResult.OK)
                    return;

                declarebincomplete casebreak = new declarebincomplete();
                casebreak.type = "casebreak";
                casebreak.picklistid = picklist.picklistid;
                casebreak.label2.Text = "Scan CaseBreak ID:";
                if (casebreak.ShowDialog() != DialogResult.OK)
                    return;

                declarebincomplete putaway = new declarebincomplete();
                putaway.type = "putaway";
                putaway.label2.Text = "Scan PutAway ID:";
                putaway.picklistid = picklist.picklistid;
                putaway.casebreakid = casebreak.casebreakid;
                if (putaway.ShowDialog() != DialogResult.OK)
                    return;

                confirm_picklistcasebreakputaway(grdreplenishmentconfirm.Rows[e.RowIndex].Cells["picklist_id"].Value.ToString(), grdreplenishmentconfirm.Rows[e.RowIndex].Cells["casebreak_id"].Value.ToString(), grdreplenishmentconfirm.Rows[e.RowIndex].Cells["putaway_id"].Value.ToString());
            }
        }
        private void confirm_picklistcasebreakputaway(String picklist_id, String casebreak_id, String putaway_id)
        {
            DataTable picklistdetails = DataSupport.RunDataSet(String.Format("SELECT * FROM [PicklistDetails] WHERE picklist = '{0}'", picklist_id)).Tables[0];
            DataTable casebreakdetails = DataSupport.RunDataSet(String.Format("SELECT * FROM [CaseBreakDetails] WHERE casebreak = '{0}'", casebreak_id)).Tables[0];
            DataTable putawaydetails = DataSupport.RunDataSet(String.Format("SELECT * FROM [PutawayDetails] WHERE putaway = '{0}'", putaway_id)).Tables[0];
            Dictionary<String, DataRow> binreplenishment = Utils.BuildIndex("SELECT *,([Location]+[product]+[uom]+[lot_no]+convert(nvarchar(30), expiry, 101))[search] FROM [wms_db].[dbo].BinProductLedger", "search");
            StringBuilder sql = new StringBuilder();
            //picklist
            if(picklistdetails.Rows.Count >= 1)
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
                // Update Transaction Ledger
                {
                    DataTable insDT = LedgerSupport.GetLocationLedgerDT();

                    insDT.Rows.Add("STOCKS-P2", DateTime.Now.AddSeconds(1), "IN", "CASEBREAK_DECLARE_COMPLETE", casebreak_id);
                    sql.Append(LedgerSupport.UpdateLocationLedger(insDT));


                    DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
                    foreach (DataRow row in picklistdetails.Rows)
                        outsDT.Rows.Add("STOCKS-P", DateTime.Now.AddSeconds(1), "OUT", "CASEBREAK_DECLARE_COMPLETE", casebreak_id);

                    sql.Append(LedgerSupport.UpdateLocationLedger(outsDT));
                }

                {
                    DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

                    foreach (DataRow row in casebreakdetails.Rows)
                        insDT.Rows.Add("STOCKS-P2", row["product"], row["expected_qty"], row["breakto_uom"], row["lot_no"], row["expiry"]);
                    sql.Append(LedgerSupport.UpdateLocationProductsLedger(insDT));

                    DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();
                    foreach (DataRow row in picklistdetails.Rows)
                        outsDT.Rows.Add("STOCKS-P", row["product"], int.Parse(row["qty"].ToString()) * -1, row["uom"], row["lot_no"], row["expiry"], 0, 0);
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
                sql.Append(String.Format("UPDATE PUTAWAYS SET completed_on = '{1}' WHERE putaway_id= '{0}'; ", putaway_id,DateTime.Now));
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

                        string search = String.Format("{0}{1}{2}{3}{4}",row["Location"],row["product"],row["uom"],row["lot_no"],Convert.ToDateTime(row["expiry"]).ToString("MM/dd/yyyy"));
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
                                    ),new List<string> { "location", "product", "uom", "lot_no","expiry" }));
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
                    loadreplenishment();
                    MessageBox.Show("Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
