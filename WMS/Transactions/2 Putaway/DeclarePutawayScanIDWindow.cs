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
    public partial class DeclarePutawayScanIDWindow : Form
    {
        public DeclarePutawayScanIDWindow()
        {
            InitializeComponent();
            txtPutawayCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(KeyBoardSupport.ForAlhpaNumericUpper_KeyPress);
        }

        private void txtPutawayCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String container = FAQ.GetContainer(txtPutawayCode.Text);
                if (container == null)
                {
                    MessageBox.Show("Barcode not recognized");
                    return;
                }

                // DeclareCompleteOptions dialog = new DeclareCompleteOptions();
                // dialog.txtPutawayID.Text = txtPutawayCode.Text;
                // dialog.txtContainer.Text = container;

                //DeclarePutawayScanContainerWindow dialog = new DeclarePutawayScanContainerWindow();
                //dialog.putaway_id = this.txtPutawayCode.Text;
                //dialog.container = container;
                //dialog.ShowDialog();
                //this.Close();

                DeclareCompleteOptions dialog = new DeclareCompleteOptions();
                dialog.txtPutawayID.Text = txtPutawayCode.Text;
                dialog.txtContainer.Text = container;
                this.Visible = false;
                dialog.ShowDialog();
                this.Close();
            }
        }
    }
}
