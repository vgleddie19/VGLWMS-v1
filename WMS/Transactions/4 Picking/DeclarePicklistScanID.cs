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
    public partial class DeclarePicklistScanID : Form
    {
        public DeclarePicklistScanID()
        {
            InitializeComponent();
            txtPicklistCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(KeyBoardSupport.ForAlhpaNumericUpper_KeyPress);
        }

        private void txtPicklistCode_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!FAQ.DoesPicklistExist(txtPicklistCode.Text))
                {
                    MessageBox.Show("Barcode Not Recognized");
                    return;
                }

                DeclarePicklistScanningWindow dialog = new DeclarePicklistScanningWindow();
                dialog.txtPicklist.Text = txtPicklistCode.Text;
                dialog.ShowDialog();
                this.Close();
            }
        }
    }
}
