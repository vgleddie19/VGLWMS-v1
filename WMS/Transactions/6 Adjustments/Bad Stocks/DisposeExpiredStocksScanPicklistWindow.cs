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
    public partial class DisposeExpiredStocksScanPicklistWindow : Form
    {
        public DisposeExpiredStocksScanPicklistWindow()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String txt = txtScan.Text.Replace("'", "");

                if (!FAQ.IsPicklistForDisposal(txt))
                {
                    MessageBox.Show("Picklist is not recognized");
                    txtScan.Text = "";
                    return;
                }

                DisposeExpiredStocksScanningWindow dialog = new DisposeExpiredStocksScanningWindow();
                dialog.txtPicklistID.Text = txt;
                this.Visible = false;
                dialog.ShowDialog();
                this.Close();
            }
        }
    }
}
