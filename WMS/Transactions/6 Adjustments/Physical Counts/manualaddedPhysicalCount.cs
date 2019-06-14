using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class manualaddedPhysicalCount : Form
    {
        public manualaddedPhysicalCount()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLot.Text.Trim().Length >= 0)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("You forgot to encode Lot Number!");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
