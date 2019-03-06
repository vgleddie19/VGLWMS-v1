using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
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
    public partial class NewCaseBreakWindow : Form
    {
        public NewCaseBreakWindow()
        {
            InitializeComponent();
            DataTable dt = FAQ.GetEmployees("SELECT * FROM EMPLOYEES");
            cboReceivedBy.DataSource = dt;
            cboReceivedBy.DropDownStyle = ComboBoxStyle.DropDown;
            cboReceivedBy.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboReceivedBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboReceivedBy.DisplayMember = "name";
            cboReceivedBy.ValueMember = "employee_id";
            if (dt.Rows.Count > 0)
                cboReceivedBy.SelectedIndex = 0;
        }

        private void NewCaseBreakWindow_Load(object sender, EventArgs e)
        {
            LoadProductGrid();
        }
        private void LoadProductGrid()
        {
            grid.Columns.Clear();
            grid.Rows.Clear();

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
            grid.Columns.Add(cbo);

            DataGridViewComboBoxColumn cbo1 = new DataGridViewComboBoxColumn();
            cbo1.Name = "gridcol_uom";
            cbo1.HeaderText = "UOM";
            grid.Columns.Add(cbo1);

            cbo1 = new DataGridViewComboBoxColumn();
            cbo1.Name = "gridcol_lotno";
            cbo1.HeaderText = "Lot Number";
            grid.Columns.Add(cbo1);

            cbo1 = new DataGridViewComboBoxColumn();
            cbo1.Name = "gridcol_expiry";
            cbo1.HeaderText = "Expiry Date";            
            grid.Columns.Add(cbo1);

            DataGridViewTextBoxColumn cbo2 = new DataGridViewTextBoxColumn();
            cbo2.Name = "gridcol_qty";
            cbo2.HeaderText = "Quantity";
            cbo2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns.Add(cbo2);

            cbo1 = new DataGridViewComboBoxColumn();
            cbo1.Name = "gridcol_whatuom";
            cbo1.HeaderText = "To What UOM?";
            grid.Columns.Add(cbo1);
        }

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grid.Columns["gridcol_product"].Index)
            {
                DataGridViewComboBoxCell dgvcc = new DataGridViewComboBoxCell();
                DataGridViewCell dgvc = new DataGridViewComboBoxExCell();
                dgvcc.AutoComplete = true;
                dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT * FROM productuoms where product = '{0}'", grid.Rows[e.RowIndex].Cells["gridcol_product"].Value)).Tables[0];
                dgvcc.DisplayMember = "uom";
                dgvcc.ValueMember = "uom";                
                dgvc = dgvcc;
                grid.Rows[e.RowIndex].Cells["gridcol_uom"] = dgvc;

                dgvcc = new DataGridViewComboBoxCell();
                dgvc = new DataGridViewComboBoxExCell();
                dgvcc.AutoComplete = true;
                dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT * FROM productuoms where product = '{0}'", grid.Rows[e.RowIndex].Cells["gridcol_product"].Value)).Tables[0];
                dgvcc.DisplayMember = "uom";
                dgvcc.ValueMember = "uom";
                dgvc = dgvcc;
                grid.Rows[e.RowIndex].Cells["gridcol_whatuom"] = dgvc;
            }
            else if (e.ColumnIndex == grid.Columns["gridcol_uom"].Index)
            {
                if (grid.Rows[e.RowIndex].Cells["gridcol_uom"].Value == null)
                    return;

                ComboBox c = new ComboBox();
                
                DataGridViewComboBoxCell dgvcc = new DataGridViewComboBoxCell();
                DataGridViewCell dgvc = new DataGridViewComboBoxExCell();
                dgvcc.AutoComplete = true;
                dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT DISTINCT lot_no FROM LocationProductsLedger where product = '{0}' and uom = '{1}'", grid.Rows[e.RowIndex].Cells["gridcol_product"].Value, grid.Rows[e.RowIndex].Cells["gridcol_uom"].Value)).Tables[0];
                dgvcc.DisplayMember = "lot_no";
                dgvcc.ValueMember = "lot_no";
                dgvc = dgvcc;                
                grid.Rows[e.RowIndex].Cells["gridcol_lotno"] = dgvc;
            }
            else if (e.ColumnIndex == grid.Columns["gridcol_lotno"].Index)
            {
                if (grid.Rows[e.RowIndex].Cells["gridcol_uom"].Value == null)
                    return;

                DataGridViewComboBoxCell dgvcc = new DataGridViewComboBoxCell();
                DataGridViewCell dgvc = new DataGridViewComboBoxExCell();
                dgvcc.AutoComplete = true;
                dgvcc.DataSource = DataSupport.RunDataSet(String.Format("SELECT DISTINCT expiry FROM LocationProductsLedger where product = '{0}' and uom = '{1}' and lot_no = '{2}'", grid.Rows[e.RowIndex].Cells["gridcol_product"].Value, grid.Rows[e.RowIndex].Cells["gridcol_uom"].Value, grid.Rows[e.RowIndex].Cells["gridcol_lotno"].Value)).Tables[0];
                dgvcc.DisplayMember = "expiry";
                dgvcc.ValueMember = "expiry";
                dgvc = dgvcc;
                grid.Rows[e.RowIndex].Cells["gridcol_expiry"] = dgvc;
            }
        }

        private void InitMyCaseBreakPickingList()
        {
            foreach (DataGridViewRow gRow in grid.Rows)
            {
                if (gRow.Index == grid.Rows.Count-1)
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
                        picklist_grid.Rows.Add(gRow.Cells["gridcol_product"].Value, dRow["available_qty"], gRow.Cells["gridcol_uom"].Value, dRow["lot_no"], dRow["expiry"], dRow["location"], gRow.Cells["gridcol_whatuom"].Value);
                        orderqty = -Convert.ToInt32(dRow["available_qty"]);
                    }
                    else
                    {
                        picklist_grid.Rows.Add(gRow.Cells["gridcol_product"].Value, orderqty, gRow.Cells["gridcol_uom"].Value, dRow["lot_no"], dRow["expiry"], dRow["location"], gRow.Cells["gridcol_whatuom"].Value);
                        orderqty = 0;
                    }
                }

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            NewCaseBreakConfirm dialog = new NewCaseBreakConfirm();
            dialog.Icon = this.Icon;
            dialog.parent = this;
            if (dialog.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
            if (dialog.btnCancel.Visible == false)
                DialogResult = DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InitMyCaseBreakPickingList();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}

