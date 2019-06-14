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
    public partial class DeclareCompleteOptions : Form
    {
        public DeclareCompleteOptions()
        {
            InitializeComponent();
        }

        private void btnDeclareComplete_Click(object sender, EventArgs e)
        {
            String sql = "";
            String putaway_id = txtPutawayID.Text;
            DateTime now = DateTime.Now;

            // Update Putaway
            sql += "UPDATE PutawayDetails SET actual_qty = expected_qty WHERE putaway= '"+putaway_id+"'; ";


            // Update Transactions Ledger
            DataTable detailsDT = FAQ.GetPutawayDetails(putaway_id);

            // Update Transaction Ledger
            {
                // Out with the container
                DataTable outsDT = LedgerSupport.GetLocationLedgerDT();
                outsDT.Rows.Add(txtContainer.Text, now, "OUT", "PUTAWAY_DECLARE_COMPLETE", putaway_id);

                sql += LedgerSupport.UpdateLocationLedger(outsDT);


                // In with the location
                DataTable insDT = LedgerSupport.GetLocationLedgerDT();
                foreach (DataRow row in detailsDT.Rows)
                    insDT.Rows.Add(row["location"], now, "IN", "PUTAWAY_DECLARE_COMPLETE", putaway_id);
                sql += LedgerSupport.UpdateLocationLedger(insDT);

            }


            // Update Location Products Ledger
            {
                // Out with the container
                DataTable outsDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataRow row in detailsDT.Rows)
                    outsDT.Rows.Add(txtContainer.Text, row["product"].ToString(), int.Parse(row["expected_qty"].ToString()) * -1, row["uom"].ToString(), row["lot_no"].ToString(), row["expiry"].ToString());
                sql += LedgerSupport.UpdateLocationProductsLedger(outsDT);


                // In with the location
                DataTable insDT = LedgerSupport.GetLocationProductsLedgerDT();

                foreach (DataRow row in detailsDT.Rows)
                    insDT.Rows.Add(row["location"].ToString(), row["product"].ToString(), row["expected_qty"].ToString(), row["uom"].ToString(), row["lot_no"].ToString(), row["expiry"].ToString());
                sql += LedgerSupport.UpdateLocationProductsLedger(insDT);

            }         

            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");
            this.Close();
        }

        private void btnDeclareIncomplete_Click(object sender, EventArgs e)
        {
            DeclareIncompleteWindow dialog = new DeclareIncompleteWindow();
            dialog.txtPutawayID.Text = this.txtPutawayID.Text;
            dialog.txtContainer.Text = this.txtContainer.Text;
            dialog.ShowDialog();
        }
    }
}
