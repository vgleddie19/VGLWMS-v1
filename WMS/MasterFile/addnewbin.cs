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
    public partial class addnewbin : Form
    {
        public String entrytype = null;
        public String bin_id = null;
        public addnewbin()
        {
            InitializeComponent();
        }

        private void addnewbin_Load(object sender, EventArgs e)
        {
            if(entrytype =="update")
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            foreach (DataRow drow in DataSupport.RunDataSet(@"SELECT [bin],[product],[uom],[min_qty][min],[max_qty][max] FROM [BinProducts] WHERE bin = '" + txtbin_id.Text  + "'").Tables[0].Rows)
            {
                txtbin_id.Text = drow["bin"].ToString();
                txtProducts.Text = drow["product"].ToString();
                txtUOM.Text = drow["uom"].ToString();
                txtmin_qty.Text = drow["min"].ToString();
                txtmax_qty.Text = drow["max"].ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            if (entrytype == "update")
            {
                sql.Append(DataSupport.GetUpdate("[BinProducts]", Utils.ToDict(
                "bin", txtbin_id.Text
               , "uom", txtUOM.Text
               , "min_qty", txtmin_qty.Text
               , "max_qty", txtmax_qty.Text
                ),new List<string> { "bin" }));
            }
            else
            {
                sql.Append(DataSupport.GetInsert("[Locations]", Utils.ToDict(
                "location_id", txtbin_id.Text
               , "description", txtbin_id.Text
               , "type", "BIN"
               , "status", "ACTIVE"
                )));

                sql.Append(DataSupport.GetInsert("[BinProducts]", Utils.ToDict(
                                "bin", txtbin_id.Text
                               , "uom", txtUOM.Text
                               , "min_qty", txtmin_qty.Text
                               , "max_qty", txtmax_qty.Text
                                )));
            }
        }
    }
}
