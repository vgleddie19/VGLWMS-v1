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
            UISetter.SetGridAppearance(genpickgrid, headerGrid, genproductpickgrid);
            UISetter.SetButtonAppearance(false, btnrepbins, btngenpick, btnconpick);
            LoadProductGrid();
        }

        private void LoadProductGrid()
        {           
            genpickgrid.Columns.Clear();
            genpickgrid.Rows.Clear();

            DataGridViewComboBoxExColumn cbo = new DataGridViewComboBoxExColumn();
            cbo.DropDownStyle = ComboBoxStyle.DropDown;
            cbo.DataSource = DataSupport.RunDataSet("SELECT * FROM PRODUCTS").Tables[0];
            cbo.DisplayMember = "product_id";
            cbo.ValueMember = "product_id";
            cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo.DropDownHeight = 100;
            cbo.Name = "gridcol_product";
            cbo.HeaderText = "Product";
            genpickgrid.Columns.Add(cbo);

            DataGridViewComboBoxColumn cbo1 = new DataGridViewComboBoxColumn();
            cbo1.Name = "gridcol_uom";
            cbo1.HeaderText = "UOM";
            cbo1.DefaultCellStyle.BackColor = Color.White;
            cbo1.DefaultCellStyle.SelectionBackColor = Color.White;
            cbo1.FlatStyle = FlatStyle.Flat;
            genpickgrid.Columns.Add(cbo1);

            cbo1 = new DataGridViewComboBoxColumn();
            cbo1.Name = "gridcol_lotno";
            cbo1.HeaderText = "Lot Number";
            cbo1.DefaultCellStyle.BackColor = Color.White;
            cbo1.DefaultCellStyle.SelectionBackColor = Color.White;
            cbo1.FlatStyle = FlatStyle.Popup;
            genpickgrid.Columns.Add(cbo1);

            cbo1 = new DataGridViewComboBoxColumn();
            cbo1.Name = "gridcol_expiry";
            cbo1.HeaderText = "Expiry Date";
            cbo1.DefaultCellStyle.BackColor = Color.White;
            cbo1.DefaultCellStyle.SelectionBackColor = Color.White;
            cbo1.FlatStyle = FlatStyle.Popup;
            genpickgrid.Columns.Add(cbo1);

            DataGridViewTextBoxColumn cbo2 = new DataGridViewTextBoxColumn();
            cbo2.Name = "gridcol_qty";
            cbo2.HeaderText = "Quantity";
            cbo2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            genpickgrid.Columns.Add(cbo2);

            DataGridViewButtonColumn grdbtn = new DataGridViewButtonColumn();
            grdbtn.Name = "gridcol_btn";
            grdbtn.HeaderText = " ";
            grdbtn.DefaultCellStyle.BackColor = Color.OrangeRed;
            grdbtn.DefaultCellStyle.SelectionBackColor = Color.OrangeRed;
            grdbtn.FlatStyle = FlatStyle.Popup;
            grdbtn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            genpickgrid.Columns.Add(grdbtn);

            genproductpickgrid.Columns.Clear();
            genproductpickgrid.Rows.Clear();

             cbo = new DataGridViewComboBoxExColumn();
            cbo.DropDownStyle = ComboBoxStyle.DropDown;
            cbo.DataSource = DataSupport.RunDataSet("SELECT * FROM PRODUCTS").Tables[0];
            cbo.DisplayMember = "product_id";
            cbo.ValueMember = "product_id";
            cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbo.DropDownHeight = 100;
            cbo.Name = "gridcol_product";
            cbo.HeaderText = "Product";
            genproductpickgrid.Columns.Add(cbo);

            cbo1 = new DataGridViewComboBoxColumn();
            cbo1.Name = "gridcol_uom";
            cbo1.HeaderText = "UOM";
            genproductpickgrid.Columns.Add(cbo1);

            cbo1 = new DataGridViewComboBoxColumn();
            cbo1.Name = "gridcol_lotno";
            cbo1.HeaderText = "Lot Number";
            genproductpickgrid.Columns.Add(cbo1);

            cbo1 = new DataGridViewComboBoxColumn();
            cbo1.Name = "gridcol_expiry";
            cbo1.HeaderText = "Expiry Date";
            genproductpickgrid.Columns.Add(cbo1);

            cbo2 = new DataGridViewTextBoxColumn();
            cbo2.Name = "gridcol_qty";
            cbo2.HeaderText = "Quantity";
            cbo2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            genproductpickgrid.Columns.Add(cbo2);

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
            genpickgrid.Rows[e.RowIndex].Cells["gridcol_btn"].Value = "Remove";            
            if (e.ColumnIndex == genpickgrid.Columns["gridcol_product"].Index)
            {
                DataGridViewComboBoxCell dgvcc = new DataGridViewComboBoxCell();
                DataGridViewCell dgvc = new DataGridViewComboBoxExCell();
                dgvcc.AutoComplete = true;
                dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT * FROM productuoms where product = '{0}'", genpickgrid.Rows[e.RowIndex].Cells["gridcol_product"].Value)).Tables[0];
                dgvcc.DisplayMember = "uom";
                dgvcc.ValueMember = "uom";
                dgvc = dgvcc;
                genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"] = dgvc;

                //dgvcc = new DataGridViewComboBoxCell();
                //dgvc = new DataGridViewComboBoxExCell();
                //dgvcc.AutoComplete = true;
                //dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT * FROM productuoms where product = '{0}'", genpickgrid.Rows[e.RowIndex].Cells["gridcol_product"].Value)).Tables[0];
                //dgvcc.DisplayMember = "uom";
                //dgvcc.ValueMember = "uom";
                //dgvc = dgvcc;
                //genpickgrid.Rows[e.RowIndex].Cells["gridcol_whatuom"] = dgvc;
            }
            else if (e.ColumnIndex == genpickgrid.Columns["gridcol_uom"].Index)
            {
                genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"].Style.BackColor = Color.White;
                if (genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"].Value == null)
                    return;

                ComboBox c = new ComboBox();

                DataGridViewComboBoxCell dgvcc = new DataGridViewComboBoxCell();
                DataGridViewCell dgvc = new DataGridViewComboBoxExCell();
                dgvcc.AutoComplete = true;
                dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT DISTINCT lot_no FROM LocationProductsLedger where product = '{0}' and uom = '{1}'", genpickgrid.Rows[e.RowIndex].Cells["gridcol_product"].Value, genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"].Value)).Tables[0];
                dgvcc.DisplayMember = "lot_no";
                dgvcc.ValueMember = "lot_no";
                dgvc = dgvcc;
                genpickgrid.Rows[e.RowIndex].Cells["gridcol_lotno"] = dgvc;
            }
            else if (e.ColumnIndex == genpickgrid.Columns["gridcol_lotno"].Index)
            {
                if (genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"].Value == null)
                    return;

                DataGridViewComboBoxCell dgvcc = new DataGridViewComboBoxCell();
                DataGridViewCell dgvc = new DataGridViewComboBoxExCell();
                dgvcc.AutoComplete = true;
                dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT DISTINCT expiry FROM LocationProductsLedger where product = '{0}' and uom = '{1}' and lot_no = '{2}'", genpickgrid.Rows[e.RowIndex].Cells["gridcol_product"].Value, genpickgrid.Rows[e.RowIndex].Cells["gridcol_uom"].Value, genpickgrid.Rows[e.RowIndex].Cells["gridcol_lotno"].Value)).Tables[0];
                dgvcc.DisplayMember = "expiry";
                dgvcc.ValueMember = "expiry";
                dgvc = dgvcc;
                dgvc.Style.BackColor = Color.White;
                dgvc.Style.SelectionBackColor = Color.White;
                genpickgrid.Rows[e.RowIndex].Cells["gridcol_expiry"] = dgvc;               
            }            
        }
    }
}
