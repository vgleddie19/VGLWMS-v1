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
    public partial class DisposeExpiredStocksScanningWindow : Form
    {

        public DisposeExpiredStocksScanningWindow()
        {
            InitializeComponent();
        }

        private void txtScan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (   txtReleaseTo.Text.Trim() == ""
                    || txtReleaseToPerson.Text.Trim() == ""
                    || txtTripReference.Text.Trim() == ""
                    )
                {


                    MessageBox.Show("Fill out details first");
                    txtScan.Text = "";
                    return;
                }


                var product_row = BarcodeSupport.GetProductFromBarcode(txtScan.Text);
                if (product_row == null)
                {
                    MessageBox.Show("Barcode Not Recognized");
                    return;
                }
                String product = product_row["PRODUCT"].ToString();
                String uom = product_row["MATCHED_UOM"].ToString();

                DataTable dt = DataSupport.RunDataSet("SELECT Product,Uom, lot_no[Lot No],Expiry, Qty FROM ForDisposals WHERE trans_id = @picklist_id AND product=@product AND @uom = @uom", "picklist_id", txtPicklistID.Text, "product", product, "uom", uom).Tables[0];

                SelectGridWindow dialog = new SelectGridWindow();
                dialog.dataGridView1.DataSource = dt;
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                var selected_row = dialog.dataGridView1.SelectedRows[0];

                String expiry = selected_row.Cells["Expiry"].Value.ToString();
                String lot_no = selected_row.Cells["Lot No"].Value.ToString();

                List<DataGridViewRow> for_transfer = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in for_scanning_grid.Rows)
                {
                    if (row.Cells["Product"].Value.ToString().ToUpper() == product.ToUpper()
                      && row.Cells["Uom"].Value.ToString().ToUpper() == uom.ToUpper()
                      && row.Cells["Expiry"].Value.ToString().ToUpper() == expiry.ToUpper()
                      && row.Cells["Lot No"].Value.ToString().ToUpper() == lot_no.ToUpper()
                        )
                    {
                        for_transfer.Add(row);
                    }
                }

                foreach (DataGridViewRow row in for_transfer)
                {
                    List<Object> list = new List<object>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        list.Add(cell.Value.ToString());
                    }

                    scanned_grid.Rows.Add(list.ToArray());

                    for_scanning_grid.Rows.Remove(row);
                }

            }
        }

        private void DisposeExpiredStocksScanningWindow_Load(object sender, EventArgs e)
        {
            txtScan.Focus();
            LoadData();
        }

        private void LoadData()
        {
            {
                var dt = DataSupport.RunDataSet(@"SELECT 
                                                        (
	                                                        SELECT  TOP 1 R.received_from 
	                                                        FROM Receipts R
	                                                        INNER JOIN ReceiptDetails RD ON RD.receipt = R.receipt_id
	                                                        WHERE D.product = RD.product
	                                                          AND D.uom = RD.uom
	                                                          AND D.lot_no = RD.lot_no
	                                                          AND D.expiry = RD.expiry
                                                        )
                                                        [Client],
                                                        D.Product,D.Uom, D.lot_no[Lot No],D.Expiry, D.Qty 
                                                        FROM ForDisposals D
                                                        WHERE D.trans_id = '" + txtPicklistID.Text+"'").Tables[0];
                for_scanning_grid.DataSource = dt;
            }

          
        }
    }
}
