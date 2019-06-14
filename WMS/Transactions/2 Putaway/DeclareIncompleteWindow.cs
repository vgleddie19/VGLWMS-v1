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
    public partial class DeclareIncompleteWindow : Form
    {
        public DeclareIncompleteWindow()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataRow products_row = BarcodeSupport.GetProductFromBarcode(txtScan.Text);
                    if (products_row == null)
                        throw new Exception("Barcode Not Recognized!");

                    String product = products_row["PRODUCT"].ToString();
                    String uom = products_row["MATCHED_UOM"].ToString();

                    DataTable lotsDt = new DataTable();
                    lotsDt.Columns.Add("Lot No");
                    lotsDt.Columns.Add("Expiry");

                    foreach (DataGridViewRow row in putaway_details_grid.Rows)
                    {
                        if (row.Cells["product"].Value.ToString() == product 
                            && row.Cells["uom"].Value.ToString() == uom
                            && int.Parse(row.Cells["Quantity"].Value.ToString()) >0
                            )
                        {
                            lotsDt.Rows.Add(row.Cells["Lot No"].Value.ToString(), row.Cells["Expiry"].Value.ToString());
                        }
                    }

                    if (lotsDt.Rows.Count == 0)
                        throw new Exception("Scanned item not recognized!");
                    SelectGridWindow select_dialog = new SelectGridWindow();
                    select_dialog.dataGridView1.DataSource = lotsDt;


                    if (select_dialog.ShowDialog() == DialogResult.OK)
                    {
                        var selected_row = select_dialog.dataGridView1.SelectedRows[0];

                        List<DataGridViewRow> for_deletion = new List<DataGridViewRow>();
                        foreach (DataGridViewRow row in putaway_details_grid.Rows)
                        {
                            if (row.Cells["product"].Value.ToString() == product
                                && row.Cells["uom"].Value.ToString() == uom
                                && row.Cells["Lot No"].Value.ToString() == selected_row.Cells["Lot No"].Value.ToString()
                                && row.Cells["Expiry"].Value.ToString() == selected_row.Cells["Expiry"].Value.ToString()
                                )
                            {
                                row.Cells["Quantity"].Value = int.Parse(row.Cells["Quantity"].Value.ToString()) - 1;
                                if (int.Parse(row.Cells["Quantity"].Value.ToString()) <= 0)
                                    for_deletion.Add(row);

                                Boolean is_existing = false;
                                foreach (DataGridViewRow return_row in returns_grid.Rows)
                                {
                                    if (return_row.Cells["product"].Value.ToString() == product
                                && return_row.Cells["uom"].Value.ToString() == uom
                                && return_row.Cells["lot_no"].Value.ToString() == selected_row.Cells["Lot No"].Value.ToString()
                                && return_row.Cells["expiry"].Value.ToString() == selected_row.Cells["Expiry"].Value.ToString()
                                        )
                                    {
                                        return_row.Cells["Quantity"].Value = int.Parse(return_row.Cells["Quantity"].Value.ToString()) + 1;
                                        is_existing = true;
                                    }
                                }

                                if (!is_existing)
                                {
                                    returns_grid.Rows.Add(product, uom, selected_row.Cells["Lot No"].Value.ToString(), selected_row.Cells["Expiry"].Value.ToString(), 1);
                                }


                            }
                        }
                        foreach (DataGridViewRow row in for_deletion)
                        {
                            putaway_details_grid.Rows.Remove(row);
                        }

                        txtScan.Text = "";
                        txtScan.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        
        private void DeclareIncompleteWindow_Load(object sender, EventArgs e)
        {
            txtScan.Select();
            DataTable dt = DataSupport.RunDataSet(@"SELECT  
      [Product]
      ,[Uom]
      ,lot_no [Lot No] 
      ,[Expiry]
      ,expected_qty[Quantity]
      ,location
  FROM[PutawayDetails] WHERE putaway = @id", "id", txtPutawayID.Text).Tables[0];
            putaway_details_grid.DataSource = dt;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String sql = "";
            String putaway_id = txtPutawayID.Text;

            // Update the Putaway Details for those declared complete
            foreach (DataGridViewRow row in putaway_details_grid.Rows)
            {
                sql += "UPDATE PutawayDetails SET actual_qty = '"+row.Cells["Quantity"].Value.ToString()+"' WHERE putaway='"+txtPutawayID.Text+ "' AND product = '" + row.Cells["product"].Value.ToString() + "' AND uom='" + row.Cells["uom"].Value.ToString() + "' AND lot_no='" + row.Cells["lot no"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "' ";
            }


            // Update the Putaway Details for those declared returneds
            foreach (DataGridViewRow row in returns_grid.Rows)
            {
                sql += "UPDATE PutawayDetails SET actual_qty = expected_qty - " + row.Cells["qty"].Value.ToString() + " WHERE putaway='" + txtPutawayID.Text + "' AND product = '" + row.Cells["product"].Value.ToString() + "' AND uom='" + row.Cells["uom"].Value.ToString() + "' AND lot_no='" + row.Cells["lot_no"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "' ";
            }

            // Transactions Ledger

            sql += DataSupport.GetInsert("LocationLedger", Utils.ToDict(
              "location", txtContainer.Text
             , "transaction_datetime", DateTime.Now.ToString()
             , "transaction_type", "OUT"
             , "transaction_name", "PUTAWAY_DECLARE_INCOMPLETE"
             , "transaction_id", putaway_id
              ));

            foreach (DataGridViewRow row in putaway_details_grid.Rows)
            {
                sql += DataSupport.GetUpsert("LocationLedger", Utils.ToDict(
                    "location", row.Cells["location"].Value.ToString()
                   , "transaction_datetime", DateTime.Now.ToString()
                   , "transaction_type", "IN"
                   , "transaction_name", "PUTAWAY_DECLARE_INCOMPLETE"
                   , "transaction_id", putaway_id
                    ), "location", "transaction_datetime", "transaction_id");
            }

            foreach (DataGridViewRow row in returns_grid.Rows)
            {
                sql += DataSupport.GetUpsert("LocationLedger", Utils.ToDict(
                    "location", "STAGING-IN"
                   , "transaction_datetime", DateTime.Now.ToString()
                   , "transaction_type", "IN"
                   , "transaction_name", "PUTAWAY_DECLARE_INCOMPLETE"
                   , "transaction_id", putaway_id
                    ), "location", "transaction_datetime", "transaction_id");
            }

            // Update Location Products Ledger
            foreach (DataGridViewRow row in putaway_details_grid.Rows)
            {

                sql += "UPDATE LocationProductsLedger SET qty = qty - " + row.Cells["Quantity"].Value.ToString() + " WHERE location = '" + txtContainer.Text + "' AND product='" + row.Cells["product"].Value.ToString() + "' AND uom ='" + row.Cells["uom"].Value.ToString() + "' AND lot_no = '" + row.Cells["lot no"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "'";

                if (FAQ.IsNewLine(row.Cells["location"].Value.ToString(), row.Cells["product"].Value.ToString(), row.Cells["uom"].Value.ToString(), row.Cells["lot no"].Value.ToString(), row.Cells["expiry"].Value.ToString()))
                {
                    sql += "UPDATE LocationProductsLedger SET qty = qty + " + row.Cells["Quantity"].Value.ToString() + " WHERE location = '" + row.Cells["location"].Value.ToString() + "' AND product='" + row.Cells["product"].Value.ToString() + "' AND uom ='" + row.Cells["uom"].Value.ToString() + "' AND lot_no = '" + row.Cells["lot no"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "'";
                }
                else
                {
                    sql += DataSupport.GetInsert("LocationProductsLedger", Utils.ToDict(
                          "location", row.Cells["location"].Value.ToString()
                         , "product", row.Cells["product"].Value.ToString()
                         , "qty", row.Cells["Quantity"].Value.ToString()
                         , "uom", row.Cells["uom"].Value.ToString()
                         , "lot_no", row.Cells["lot no"].Value.ToString()
                         , "expiry", row.Cells["expiry"].Value.ToString()
                        ));
                }
            }

            foreach (DataGridViewRow row in returns_grid.Rows)
            {

                sql += "UPDATE LocationProductsLedger SET qty = qty - " + row.Cells["qty"].Value.ToString() + " WHERE location = '" + txtContainer.Text + "' AND product='" + row.Cells["product"].Value.ToString() + "' AND uom ='" + row.Cells["uom"].Value.ToString() + "' AND lot_no = '" + row.Cells["lot_no"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "'";

                if (FAQ.IsNewLine("STAGING-IN", row.Cells["product"].Value.ToString(), row.Cells["uom"].Value.ToString(), row.Cells["lot_no"].Value.ToString(), row.Cells["expiry"].Value.ToString()))
                {
                    sql += "UPDATE LocationProductsLedger SET qty = qty + " + row.Cells["qty"].Value.ToString() + " WHERE location = '" + "STAGING-IN" + "' AND product='" + row.Cells["product"].Value.ToString() + "' AND uom ='" + row.Cells["uom"].Value.ToString() + "' AND lot_no = '" + row.Cells["lot_no"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "'";
                }
                else
                {
                    sql += DataSupport.GetInsert("LocationProductsLedger", Utils.ToDict(
                          "location", "STAGING-IN"
                         , "product", row.Cells["product"].Value.ToString()
                         , "qty", row.Cells["qty"].Value.ToString()
                         , "uom", row.Cells["uom"].Value.ToString()
                         , "lot_no", row.Cells["lot_no"].Value.ToString()
                         , "expiry", row.Cells["expiry"].Value.ToString()
                        ));
                }
            }

            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("success");
            this.Close();
        }
    }
}
