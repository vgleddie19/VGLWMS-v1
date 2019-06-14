using DevComponents.DotNetBar.SuperGrid;
using Framework;
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
    public partial class ProductMaster : Form
    {
        public ProductMaster()
        {
            InitializeComponent();
            GridPanel panel = grd.PrimaryGrid;
            panel.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            panel.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            panel.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            panel.DefaultVisualStyles.ColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            panel.DefaultVisualStyles.ColumnHeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            panel.DefaultVisualStyles.ColumnHeaderStyles.Default.Padding = new DevComponents.DotNetBar.SuperGrid.Style.Padding(0, 10, 0, 10);
            panel.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            panel.DefaultVisualStyles.GridPanelStyle.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            panel.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            panel.DefaultVisualStyles.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            panel.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            //panel.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells;
            panel.DefaultRowHeight = 50;
            InitializeGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void InitializeGrid()
        {
            DataTable dt = DataSupport.RunDataSet(@"SELECT  p.product_id[gridcol_product], p.[description][gridcol_descp], p.category[gridcol_category], p.default_owner[gridcol_client],id[gridcol_id] FROM [Products] p").Tables[0];
            grd.PrimaryGrid.DataSource = dt;
            //dataGridView1.Columns["Physical Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns["Reserved Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns["For Picking Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns["Available Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void grd_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            try
            {
                newproduct dialog = new newproduct();
                string code = grd.PrimaryGrid.GetCell(e.GridRow.RowIndex, grd.PrimaryGrid.Columns["gridcol_id"].ColumnIndex).Value.ToString();//  product.Rows[e.RowIndex].Cells[colId.Name].Value.ToString();
                var dRow = DataSupport.RunDataSet(String.Format("select top 1 * FROM products  where id = '{0}'", code)).Tables[0];
                if (dRow.Rows.Count > 0)
                {
                    foreach (DataRow rows in dRow.Rows)
                    {
                        dialog.txtCode.Text = rows["product_id"].ToString();
                        dialog.txtdesc1.Text = rows["description"].ToString();
                        dialog.txtdesc2.Text = rows["description1"].ToString();
                        dialog.txtdesc3.Text = rows["description2"].ToString();
                        dialog.cboclient.SelectedValue = rows["default_owner"].ToString();
                        dialog.id = code;
                        dialog.dataGridView1.DataSource = DataSupport.RunDataSet("select uom,qty,barcode[colbarcode] from productuoms  where id = '" + code + "' ").Tables[0];
                    }
                }
                dialog._entrytype = "update";
                dialog.Text = "Update Products";

                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
                if (dialog.DialogResult == DialogResult.OK)
                    InitializeGrid();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
