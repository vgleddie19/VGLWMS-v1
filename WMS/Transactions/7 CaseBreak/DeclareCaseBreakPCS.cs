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
    public partial class DeclareCaseBreakPCS : Form
    {
        public Dictionary<String, String> productsupportdetail = new Dictionary<String, String>();
        public  DeclareCaseBreakPicklistScanningWindow parent = null;

        int scanqty = 0;
        public DeclareCaseBreakPCS()
        {
            InitializeComponent();
        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataRow products_row = BarcodeSupport.GetProductFromBarcode(txtScan.Text);
                if (products_row == null)
                {
                    MessageBox.Show("Barcode Not Recognized!");
                    return;
                }
                if (products_row["product"].ToString() != lblProduct.Text)
                {
                    MessageBox.Show("Barcode Not Recognized!\nNot the same product ID");
                    return;
                }
                if (products_row["MATCHED_UOM"].ToString() != lblUOM.Text)
                {
                    MessageBox.Show("Barcode Not Recognized!\nPlease scan the requested UOM.");
                    return;
                }
                scanned_grid.Rows.Clear();
                scanqty += 1;
                scanned_grid.Rows.Add(products_row["product"], scanqty, products_row["MATCHED_UOM"], productsupportdetail["lotno"], productsupportdetail["expiry"], "STAGING IN");
            }
        }

        private void DeclareCaseBreakPCS_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            foreach (DataGridViewRow gRow in scanned_grid.Rows)
            {
                DataRow dRow = parent.casebreak_detailscan.NewRow();
                dRow["product"] = gRow.Cells[product.Name].Value;
                dRow["lotno"] = gRow.Cells[lot_no.Name].Value;
                dRow["expiry"] = gRow.Cells[expiry.Name].Value;
                dRow["location"] = gRow.Cells[location.Name].Value;
                dRow["uom"] = gRow.Cells[uom.Name].Value;
                dRow["qty"] = gRow.Cells[qty.Name].Value;

                parent.casebreak_detailscan.Rows.Add(dRow);
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
