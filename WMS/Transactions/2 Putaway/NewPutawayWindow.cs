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
    public partial class NewPutawayWindow : Form
    {
        public NewPutawayWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLocation.Text == "")
            {
                MessageBox.Show("Please Encode Location");
                return;
            }

            NewPutawayDetailWindow dialog = new NewPutawayDetailWindow();
            dialog.header_grid = this.headerGrid;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var row = dialog.product_row;
            var lot_row = dialog.lot_row;

            foreach (DataGridViewRow ui_row in headerGrid.Rows)
            {
                if (ui_row.Cells[product.Name].Value.ToString() == row["PRODUCT"].ToString()
                 && ui_row.Cells[uom.Name].Value.ToString() == row["MATCHED_UOM"].ToString()
                 && ui_row.Cells[lot.Name].Value.ToString() == lot_row.Cells["lot_no"].Value.ToString()
                 && ui_row.Cells[expiry.Name].Value.ToString() == lot_row.Cells["expiry"].Value.ToString()
                    )
                {
                    ui_row.Cells[Quantity.Name].Value = int.Parse(ui_row.Cells[Quantity.Name].Value.ToString()) + 1;

                    return;
                }
            }


            headerGrid.Rows.Add(row["PRODUCT"].ToString(), "1", row["MATCHED_UOM"].ToString(), lot_row.Cells["lot_no"].Value.ToString(), lot_row.Cells["expiry"].Value.ToString(), txtLocation.Text);
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            NewPutawaySplitLocationWindow dialog = new NewPutawaySplitLocationWindow();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            DataGridViewRow old_row = headerGrid.SelectedRows[0];
            
            var old_value = int.Parse(old_row.Cells[Quantity.Name].Value.ToString()) - int.Parse(dialog.txtQty.Text);
            if (old_value <= 0)
            {
                MessageBox.Show("Can't split more than total quantity");
                return;
            }


            old_row.Cells[Quantity.Name].Value = old_value;

            headerGrid.Rows.Add(old_row.Cells[product.Name].Value, dialog.txtQty.Text, old_row.Cells[uom.Name].Value, old_row.Cells[lot.Name].Value, old_row.Cells[expiry.Name].Value, dialog.txtLocation.Text);

        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            
            NewPutawayConfirmationWindow dialog = new NewPutawayConfirmationWindow();
            dialog.parent = this;
            if (dialog.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
            if(dialog.btnCancel.Visible == false)
                DialogResult = DialogResult.OK;
        }

        private void NewPutawayWindow_Load(object sender, EventArgs e)
        {
            var dt = FAQ.GetLocations();
            txtLocation.Items.Clear();
            foreach (DataRow row in dt.Rows)
                if (row["location_id"].ToString() != "STAGING-IN")
                    txtLocation.Items.Add(row["location_id"].ToString());

            dt = FAQ.GetRecord("SELECT * FROM containers");
            cboContainer.DataSource = dt;
            cboContainer.DisplayMember = "type";
            cboContainer.ValueMember = "container_id";
            cboContainer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboContainer.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (dt.Rows.Count != 0)
                cboContainer.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var row = headerGrid.SelectedRows[0];
            headerGrid.Rows.Remove(row);
        }
    }
}
