using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Rendering;
using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VGLHelper;
using WMS.Utilities;

namespace WMS
{
    public partial class BinReplishmentWindow : Form
    {
        public List<String> process_bin { get; set; }
        #region Form Initialization
        public BinReplishmentWindow()
        {
            InitializeComponent();
            UISetter.SetGridAppearance(genpickgrid, headerGrid, gencasebreakgrid);
        }

        private void BinReplishmentWindow_Load(object sender, EventArgs e)
        {
            DataTable dt = DataSupport.RunDataSet("SELECT [Location], [Product], [uom], [lot_no], convert(varchar, [expiry], 11)[expiry], [actualqty], [min_qty], [max_qty], [qty_to_replenished], [status] FROM binproductledger").Tables[0];
            headerGrid.DataSource = dt;
            headerGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            headerGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            headerGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerGrid.Columns["uom"].HeaderText = "UOM";
            headerGrid.Columns["lot_no"].HeaderText = "Lot Number";
            headerGrid.Columns["expiry"].HeaderText = "Expiry Date";
            headerGrid.Columns["actualqty"].HeaderText = "Actual Qty.";
            headerGrid.Columns["min_qty"].HeaderText = "Minimum Qty.";
            headerGrid.Columns["max_qty"].HeaderText = "Maximum Qty.";
            headerGrid.Columns["qty_to_replenished"].HeaderText = "Qty. to Replenished";
            headerGrid.Columns["status"].HeaderText = "Status";

            //Etcetera.modify_coltype(headerGrid, "button", DataGridViewAutoSizeColumnMode.DisplayedCells, 200, "btn", "Action",headerGrid.Columns.Count-1);
            UISetter.SetLabelAppearance(label1);
        }

        private void utabControl1_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            genpickgrid.Rows.Clear();
            e.Tab.Visible = false;
            e.Cancel = true;
        }
        #endregion

        #region Generate Replenishment and Controls
        private void btnaddprod_Click(object sender, EventArgs e)
        {
            //SearchProductStocks sp = new SearchProductStocks();
            //sp.Icon = this.Icon;
            //sp.StartPosition = FormStartPosition.CenterScreen;
            //sp.parentform = this;
            //if (sp.ShowDialog() == DialogResult.OK)
            //{

            //}
        }
        #endregion

        private void btngendocs_Click(object sender, EventArgs e)
        {
            CaseBreakPickListConfirmation dialog = new CaseBreakPickListConfirmation();
            dialog.parent = this;
            dialog.Show();

            //CaseBreakPickListConfirmation dialog1  = new CaseBreakPickListConfirmation();
            //dialog1.parent = this;
            //dialog1.Text = "Case Break Confirmation";
            //dialog1.reportname = "casebreak";
            //dialog1.Show();

            //CaseBreakPickListConfirmation dialog2 = new CaseBreakPickListConfirmation();
            //dialog2.parent = this;
            //dialog2.Text = "BIN Put-Away Confirmation";
            //dialog2.reportname = "putaway";
            //dialog2.Show();

            //CaseBreakPickListConfirmation dialog2 = new CaseBreakPickListConfirmation();
            //dialog2.parent = this;
            //dialog2.reportname = "putaway";
            //dialog2.ShowDialog();

            //if (dialog.ShowDialog() == DialogResult.OK)
            //    DialogResult = DialogResult.OK;
            //if (dialog.btnCancel.Visible == false)
            //    DialogResult = DialogResult.OK;
        }

        private void headerGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void btnNewPutaway_Click(object sender, EventArgs e)
        {
            foreach (DataRow dRow in FAQ.Whatareproductstobereplenish().Rows)
            {
                genpickgrid.Rows.Add(dRow["binid"],dRow["location"], dRow["product"], dRow["uom"], dRow["lot"], dRow["expiry"], dRow["qty"]);
                if(dRow["uom"].ToString() == "CS" || dRow["uom"].ToString() == "CASES")
                {
                    gencasebreakgrid.Rows.Add(dRow["binid"],dRow["location"], dRow["product"], dRow["uom"], dRow["lot"], dRow["expiry"], dRow["qty"]);
                }
            }

            process_bin = new List<string>();
            tabcontrol.Tabs["tabgenpick"].Visible = true;
            tabcontrol.SelectedTabIndex = 4;
        }
    }
}
