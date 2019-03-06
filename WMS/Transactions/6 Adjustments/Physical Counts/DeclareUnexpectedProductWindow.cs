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
    public partial class DeclareUnexpectedProductWindow : Form
    {
        public DeclareUnexpectedProductWindow()
        {
            InitializeComponent();
        }
        public String product;
        public String uom;
        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var product_row =  BarcodeSupport.GetProductFromBarcode(txtScan.Text);
                if (product_row == null)
                {
                    MessageBox.Show("Barcode not recognized");
                    return;
                }

                product = product_row["PRODUCT"].ToString();
                uom = product_row["MATCHED_UOM"].ToString();

                DialogResult = DialogResult.OK;
            }
        }
    }
}
