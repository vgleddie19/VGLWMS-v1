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
    public partial class NewPhysicalCountWindow : Form
    {
        public NewPhysicalCountWindow()
        {
            InitializeComponent();
        }

        private void NewPhysicalCountWindow_Load(object sender, EventArgs e)
        {
            txtYear.Text = DateTime.Now.Year.ToString();
            txtCycle.Value = decimal.Parse(DateTime.Now.Month.ToString());


            DataTable dt = DataSupport.RunDataSet(@"SELECT location_id, 
                                                               ISNULL((SELECT MAX(finished_on) 
                                                                        FROM PhysicalCounts INNER JOIN PhysicalCountDetails ON phcount_id = phcount 
                                                                        WHERE location = location_id),'N/A')[Last Counted On] 
                                                                , ISNULL((SELECT TOP 1 CAST (cycle AS VARCHAR) + '-' + CAST( cycle_year AS VARCHAR)
                                                                        FROM PhysicalCounts INNER JOIN PhysicalCountDetails ON phcount_id = phcount 
                                                                        WHERE location = location_id),'N/A')[Last Cycle] 
                                                                FROM Locations L WHERE type !='VIRTUAL'").Tables[0];

            foreach (DataRow row in dt.Rows)
                header_grid.Rows.Add(false, row[0].ToString(), row[1].ToString(), row[2].ToString());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (btnSelect.Text == "Select All")
            {
                header_grid.EndEdit();
                foreach (DataGridViewRow row in header_grid.Rows)
                    row.Cells[0].Value = true;

                btnSelect.Text = "Unselect All";
            }
            else
            {
                header_grid.EndEdit();
                foreach (DataGridViewRow row in header_grid.Rows)
                    row.Cells[0].Value = false;

                btnSelect.Text = "Select All";
            }
        }

        private void btnGenerateCountSheet_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (DataGridViewRow row in header_grid.Rows)
            {
                if ((bool)row.Cells[0].Value)
                { found = true; break; }
            }

            if (!found)
            {
                MessageBox.Show("Please select location to count!");
                return;
            }
            GenerateCountSheetWindow dialog = new GenerateCountSheetWindow();
            dialog.parent = this;
            dialog.ShowDialog();
            if (dialog.btnPrintPreview.Text == "Print")
                this.Close();
            
        }
    }
}
