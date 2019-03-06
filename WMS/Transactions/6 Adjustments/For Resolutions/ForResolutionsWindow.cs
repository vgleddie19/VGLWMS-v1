using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework;

namespace WMS
{
    public partial class ForResolutionsWindow : Form
    {
        public ForResolutionsWindow()
        {
            InitializeComponent();
        }

        private void ForResolutionsWindow_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            DataTable dt = DataSupport.RunDataSet(@"SELECT *
                                                    FROM
                                                    (
                                                        SELECT trans_source[Trans], trans_id[Id],line[Line], detected_on[Detected], product[Product], uom[Uom], lot_no[Lot No], expiry[Expiry], location[Location] 
                                                        ,variance_type[Type], variance_qty [Qty]
                                                        ,variance_qty - ISNULL((SELECT SUM(qty_resolved) FROM Resolutions B WHERE A.trans_id = B.trans_id AND A.trans_source = B.trans_source AND A.line = B.line ),0)[Unresolved Qty]
                                                        FROM ForResolutions A
                                                        WHERE status = 'FOR RESOLUTION'
                                                    ) T 
                                                    WHERE [Unresolved Qty] >0 OR [Detected] >='" + DateTime.Now.AddMonths(-2) + "' ").Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                row["Expiry"] = DateTime.Parse(row["Expiry"].ToString()).ToShortDateString();
            }
            header_grid.DataSource = dt;

            foreach (DataGridViewRow row in header_grid.Rows)
            {
                if (row.Cells["Unresolved Qty"].Value.ToString() == "0")
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void btnResolutions_Click(object sender, EventArgs e)
        {
           var selected_row = header_grid.SelectedRows[0];

            ResolutionsWindow dialog = new ResolutionsWindow();
            dialog.product_row = selected_row;
            dialog.ShowDialog();
            LoadData();

        }
    }
}
