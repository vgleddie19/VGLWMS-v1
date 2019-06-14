using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class MainMenu : Form
    {
        public MenuWindow dashboard = new MenuWindow();
        ProductMaster pm = new ProductMaster();
        public MainMenu()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            dashboard.MdiParent = this;
            dashboard.Show();
            dashboard.Dock = DockStyle.Fill;
            dashboard.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if(childForm.Text != "DASH BOARD")
                    childForm.Close();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Contains(pm))
                return;

            pm = new ProductMaster();
            pm.MdiParent = this;
            pm.StartPosition = FormStartPosition.CenterScreen;
            //pm.Dock = DockStyle.;
            pm.Show();
        }

        private void receivingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportform dialog = new reportform();
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.Show();
        }
    }
}
