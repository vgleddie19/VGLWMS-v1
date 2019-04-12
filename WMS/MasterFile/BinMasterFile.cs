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
            foreach (DataRow drow in DataSupport.RunDataSet(@"SELECT [bin],[product],[uom],[min_qty][min],[max_qty][max] FROM [BinProducts]").Tables[0].Rows)
                grd.Rows.Add(drow["bin"], drow["product"], drow["uom"], drow["min"], drow["max"], "UPDATE");
        }

        private void grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grd.Columns["update"].Index)
            {
                addnewbin dialog = new addnewbin();
                dialog.ShowIcon = false;
                dialog.ShowInTaskbar = false;
                dialog.Icon = this.Icon;
                dialog.entrytype = "update";
                dialog.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addnewbin dialog = new addnewbin();
            dialog.ShowIcon = false;
            dialog.ShowInTaskbar = false;
            dialog.Icon = this.Icon;
            dialog.entrytype = "new";
            dialog.ShowDialog();
        }
    }
}
