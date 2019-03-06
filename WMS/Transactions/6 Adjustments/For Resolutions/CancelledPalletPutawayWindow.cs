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
    public partial class CancelledPalletPutawayWindow : Form
    {
        public CancelledPalletPutawayWindow()
        {
            InitializeComponent();
        }

        private void CancelledPalletPutawayWindow_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = DataSupport.RunDataSet("SELECT Product, Uom, lot_no[Lot No], Expiry, Qty,''[Putaway To] FROM LocationProductsLedger WHERE location = 'CANCELLED_PALLET'").Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                row["Expiry"] = DateTime.Parse(row["Expiry"].ToString()).ToShortDateString();
            }
            items_grid.Columns.Clear();
            items_grid.DataSource = dt;
        }

        private void btnChangeLocation_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = items_grid.SelectedRows[0];

            DataTable dt = DataSupport.RunDataSet(@"SELECT location_id[Location], ISNULL((
	                                                                SELECT qty FROM LocationProductsLedger
	                                                                WHERE location = location_id
	                                                                      AND product = '" + row.Cells["Product"].Value.ToString() + @"'
		                                                                  AND uom = '" + row.Cells["Uom"].Value.ToString() + @"'
		                                                                  AND lot_no = '" + row.Cells["Lot No"].Value.ToString() + @"'
		                                                                  and expiry='" + row.Cells["Expiry"].Value.ToString() + @"'
                                                                ),0)[Qty]
                                                                FROM Locations        
                                                                WHERE type = 'STORAGE' 
                                                
                                                        ").Tables[0];
            SelectGridWindow dialog = new SelectGridWindow();
            dialog.dataGridView1.DataSource = dt;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                row.Cells["Putaway To"].Value = dialog.dataGridView1.SelectedRows[0].Cells["Location"].Value.ToString();
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

            CancelledPutawayConfirmationWindow dialog = new CancelledPutawayConfirmationWindow();
            dialog.parent = this;
            if (dialog.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
            if (dialog.btnCancel.Visible == false)
                DialogResult = DialogResult.OK;
        }
    }
}
