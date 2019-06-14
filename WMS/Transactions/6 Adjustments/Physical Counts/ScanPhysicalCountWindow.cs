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
    public partial class ScanPhysicalCountWindow : Form
    {
        public ScanPhysicalCountWindow()
        {
            InitializeComponent();
            txtScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(KeyBoardSupport.ForAlhpaNumericUpper_KeyPress);
        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String phcount_id = txtScan.Text;
                if (!FAQ.DoesPhysicalCountExist(phcount_id))
                {
                    MessageBox.Show("Barcode not recognized");
                    return;
                }

                DeclarePhysicalCountWindow dialog = new DeclarePhysicalCountWindow();
                dialog.phcount_id = phcount_id;
                dialog.ShowDialog();
                this.Close();
            }
        }
    }
}
