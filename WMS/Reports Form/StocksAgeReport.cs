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
    public partial class StocksAgeReport : Form
    {
        public StocksAgeReport()
        {
            InitializeComponent();
        }

        private void StocksAgeReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = DataSupport.RunDataSet(@"SELECT Location, Product, Uom, lot_no[Lot No],Qty, Expiry, ''[Days To Expiry],expiry_status
                            FROM LocationProductsLedger
                            WHERE  qty >0 AND location !='RELEASED'
                            ORDER BY expiry ").Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                DateTime expiry = DateTime.Parse(row["Expiry"].ToString());
                DateTime today = DateTime.Parse(DateTime.Now.ToShortDateString());
                var total_days = ((int)expiry.Subtract(today).TotalDays).ToString();

                if (double.Parse(total_days) <= 0)
                    total_days = "EXPIRED";

                if (row["expiry_status"].ToString() != "")
                    total_days = row["expiry_status"].ToString();


                row["Expiry"] = DateTime.Parse(row["Expiry"].ToString()).ToShortDateString();
                row["Days To Expiry"] = total_days;


            }
            dt.Columns.Remove("expiry_status");
            header_grid.DataSource = dt;
        }

        private void btnDeclareExpiredStocks_Click(object sender, EventArgs e)
        {
            var row = header_grid.SelectedRows[0];
            DataSupport.RunNonQuery(@" UPDATE LocationProductsLedger 
                                        SET expiry_status='NEAR EXPIRY' 
                                        WHERE location='" + row.Cells["Location"].Value.ToString() + @"' 
                                          AND product = '" + row.Cells["Product"].Value.ToString() + @"'
                                          AND uom = '" + row.Cells["Uom"].Value.ToString() + @"'
                                          AND lot_no = '" + row.Cells["Lot No"].Value.ToString() + @"'
                                          AND expiry = '" + row.Cells["Expiry"].Value.ToString() + @"'
                                        ");
            LoadData();
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            PrintDisposalPicklist dialog = new PrintDisposalPicklist();
            dialog.parent = this;
            if (dialog.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
            if (dialog.btnCancel.Visible == false)
                DialogResult = DialogResult.OK;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            DisposeExpiredStocksScanPicklistWindow dialog = new DisposeExpiredStocksScanPicklistWindow();
            dialog.ShowDialog();
        }
    }
}
