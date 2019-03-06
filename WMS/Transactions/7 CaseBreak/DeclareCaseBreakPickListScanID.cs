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
    public partial class DeclareCaseBreakPickListScanID : Form
    {

        public DeclareCaseBreakPickListScanID()
        {
            InitializeComponent();
        }

        private void txtPicklistCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!FAQ.DoesCaseBreakExist(txtPicklistCode.Text))
                {
                    MessageBox.Show("Barcode Not Recognized");
                    return;
                }
                DeclareCaseBreakPicklistScanningWindow dialog = new DeclareCaseBreakPicklistScanningWindow();
                dialog.txtPicklist.Text = txtPicklistCode.Text;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
