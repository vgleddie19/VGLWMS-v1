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
    public partial class DeclarePutawayScanContainerWindow : Form
    {
        public String container = null;
        public String putaway_id = null;

        public DeclarePutawayScanContainerWindow()
        {
            InitializeComponent();
            txtContainer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(KeyBoardSupport.ForAlhpaNumericUpper_KeyPress);
        }

        private void txtPutawayCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (container != txtContainer.Text.ToUpper())
                {
                    MessageBox.Show("Container does not match");
                    return;
                }
                DeclareCompleteOptions dialog = new DeclareCompleteOptions();
                dialog.txtPutawayID.Text = putaway_id;
                dialog.txtContainer.Text = container;
                this.Visible = false;
                dialog.ShowDialog();
                this.Close();
            }
        }

        private void txtContainer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
