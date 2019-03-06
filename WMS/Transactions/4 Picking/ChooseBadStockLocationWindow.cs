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
    public partial class ChooseBadStockLocationWindow : Form
    {
        public ChooseBadStockLocationWindow()
        {
            InitializeComponent();
        }

        private void ChooseBadStockLocationWindow_Load(object sender, EventArgs e)
        {
            DataTable locations_dt = DataSupport.RunDataSet("SELECT location_id[Location], Type FROM Locations WHERE type='STORAGE - BAD STOCKS'").Tables[0];
            var col = (DataGridViewComboBoxColumn)header_grid.Columns["bad_stock_location"];
            foreach (DataRow row in locations_dt.Rows)
                col.Items.Add(row["Location"].ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean is_incomplete = false;
            foreach (DataGridViewRow row in header_grid.Rows)
            {
                if (row.Cells["bad_stock_location"].Value == null)
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


                if (row.Cells["reason"].Value == null || row.Cells["reason"].Value.ToString().Trim() == "")
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
                MessageBox.Show("Must Tell Me Where you will put bad stocks and the reason");
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
