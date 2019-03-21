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
using WMS.Utilities;

namespace WMS
{
    public partial class BinReplishmentWindow : Form
    {
        public BinReplishmentWindow()
        {
            InitializeComponent();
            UISetter.SetGridAppearance(genpickgrid, headerGrid, gencasebreakgrid);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GenerateBinReplenishPicklist dialog = new GenerateBinReplenishPicklist();
            dialog.Icon = this.Icon;
            dialog.ShowDialog();
        }

        private void BinReplishmentWindow_Load(object sender, EventArgs e)
        {
            DataTable dt = DataSupport.RunDataSet("SELECT * FROM binproductledger").Tables[0];
            headerGrid.DataSource = dt;
            UISetter.SetButtonAppearance(false, btnrepbins, btngenpick, btnconpick);
            UISetter.SetLabelAppearance(label1);
            LoadProductGrid();
        }

        private void LoadProductGrid()
        {  

        }

        private void btngenpick_Click(object sender, EventArgs e)
        {
            utabControl1.Tabs["genpick"].Visible = true;
            utabControl1.SelectedTabIndex = 1;
        }

        private void btnconpick_Click(object sender, EventArgs e)
        {            
            utabControl1.Tabs["confirmpick"].Visible = true;
            utabControl1.SelectedTabIndex = 2;
        }

        private void InitMyCaseBreakPickingList()
        {
            foreach (DataGridViewRow gRow in genpickgrid.Rows)
            {
                if (gRow.Index == genpickgrid.Rows.Count - 1)
                    break;


                int orderqty = Convert.ToInt32(gRow.Cells["gridcol_qty"].Value);
                DataTable dt = FAQ.GetRecord(String.Format(@"SELECT * FROM LocationProductsLedger WHERE product = '{0}' AND lot_no = '{1}' AND expiry = '{2}' AND UOM = '{3}' AND available_qty > 0"
                                              , gRow.Cells["gridcol_product"].Value
                                              , gRow.Cells["gridcol_lotno"].Value
                                              , Convert.ToDateTime(gRow.Cells["gridcol_expiry"].Value).ToShortDateString()
                                              , gRow.Cells["gridcol_uom"].Value
                                              ));
                foreach (DataRow dRow in dt.Rows)
                {
                    if (orderqty == 0)
                        break;

                    if (Convert.ToInt32(dRow["available_qty"]) <= Convert.ToInt32(gRow.Cells["gridcol_qty"].Value))
                    {
                        //genproductpickgrid.Rows.Add(gRow.Cells["gridcol_product"].Value, dRow["available_qty"], gRow.Cells["gridcol_uom"].Value, dRow["lot_no"], dRow["expiry"], dRow["location"], gRow.Cells["gridcol_whatuom"].Value);
                        orderqty = -Convert.ToInt32(dRow["available_qty"]);
                    }
                    else
                    {
                        //genproductpickgrid.Rows.Add(gRow.Cells["gridcol_product"].Value, orderqty, gRow.Cells["gridcol_uom"].Value, dRow["lot_no"], dRow["expiry"], dRow["location"], gRow.Cells["gridcol_whatuom"].Value);
                        orderqty = 0;
                    }
                }

            }
        }

        private void utabControl1_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            genpickgrid.Rows.Clear();
            e.Tab.Visible = false;
            e.Cancel = true;
        }

        private void genpickgrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"].Style. = Color.White;
            //genpickgrid.Rows[e.RowIndex].Cells["gridcol_btn"].Value = "Remove";            
            //if (e.ColumnIndex == genpickgrid.Columns["gridcol_product"].Index)
            //{
            //    DataGridViewComboBoxCell dgvcc = new DataGridViewComboBoxCell();
            //    DataGridViewCell dgvc = new DataGridViewComboBoxExCell();
            //    dgvcc.AutoComplete = true;
            //    dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT * FROM productuoms where product = '{0}'", genpickgrid.Rows[e.RowIndex].Cells["gridcol_product"].Value)).Tables[0];
            //    dgvcc.DisplayMember = "uom";
            //    dgvcc.ValueMember = "uom";
            //    dgvc = dgvcc;                
            //    genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"] = dgvc;

            //    //dgvcc = new DataGridViewComboBoxCell();
            //    //dgvc = new DataGridViewComboBoxExCell();
            //    //dgvcc.AutoComplete = true;
            //    //dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT * FROM productuoms where product = '{0}'", genpickgrid.Rows[e.RowIndex].Cells["gridcol_product"].Value)).Tables[0];
            //    //dgvcc.DisplayMember = "uom";
            //    //dgvcc.ValueMember = "uom";
            //    //dgvc = dgvcc;
            //    //genpickgrid.Rows[e.RowIndex].Cells["gridcol_whatuom"] = dgvc;
            //}
            //else if (e.ColumnIndex == genpickgrid.Columns["gridcol_uom"].Index)
            //{
            //    genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"].Style.BackColor = Color.White;
            //    if (genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"].Value == null)
            //        return;

            //    ComboBox c = new ComboBox();

            //    DataGridViewComboBoxCell dgvcc = new DataGridViewComboBoxCell();
            //    DataGridViewCell dgvc = new DataGridViewComboBoxExCell();
            //    dgvcc.AutoComplete = true;
            //    dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT DISTINCT lot_no FROM LocationProductsLedger where product = '{0}' and uom = '{1}'", genpickgrid.Rows[e.RowIndex].Cells["gridcol_product"].Value, genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"].Value)).Tables[0];
            //    dgvcc.DisplayMember = "lot_no";
            //    dgvcc.ValueMember = "lot_no";
            //    dgvc = dgvcc;
            //    genpickgrid.Rows[e.RowIndex].Cells["gridcol_lotno"] = dgvc;
            //}
            //else if (e.ColumnIndex == genpickgrid.Columns["gridcol_lotno"].Index)
            //{
            //    if (genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"].Value == null)
            //        return;

            //    DataGridViewComboBoxCell dgvcc = new DataGridViewComboBoxCell();
            //    DataGridViewCell dgvc = new DataGridViewComboBoxExCell();
            //    dgvcc.AutoComplete = true;
            //    dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT DISTINCT expiry FROM LocationProductsLedger where product = '{0}' and uom = '{1}' and lot_no = '{2}'", genpickgrid.Rows[e.RowIndex].Cells["gridcol_product"].Value, genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"].Value, genpickgrid.Rows[e.RowIndex].Cells["gridcol_lotno"].Value)).Tables[0];
            //    dgvcc.DisplayMember = "expiry";
            //    dgvcc.ValueMember = "expiry";
            //    dgvc = dgvcc;
            //    dgvc.Style.BackColor = Color.White;
            //    dgvc.Style.SelectionBackColor = Color.White;
            //    genpickgrid.Rows[e.RowIndex].Cells["gridcol_expiry"] = dgvc;               
            //}            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchProductStocks sp = new SearchProductStocks();
            sp.Icon = this.Icon;
            sp.StartPosition = FormStartPosition.CenterScreen;
            sp.parentform = this;
            if (sp.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
