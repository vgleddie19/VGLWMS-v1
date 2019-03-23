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
    public partial class SearchProductStocks : Form
    {
        public BinReplishmentWindow parentform { get; set; }
        bool formload = false;
        #region Initialize Form
        public SearchProductStocks()
        {
            InitializeComponent();
        }

        private void SearchProductStocks_Load(object sender, EventArgs e)
        {
            LoadData();
            formload = true;
        }
        #endregion

        #region Initialize Grid
        private void LoadData()
        {
            String sql;
            if (parentform.process_bin[1] != "")
                sql=String.Format("SELECT lp.* FROM[LocationProductsLedger] lp JOIN Locations l on lp.location = l.location_id where l.type = 'STORAGE' AND lp.available_qty >= 1 AND product = '{0}'", parentform.process_bin[1]);
            else
                sql = "SELECT lp.* FROM[LocationProductsLedger] lp JOIN Locations l on lp.location = l.location_id where l.type = 'STORAGE' AND lp.available_qty >= 1";

            foreach (DataRow item in DataSupport.RunDataSet(sql).Tables[0].Rows)
            {
                bool found = false;
                foreach (DataGridViewRow item1 in parentform.genpickgrid.Rows)
                {
                    if (item["location"].ToString() == item1.Cells["gridcolloc"].Value.ToString() &&
                        item["product"].ToString() == item1.Cells["gridcolprod"].Value.ToString() &&
                        item["uom"].ToString() == item1.Cells["gridcoluom"].Value.ToString() &&
                        item["lot_no"].ToString() == item1.Cells["gridcollot"].Value.ToString() &&
                        Convert.ToDateTime(item["expiry"]).ToShortDateString() == Convert.ToDateTime(item1.Cells["gridcolexpiry"].Value).ToShortDateString())
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                    grid.PrimaryGrid.Rows.Add(new GridRow(true, item["location"], item["product"], item["uom"], item["lot_no"], Convert.ToDateTime(item["expiry"]).ToShortDateString(), item["available_qty"]));
                else
                    grid.PrimaryGrid.Rows.Add(new GridRow(false, item["location"], item["product"], item["uom"], item["lot_no"], Convert.ToDateTime(item["expiry"]).ToShortDateString(), item["available_qty"]));
            }
        }
        #endregion

        private void grid_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            if (!formload)
                return;
            if (e.GridCell.ColumnIndex == grid.PrimaryGrid.Columns["gridcolchk"].ColumnIndex)
            {
                if ((bool)e.NewValue)
                {
                    parentform.genpickgrid.Rows.Add(grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolloc"].ColumnIndex).Value.ToString().Trim(),
                        grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolprod"].ColumnIndex).Value.ToString().Trim(),
                        grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcoluom"].ColumnIndex).Value.ToString().Trim(),
                        grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcollot"].ColumnIndex).Value.ToString().Trim(),
                        Convert.ToDateTime(grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolexpiry"].ColumnIndex).Value).ToShortDateString(),
                        grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolqty"].ColumnIndex).Value.ToString().Trim(),
                        "REMOVE");
                    if (grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcoluom"].ColumnIndex).Value.ToString().Trim() == "CASE" ||
                        grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcoluom"].ColumnIndex).Value.ToString().Trim() == "CASES")
                    {
                        parentform.gencasebreakgrid.Rows.Add(parentform.process_bin[0],
                            grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolprod"].ColumnIndex).Value.ToString().Trim(),
                            grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcoluom"].ColumnIndex).Value.ToString().Trim(),
                            grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcollot"].ColumnIndex).Value.ToString().Trim(),
                            Convert.ToDateTime(grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolexpiry"].ColumnIndex).Value).ToShortDateString(),
                            grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolqty"].ColumnIndex).Value.ToString().Trim(),
                            "REMOVE");
                    }
                }
                else
                {
                    foreach (DataGridViewRow item in parentform.genpickgrid.Rows)
                    {
                        if (grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolloc"].ColumnIndex).Value.ToString().Trim() == item.Cells["gridcolloc"].Value.ToString().Trim() &&
                        grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolprod"].ColumnIndex).Value.ToString().Trim() == item.Cells["gridcolprod"].Value.ToString().Trim() &&
                        grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcoluom"].ColumnIndex).Value.ToString().Trim() == item.Cells["gridcoluom"].Value.ToString().Trim() &&
                        grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcollot"].ColumnIndex).Value.ToString().Trim() == item.Cells["gridcollot"].Value.ToString().Trim() &&
                        Convert.ToDateTime(grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolexpiry"].ColumnIndex).Value).ToShortDateString() == Convert.ToDateTime(item.Cells["gridcolexpiry"].Value).ToShortDateString())
                        {
                            parentform.genpickgrid.Rows.Remove(item);
                        }
                    }
                    foreach (DataGridViewRow item in parentform.gencasebreakgrid.Rows)
                    {
                        if (parentform.process_bin[0] == item.Cells["gridcolcasebreak_loc"].Value.ToString().Trim() &&
                        grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolprod"].ColumnIndex).Value.ToString().Trim() == item.Cells["gridcolcasebreak_prod"].Value.ToString().Trim() &&
                        grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcoluom"].ColumnIndex).Value.ToString().Trim() == item.Cells["gridcolcasebreak_uom"].Value.ToString().Trim() &&
                        grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcollot"].ColumnIndex).Value.ToString().Trim() == item.Cells["gridcolcasebreak_lot"].Value.ToString().Trim() &&
                        Convert.ToDateTime(grid.PrimaryGrid.GetCell(e.GridCell.RowIndex, grid.PrimaryGrid.Columns["gridcolexpiry"].ColumnIndex).Value).ToShortDateString() == Convert.ToDateTime(item.Cells["gridcolcasebreak_expiry"].Value).ToShortDateString())
                        {
                            parentform.gencasebreakgrid.Rows.Remove(item);
                        }
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
