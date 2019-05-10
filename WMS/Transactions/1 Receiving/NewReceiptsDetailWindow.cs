using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WMS
{
    public partial class NewReceiptsDetailWindow : Form
    {
        DataSet set = null;
        public NewReceiptsWindow parent = null;


        public NewReceiptsDetailWindow()
        {
            InitializeComponent();
        }


        private void LoadProducts()
        {
            String sql = @"SELECT *, product_id + ' - ' + description [display] FROM Products ORDER BY description ; SELECT * FROM ProductUOMs;";
            set = DataSupport.RunDataSet(sql);

            txtProducts.DataSource = set.Tables[0];
            txtProducts.DisplayMember = "description";
            txtProducts.ValueMember = "product_id";
        }


        private DataRow GetProductRow(String product_id)
        {
            foreach (DataRow row in set.Tables[0].Rows)
            {
                if (row["product_id"].ToString() == product_id)
                    return row;
            }
            return null;
        }


        private void SyncUOM()
        {
            String product = txtProducts.SelectedValue.ToString();
            DataRow product_row = GetProductRow(product);
            if (product_row == null)
                return;

            DataTable dt = new DataTable();
            dt.Columns.Add("key");
            dt.Columns.Add("value");


            dt.Rows.Add("CASES" + " (" + product_row["pcs_per_case"] + " PCS) ", "CASES");
            dt.Rows.Add("PCS" + " ( " + 1 + "  PCS) ", "PCS");


            foreach (DataRow row in set.Tables[1].Rows)
                if (product == row["product"].ToString())
                    dt.Rows.Add(row["uom"].ToString() + " (" + row["qty"] + " PCS) ", row["uom"].ToString());

            txtUOM.DataSource = dt;
            txtUOM.DisplayMember = "key";
            txtUOM.ValueMember = "value";



        }


        private void btnAdd_Click(object sender, EventArgs e)
        {


            if (txtLot.Text == "")
            {
                MessageBox.Show("Please Encode a Lot No");
                return;
            }

            String product = txtProducts.SelectedValue.ToString();
            DataRow product_row = GetProductRow(product);

            String product_id = product_row["product_id"].ToString();


            foreach (DataGridViewRow row in parent.headerGrid.Rows)
            {
                if (row.Cells["product_id"].Value.ToString() == product_id
                    && row.Cells["uom"].Value.ToString() == txtUOM.SelectedValue.ToString()
                    && row.Cells["lot"].Value.ToString() == txtLot.Text.ToString()
                    && row.Cells["remarks"].Value.ToString() == txtRemarks.Text.ToString()
                    && row.Cells["expiry"].Value.ToString() == txtExpiry.Value.ToShortDateString()
                    )
                {
                    row.Cells["quantity"].Value = int.Parse(row.Cells["quantity"].Value.ToString()) + int.Parse(txtQty.Text);


                    btnAdd.Enabled = false;
                    Thread.Sleep(500);
                    btnAdd.Enabled = true;
                    return;
                }
            }


            parent.headerGrid.Rows.Add(product_id, product_row["description"].ToString(), txtQty.Text, txtUOM.SelectedValue, txtLot.Text, txtExpiry.Value.ToShortDateString(), txtRemarks.Text);

            btnAdd.Enabled = false;
            Thread.Sleep(500);
            btnAdd.Enabled = true;
        }

        private void AddReceiptDetailsWindow_Load(object sender, EventArgs e)
        {
            LoadProducts();
            lblShowProduct_Click(null, null);
            txtProducts.Select();

            txtExpiry.Value = DateTime.Now.AddYears(1);
        }

        private void txtProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncUOM();
        }

        private void lblShowProduct_Click(object sender, EventArgs e)
        {
            if (lblShowProduct.Text == "Show IDs")
            {
                txtProducts.DisplayMember = "display";
                lblShowProduct.Text = "Hide IDs";
            }
            else
            {
                txtProducts.DisplayMember = "description";
                lblShowProduct.Text = "Show IDs";
            }
        }

        private void AddReceiptDetailsWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
