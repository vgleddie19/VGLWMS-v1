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
    public partial class PhysicalCountCalendarReport : Form
    {
        public PhysicalCountCalendarReport()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            int cycle_days = int.Parse( txtCycleDays.Text);
            DataSet set = DataSupport.RunDataSet(@"SELECT * FROM locations; SELECT DISTINCT location, finished_on, cycle 
FROM PhysicalCounts INNER JOIN PhysicalCountDetails ON phcount = phcount_id
");
            DataTable locationsDT = set.Tables[0];
            DataTable physicalCountDT = set.Tables[1];

            header_grid.Columns.Clear();
            header_grid.Columns.Add("Location", "Location");
            header_grid.Columns.Add("Checked", "Checked Within "+cycle_days+" Day(s)? ");

            DateTime now = DateTime.Parse( DateTime.Now.ToShortDateString());
            DateTime start = now.AddDays(-1 * cycle_days);
            DateTime end = now.AddDays(cycle_days);

            for (DateTime i =  start; i <= end; i = i.AddDays(1))
            {
                var col = header_grid.Columns[ header_grid.Columns.Add(i.ToShortDateString(), i.ToShortDateString())];
                if(i==now)
                    col.DefaultCellStyle.BackColor = Color.Orange;
            }

            header_grid.Columns["Location"].Frozen = true;
            header_grid.Columns["Checked"].Frozen = true;

            foreach (DataRow row in locationsDT.Rows)
            {
                String location_id = row["location_id"].ToString();
                var new_row  = header_grid.Rows[ header_grid.Rows.Add(location_id)];
                Boolean within_cycle = false;

                for (int i = 2; i < header_grid.Columns.Count; i++)
                {
                    String datetime = DateTime.Parse(header_grid.Columns[i].HeaderText).ToShortDateString();
                    foreach (DataRow pc_row in physicalCountDT.Rows)
                    {

                        if (pc_row["finished_on"].ToString() == "")
                        {
                            MessageBox.Show("there is an ongoing physical count, please finish it first");
                            return;
                        }

                        if ( pc_row["location"].ToString() == location_id && DateTime.Parse( pc_row["finished_on"].ToString()).ToShortDateString()== datetime)
                        {
                            new_row.Cells[i].Value = pc_row["cycle"].ToString();
                            within_cycle = true;
                        }
                    }
                }
                if (within_cycle)
                {
                    new_row.Cells[1].Value = "YES";
                    new_row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else
                {
                    new_row.Cells[1].Value = "NO";

                }


                
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPhysicalCountReport dialog = new PrintPhysicalCountReport();
            dialog.parent = this;
            dialog.ShowDialog();
        }
    }
}
