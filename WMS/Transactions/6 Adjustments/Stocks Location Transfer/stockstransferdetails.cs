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
    public partial class stockstransferdetails : Form
    {
        public newstocklocationtransfers parent = null;
        public Dictionary<String, String> products_to_transfer = null;
        public stockstransferdetails()
        {
            InitializeComponent();
            txtScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(KeyBoardSupport.ForAlhpaNumericUpper_KeyPress);
        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==  Keys.Enter)
            {
                var product = BarcodeSupport.GetProductFromBarcode(txtScan.Text);
                if (product == null)
                {
                    MessageBox.Show("Barcode not recognized");
                    return;
                }
                if (products_to_transfer.ContainsKey(String.Format("{0}{1}",product["PRODUCT"].ToString(), product["MATCHED_UOM"].ToString())))
                {

                    // If it's recognized, get staging area items
                    DataTable dt = DataSupport.RunDataSet("SELECT product,UOM,lot_no,Expiry,qty FROM LocationProductsLedger WHERE location = '"+ parent.txtLocation.Text +"' AND product = '" + product["PRODUCT"] + "' AND uom = '" + product["MATCHED_UOM"] + "' AND qty > 0").Tables[0];

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Item is not declared in the "+ parent.txtLocation.Text +" area");
                        return;
                    }

                    List<DataRow> for_deletion = new List<DataRow>();
                    foreach (DataRow row in dt.Rows)
                    {
                        row["expiry"] = DateTime.Parse(row["expiry"].ToString()).ToShortDateString();
                        foreach (DataGridViewRow existing_row in parent.grd.Rows)
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

                    var lot_row = dialog.dataGridView1.SelectedRows[0];
                    //DialogResult = DialogResult.OK;



                    foreach (DataGridViewRow ui_row in parent.grd.Rows)
                    {
                        if (ui_row.Cells["product"].Value.ToString() == product["PRODUCT"].ToString()
                         && ui_row.Cells["uom"].Value.ToString() == product["MATCHED_UOM"].ToString()
                         && ui_row.Cells["lot"].Value.ToString() == lot_row.Cells["lot_no"].Value.ToString()
                         && ui_row.Cells["expiry"].Value.ToString() == lot_row.Cells["expiry"].Value.ToString()
                            )
                        {
                            ui_row.Cells["Quantity"].Value = int.Parse(ui_row.Cells["Quantity"].Value.ToString()) + 1;
                            return;
                        }
                    }

                    parent.grd.Rows.Add(product["PRODUCT"].ToString(), DataSupport.RunDataSet("SELECT top 1 description FROM Products WHERE product_id = '" + product["PRODUCT"].ToString() + "'").Tables[0].Rows[0]["description"], "1", product["MATCHED_UOM"].ToString(), lot_row.Cells["lot_no"].Value.ToString(), lot_row.Cells["expiry"].Value.ToString(), txtLocation.Text);
                }
                else
                    MessageBox.Show(String.Format("Product {0}  with uom {1} is not found in location {2}", product["PRODUCT"].ToString(), product["MATCHED_UOM"].ToString(), parent.txtLocation.Text));
            }
        }

        private void stockstransferdetails_Load(object sender, EventArgs e)
        {
            var dt = FAQ.GetLocations();
            txtLocation.Items.Clear();
            foreach (DataRow row in dt.Rows)
                if (row["TYPE"].ToString() != "PROCESSING" && row["location_id"].ToString() != parent.txtLocation.Text)
                    txtLocation.Items.Add(row["location_id"].ToString());
        }

    }
}
