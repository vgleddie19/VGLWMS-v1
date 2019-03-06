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
    public partial class NewBadStockWindow : Form
    {
        public NewBadStockWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewBadStockDetailWindow dialog = new NewBadStockDetailWindow();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var new_row = header_grid.Rows.Add(dialog.txtLocation.Text, dialog.txtProduct.Text, dialog.txtUom.Text, dialog.txtLotNo.Text, dialog.txtExpiry.Text, dialog.txtQty.Text, dialog.txtReason.Text, dialog.txtBadStockStorage.Text);
            }

        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            ConfirmBadStocksWindow dialog = new ConfirmBadStocksWindow();
            dialog.parent = this;
            dialog.ShowDialog();
            if (dialog.btnPrintPreview.Text == "Print")
                this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            header_grid.Rows.Remove(header_grid.SelectedRows[0]);
        }
    }
}
