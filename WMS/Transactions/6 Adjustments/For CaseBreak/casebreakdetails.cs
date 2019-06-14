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
    public partial class casebreakdetails : Form
    {
        public NewCaseBreak parent = null;
        bool isadd = false;
        public casebreakdetails()
        {
            InitializeComponent();
        }

        private void casebreakdetails_Load(object sender, EventArgs e)
        {
            var dt = FAQ.GetLocations();
            txtLocation.Items.Clear();
            foreach (DataRow row in dt.Rows)
                if (row["TYPE"].ToString() != "PROCESSING")
                    txtLocation.Items.Add(row["location_id"].ToString());
        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var product = BarcodeSupport.GetProductFromBarcode(txtScan.Text);
                if (product == null && product["MATCHED_UOM"].ToString() != "CS")
                {
                    MessageBox.Show("Barcode not recognized");
                    return;
                }
                

                // If it's recognized, get staging area items
                DataTable dt = DataSupport.RunDataSet("SELECT location,product,uom,lot_no,expiry,qty FROM LocationProductsLedger WHERE  product = '" + product["PRODUCT"] + "' AND uom = '" + product["MATCHED_UOM"] + "' AND qty > 0").Tables[0];

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No inventory found!");
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
                            MessageBox.Show("Items is already scanned");
                            return;
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
                label4.Text = lot_row.Cells["qty"].Value.ToString();
                txtLocation.Text = lot_row.Cells["location"].Value.ToString();


                parent.grd.Rows.Add(product["PRODUCT"].ToString()
                , DataSupport.RunDataSet("SELECT top 1 description FROM Products WHERE product_id = '" + product["PRODUCT"].ToString() + "'").Tables[0].Rows[0]["description"]
                , product["MATCHED_UOM"].ToString()
                , lot_row.Cells["lot_no"].Value.ToString()
                , lot_row.Cells["expiry"].Value.ToString()
                , lot_row.Cells["location"].Value.ToString()
                , lot_row.Cells["qty"].Value.ToString()
                , lot_row.Cells["location"].Value.ToString()
                , 0);

                isadd = true;                
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (txtQty.Text.Trim().Length >= 1)
            {
                if (int.Parse(txtQty.Text) > int.Parse(label4.Text))
                {
                    MessageBox.Show("Must be lesser that the location available qty!");
                    return;
                }
                if (parent.grd.Rows.Count >= 1)
                {
                    parent.grd.Rows[parent.grd.Rows.Count - 1].Cells["transfer_qty"].Value = FAQ.HowManyPiecesInUOM(parent.grd.Rows[parent.grd.Rows.Count - 1].Cells["product"].Value.ToString(), parent.grd.Rows[parent.grd.Rows.Count - 1].Cells["uom"].Value.ToString(), int.Parse(txtQty.Text));
                    parent.grd.Rows[parent.grd.Rows.Count - 1].Cells["translocation"].Value = txtLocation.Text;
                }
                this.Close();
            }                       
            //else

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isadd)
            {
                parent.grd.Rows.Remove(parent.grd.Rows[parent.grd.Rows.Count - 1]);
                this.Close();
            }
            else
                this.Close();
        }
    }
}
