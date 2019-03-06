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
    public partial class AuthenticationForm : Form
    {
        public AuthenticationForm()
        {
            InitializeComponent();
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {

        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtpassword.Text.Trim().Length >= 6)
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Incorrect Password!");

                this.Close();
            }

        }
    }
}
