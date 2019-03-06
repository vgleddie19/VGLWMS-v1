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
    public partial class ResolveWindow : Form
    {

        public ResolutionsWindow parent = null;

        public ResolveWindow()
        {
            InitializeComponent();
        }

        private void ResolveWindow_Load(object sender, EventArgs e)
        {
            txtUnresolvedQty.Text = parent.txtUnresolvedQty.Text;

        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            ConfirmResolveWindow dialog = new ConfirmResolveWindow();
            dialog.parent = this;
            dialog.ShowDialog();
            DialogResult = DialogResult.OK;
        }
    }
}
