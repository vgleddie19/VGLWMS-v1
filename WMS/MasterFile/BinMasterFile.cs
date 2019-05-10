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
    public partial class BinMasterFile : Form
    {
        public BinMasterFile()
        {
            InitializeComponent();
        }

        private void BinMasterFile_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            grd.Rows.Clear();
            foreach (DataRow drow in DataSupport.RunDataSet(@"SELECT [location],[product],[uom],[min_qty][min],[max_qty][max] FROM [BinProducts]").Tables[0].Rows)
                grd.Rows.Add(drow["location"], drow["product"], drow["uom"], drow["min"], drow["max"], "UPDATE");
        }

        private void grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grd.Columns["update"].Index)
            {
                addnewbin dialog = new addnewbin();
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowIcon = false;
                dialog.ShowInTaskbar = false;
                dialog.Icon = this.Icon;
                dialog.entrytype = "update";
                dialog.bin_id = grd.Rows[e.RowIndex].Cells[bin.Name].Value.ToString();
               dialog.ShowDialog();
                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addnewbin dialog = new addnewbin();
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowIcon = false;
            dialog.ShowInTaskbar = false;
            dialog.Icon = this.Icon;
            dialog.entrytype = "new";
            if (dialog.ShowDialog() == DialogResult.OK) 
                LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grd.Rows.Count >= 1)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(DataSupport.GetDelete("[BinProductLedger]", Utils.ToDictionary("location", grd.CurrentRow.Cells[bin.Name].Value.ToString())));
                sql.Append(DataSupport.GetDelete("[BinProducts]", Utils.ToDictionary("location", grd.CurrentRow.Cells[bin.Name].Value.ToString())));
                sql.Append(DataSupport.GetDelete("[Locations]", Utils.ToDictionary("location_id", grd.CurrentRow.Cells[bin.Name].Value.ToString())));


                DataSupport.RunNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);
                LoadData();
            }
        }
    }
}
