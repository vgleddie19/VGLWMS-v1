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
    public partial class ResolutionsWindow : Form
    {
        public ResolutionsWindow()
        {
            InitializeComponent();
        }


        public DataGridViewRow product_row = null;
        private void ResolutionsWindow_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            txtProduct.Text = product_row.Cells["Product"].Value.ToString();
            txtUom.Text = product_row.Cells["Uom"].Value.ToString();
            txtLotNo.Text = product_row.Cells["Lot No"].Value.ToString();
            txtExpiry.Text = DateTime.Parse(product_row.Cells["Expiry"].Value.ToString()).ToShortDateString();
            txtLocation.Text = product_row.Cells["Location"].Value.ToString();

            txtSource.Text = product_row.Cells["Id"].Value.ToString();
            txtDetected.Text = DateTime.Parse(product_row.Cells["Detected"].Value.ToString()).ToShortDateString();
            txtVarianceType.Text = product_row.Cells["Type"].Value.ToString();
            txtUnresolvedQty.Text = product_row.Cells["Unresolved Qty"].Value.ToString();



            String trans_source = product_row.Cells["Trans"].Value.ToString();
            String trans_id = product_row.Cells["Id"].Value.ToString();
            String line = product_row.Cells["Line"].Value.ToString();

            DataTable dt = DataSupport.RunDataSet(@"SELECT qty_resolved [Qty Resolved],resolved_on[Resolved On], resolved_by[Resolved By], charge_to[Charge To], Explanation 
                                                    FROM Resolutions
                                                    WHERE trans_source = '" + trans_source + @"'
                                                      AND trans_id = '" + trans_id + @"'
                                                      AND line = '" + line + @"'").Tables[0];
            header_grid.DataSource = dt;
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            ResolveWindow dialog = new ResolveWindow();
            dialog.parent = this;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadData();
               
            }
        }
    }
}
