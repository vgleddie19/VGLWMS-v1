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
    public partial class DeclareBadStockWindow : Form
    {
        public DeclareBadStockWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewBadStockWindow dialog = new NewBadStockWindow();
            dialog.ShowDialog();
            DeclareBadStockWindow_Load(null, null);
        }

        private void DeclareBadStockWindow_Load(object sender, EventArgs e)
        {
            DataTable dt = DataSupport.RunDataSet(@"SELECT Declaration_id [Declaration ID], declared_by [Declared By], declared_on[Declared On], '' [Days Ago], Status FROM BadStockDeclarations").Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                DateTime declared_on= DateTime.Parse(row["Declared On"].ToString());

                row["Declared On"] = declared_on.ToShortDateString();
                row["Days Ago"] = DateTime.Now.Subtract(declared_on).Days;

            }
            header_grid.DataSource = dt;
        }
    }
}
