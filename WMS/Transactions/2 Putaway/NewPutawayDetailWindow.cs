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
    public partial class NewPutawayDetailWindow : Form
    {
        public NewPutawayDetailWindow()
        {
            InitializeComponent();
        }

        private void txtContainer_TextChanged(object sender, EventArgs e)
        {

        }

        public DataRow product_row = null;
        public DataGridViewRow lot_row = null;

        public DataGridView header_grid = null;

        private void txtContainer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Check if the barcode is recognized
                product_row = BarcodeSupport.GetProductFromBarcode(txtContainer.Text);
                if (product_row == null)
                {
                    MessageBox.Show("Barcode not recognized");
                    return;
                }

                // If it's recognized, get staging area items
                DataTable dt = DataSupport.RunDataSet("SELECT * FROM LocationProductsLedger WHERE location = 'STAGING-IN' AND product = '" + product_row["PRODUCT"] + "' AND uom = '" + product_row["MATCHED_UOM"] + "' AND qty > 0").Tables[0];

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Item is not declared in the STAGING-IN area");
                    return;
                }

                List<DataRow> for_deletion = new List<DataRow>();
                foreach (DataRow row in dt.Rows)
                {
                    row["expiry"] = DateTime.Parse(row["expiry"].ToString()).ToShortDateString();
                    foreach (DataGridViewRow existing_row in header_grid.Rows)
                    {
                        if (
                           existing_row.Cells["product"].Value.ToString() == row["product"].ToString()
                        && existing_row.Cells["uom"].Value.ToString() == row["uom"].ToString()
                        && existing_row.Cells["lot"].Value.ToString() == row["lot_no"].ToString()
                        && existing_row.Cells["expiry"].Value.ToString() == row["expiry"].ToString()
                        )
                        {
                            int qty = int.Parse(existing_row.Cells["Quantity"].Value.ToString());
                            var new_qty = int.Parse(row["qty"].ToString()) - qty;
                            row["qty"] = new_qty;
                            if (new_qty <= 0)
                                for_deletion.Add(row);
                        }
                    }
                }
                foreach (DataRow row in for_deletion)
                {
                    dt.Rows.Remove(row);
                }


                // Ask which of the staging area items
                SelectGridWindow dialog = new SelectGridWindow();
                dialog.dataGridView1.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Items is already scanned in the STAGING-IN area");
                    return;
                }
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                lot_row = dialog.dataGridView1.SelectedRows[0];
                DialogResult = DialogResult.OK;
            }
        }

        private void NewPutawayDetailWindow_Load(object sender, EventArgs e)
        {
            txtContainer.Select();
        }
    }
}
