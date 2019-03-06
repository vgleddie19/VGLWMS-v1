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
    public partial class NewBadStockDetailWindow : Form
    {
        public NewBadStockDetailWindow()
        {
            InitializeComponent();
        }

        private void NewBadStockDetailWindow_Load(object sender, EventArgs e)
        {
            {
                DataTable dt = DataSupport.RunDataSet("SELECT location_id FROM Locations WHERE type!='STORAGE - BAD STOCKS'").Tables[0];

                txtLocation.DataSource = dt;
                txtLocation.ValueMember = "location_id";
                txtLocation.DisplayMember = "location_id";
            }

            {
                DataTable dt = DataSupport.RunDataSet("SELECT location_id FROM Locations WHERE type='STORAGE - BAD STOCKS'").Tables[0];

                txtBadStockStorage.DataSource = dt;
                txtBadStockStorage.ValueMember = "location_id";
                txtBadStockStorage.DisplayMember = "location_id";
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            String location = txtLocation.Text;

            DataTable dt = DataSupport.RunDataSet(@"SELECT Product,(SELECT description FROM Products WHERE product_id = product)[Description], Qty, Uom, lot_no[Lot No], Expiry 
                                                    FROM LocationProductsLedger
                                                    WHERE location = '" + location+@"' 
                                                      AND qty >0").Tables[0];


            SelectGridWindow dialog = new SelectGridWindow();
            dialog.dataGridView1.DataSource = dt;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Enabled = false;
                var row = dialog.dataGridView1.SelectedRows[0];
                txtProduct.Text = row.Cells["Product"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                txtUom.Text = row.Cells["Uom"].Value.ToString();
                txtLotNo.Text = row.Cells["Lot No"].Value.ToString();
                txtExpiry.Text = DateTime.Parse( row.Cells["Expiry"].Value.ToString()).ToShortDateString();
            }




        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
