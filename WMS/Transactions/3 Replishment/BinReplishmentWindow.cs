using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.Utilities;

namespace WMS
{
    public partial class BinReplishmentWindow : Form
    {
        public BinReplishmentWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GenerateBinReplenishPicklist dialog = new GenerateBinReplenishPicklist();
            dialog.Icon = this.Icon;
            dialog.ShowDialog();
        }

        private void BinReplishmentWindow_Load(object sender, EventArgs e)
        {
            DataTable dt = DataSupport.RunDataSet("SELECT order_id[ORDER ID], client[CLIENT], reference[DOCUMENT REF ID], recipient[RECIPIENT], 'NO' [ADDED]  FROM ReleaseOrders WHERE status = 'FOR PICKING' ORDER BY order_date ASC").Tables[0];
            headerGrid.SetGridAppearance();
            headerGrid.DataSource = dt;
            UISetter.SetButtonAppearance(false, btnrepbins, btngencasebreak, btngenpick, btnconpick);
        }
    }
}
