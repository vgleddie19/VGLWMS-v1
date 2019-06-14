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
    public partial class NewCaseBreak : Form
    {
        public NewCaseBreak()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            casebreakdetails dialog = new casebreakdetails();
            dialog.parent = this;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            putawaycasebreakpicklistconfirmation dialog = new putawaycasebreakpicklistconfirmation();
            dialog.parent = this;
            dialog.ShowDialog();
            //confirm_picklistcasebreakputaway();
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
    }
}
