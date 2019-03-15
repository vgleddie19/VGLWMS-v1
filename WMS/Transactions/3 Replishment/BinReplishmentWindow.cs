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

        private void btngenpick_Click(object sender, EventArgs e)
        {
            TabPage genpickbin = new TabPage();
            genpickbin.Location = new System.Drawing.Point(4, 54);
            genpickbin.Name = "genpickbin";
            genpickbin.Padding = new System.Windows.Forms.Padding(3);
            genpickbin.Size = new System.Drawing.Size(1262, 642);
            genpickbin.TabIndex = 1;
            genpickbin.Text = "Generate Picklist\nBin Replenishment";
            genpickbin.UseVisualStyleBackColor = true;
            if (!tabcontrol.Controls.ContainsKey("genpickbin"))
            {
                this.tabcontrol.Controls.Add(genpickbin);
            }
            this.tabcontrol.SelectedIndex = 1;
        }

        private void btnconpick_Click(object sender, EventArgs e)
        {
            TabPage confitmpickbin = new TabPage();
            confitmpickbin.Location = new System.Drawing.Point(4, 54);
            confitmpickbin.Name = "conpickbin";
            confitmpickbin.Padding = new System.Windows.Forms.Padding(3);
            confitmpickbin.Size = new System.Drawing.Size(1262, 642);
            confitmpickbin.TabIndex = 3;
            confitmpickbin.Text = "Confirm Picklist\nBin Replenishment";
            confitmpickbin.UseVisualStyleBackColor = true;
            if (!tabcontrol.Controls.ContainsKey("conpickbin"))
            {
                this.tabcontrol.Controls.Add(confitmpickbin);
            }
            this.tabcontrol.SelectedIndex = 3;
        }

        private void btngencasebreak_Click(object sender, EventArgs e)
        {
            TabPage casebreak = new TabPage();
            casebreak.Location = new System.Drawing.Point(4, 54);
            casebreak.Name = "casebreak";
            casebreak.Padding = new System.Windows.Forms.Padding(3);
            casebreak.Size = new System.Drawing.Size(1262, 642);
            casebreak.TabIndex = 2;
            casebreak.Text = "Case Break";
            casebreak.UseVisualStyleBackColor = true;
            if (!tabcontrol.Controls.ContainsKey("casebreak"))
            {
                this.tabcontrol.Controls.Add(casebreak);
            }
            this.tabcontrol.SelectedIndex = 2;
        }

        private void btnrepbins_Click(object sender, EventArgs e)
        {
            TabPage confirmbinrep = new TabPage();
            confirmbinrep.Location = new System.Drawing.Point(4, 54);
            confirmbinrep.Name = "confirmbinrep";
            confirmbinrep.Padding = new System.Windows.Forms.Padding(3);
            confirmbinrep.Size = new System.Drawing.Size(1262, 642);
            confirmbinrep.TabIndex = 4;
            confirmbinrep.Text = "Confirm Bin Replenishment";
            confirmbinrep.UseVisualStyleBackColor = true;
            if (!tabcontrol.Controls.ContainsKey("confirmbinrep"))
            {
                this.tabcontrol.Controls.Add(confirmbinrep);
            }
            this.tabcontrol.SelectedIndex = 4;
        }
    }
}
