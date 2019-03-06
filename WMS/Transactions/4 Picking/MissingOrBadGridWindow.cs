using Framework;
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
    public partial class MissingOrBadGridWindow : Form
    {
        public MissingOrBadGridWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean is_incomplete = false;
            foreach (DataGridViewRow row in header_grid.Rows)
            {
                if (row.Cells["what_happened"].Value == null)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    is_incomplete = true;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            if (is_incomplete)
            {
                MessageBox.Show("Must Tell Me what happened");
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
        private void MissingOrBadGridWindow_Load(object sender, EventArgs e)
        {
            
           
        }
    }
}
