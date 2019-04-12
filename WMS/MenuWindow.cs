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
    public partial class MenuWindow : Form
    {
        Dictionary<String, DataRow> Products = new Dictionary<string, DataRow>();
        #region InitializeForm
        public MenuWindow()
        {
            InitializeComponent();
            cmbReports.SelectedIndex = 0;
        }

        private void MenuWindow_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            LoadInventory();
        }
        private void MenuWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //SearchProductStocks sp = new SearchProductStocks();
                //sp.Icon = this.Icon;
                //sp.StartPosition = FormStartPosition.CenterScreen;
                //if (sp.ShowDialog() == DialogResult.OK)
                //{
                //}
            }

        }
        private void LoadInventory()
        {
            if (comboBox1.Text == "Items per Location")
            {
                DataTable dt = DataSupport.RunDataSet(@"SELECT Location, Product + ' - ' + (SELECT description FROM Products WHERE product = product_id)[Product],  Uom, 
                        SUM(Qty) [Physical Qty], SUM(reserved_qty)[Reserved Qty], SUM(to_be_picked_qty)[For Picking Qty], SUM(available_qty) [Available Qty]
                        FROM LocationProductsLedger
                        WHERE qty > 0
                        GROUP BY location, product, uom").Tables[0];


                dataGridView1.DataSource = dt;
                dataGridView1.Columns["Physical Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Reserved Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["For Picking Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Available Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (comboBox1.Text == "Detailed Items per Location")
            {
                DataTable dt = DataSupport.RunDataSet(@"SELECT Location, Product + ' - ' + (SELECT description FROM Products WHERE product = product_id)[Product],  Uom, lot_no[Lot No], Expiry, 
                        Qty [Physical Qty], reserved_qty[Reserved Qty], to_be_picked_qty[For Picking Qty]
                        FROM LocationProductsLedger
                        WHERE qty > 0").Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    row["Expiry"] = DateTime.Parse(row["Expiry"].ToString()).ToShortDateString();
                }

                dataGridView1.DataSource = dt;
            }



        }
        private void LoadInventorySuperGrid()
        {
            Products = Utils.BuildIndex("SELECT * FROM [Products]", "product_id");
            GridPanel manipanel = grid.PrimaryGrid;
            GridMainParent(manipanel);
            GridRow mainRow = new GridRow();
            foreach (DataRow dRow_loc in DataSupport.RunDataSet("SELECT * FROM [Locations]").Tables[0].Rows)
            {
                mainRow = new GridRow();

                mainRow.Cells.Add(new GridCell(dRow_loc["location_id"]));
                mainRow.Cells.Add(new GridCell(dRow_loc["description"]));

                StringBuilder currentprod = new StringBuilder();
                GridPanel productpanel = new GridPanel();
                GridRow gRow_prod = new GridRow();
                if (comboBox1.Text == "Items per Location")
                {
                    foreach (DataRow dRow_locprod in DataSupport.RunDataSet(String.Format("SELECT DISTINCT product FROM LocationProductsLedger WHERE location = '{0}' order by product", dRow_loc["location_id"])).Tables[0].Rows)
                    {
                        gRow_prod = new GridRow();
                        productpanel = new GridPanel();
                        GridColumn col = new GridColumn();
                        col.HeaderText = "Product ID";
                        col.Name = "product";
                        col.EditorType = typeof(GridLabelXEditControl);
                        productpanel.Columns.Add(col);

                        col = new GridColumn();
                        col.HeaderText = "Description";
                        col.Name = "description";
                        col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
                        col.EditorType = typeof(GridLabelXEditControl);
                        productpanel.Columns.Add(col);
                        productpanel.ShowTreeButtons = true;
                        productpanel.ShowTreeLines = true;

                        gRow_prod.Cells.Add(new GridCell(dRow_locprod["product"]));
                        DataRow data;
                        if (Products.TryGetValue(dRow_locprod["product"].ToStringNull(), out data))
                            gRow_prod.Cells.Add(new GridCell(data["description"]));

                        List<String> param = new List<string>();
                        param.Add(dRow_locprod["product"].ToStringNull());
                        param.Add(dRow_loc["location_id"].ToStringNull());

                        getProductLedger(gRow_prod, param);

                        if (gRow_prod.Rows.Count != 0)
                            productpanel.Rows.Add(gRow_prod);
                        if (productpanel.Rows.Count != 0)
                            mainRow.Rows.Add(productpanel);
                    }
                }
                else if (comboBox1.Text == "Detailed Items per Location")
                {
                    foreach (DataRow dRow_locprod in DataSupport.RunDataSet(String.Format("SELECT DISTINCT product FROM LocationProductsLedger WHERE location = '{0}' order by product", dRow_loc["location_id"])).Tables[0].Rows)
                    {
                        gRow_prod = new GridRow();
                        productpanel = new GridPanel();
                        GridColumn col = new GridColumn();
                        col.HeaderText = "Product ID";
                        col.Name = "product";
                        col.EditorType = typeof(GridLabelXEditControl);
                        productpanel.Columns.Add(col);

                        col = new GridColumn();
                        col.HeaderText = "Description";
                        col.Name = "description";
                        col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
                        col.EditorType = typeof(GridLabelXEditControl);
                        productpanel.Columns.Add(col);
                        productpanel.ShowTreeButtons = true;
                        productpanel.ShowTreeLines = true;

                        gRow_prod.Cells.Add(new GridCell(dRow_locprod["product"]));
                        DataRow data;
                        if (Products.TryGetValue(dRow_locprod["product"].ToStringNull(), out data))
                            gRow_prod.Cells.Add(new GridCell(data["description"]));

                        List<String> param = new List<string>();
                        param.Add(dRow_locprod["product"].ToStringNull());
                        param.Add(dRow_loc["location_id"].ToStringNull());

                        getProductLedger(gRow_prod, param);

                        if (gRow_prod.Rows.Count != 0)
                            productpanel.Rows.Add(gRow_prod);
                        if (productpanel.Rows.Count != 0)
                            mainRow.Rows.Add(productpanel);
                    }
                }
                manipanel.Rows.Add(mainRow);
            }
        }

        private void getProductLedger(GridRow gRow, List<String> param)
        {
            GridPanel panel_prodloc = new GridPanel();
            GridColumn col = new GridColumn();
            col.HeaderText = "UOM";
            col.Name = "uom";
            col.EditorType = typeof(GridLabelXEditControl);
            panel_prodloc.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Physical Qty";
            col.Name = "qty";
            col.EditorType = typeof(GridLabelXEditControl);
            panel_prodloc.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Reserved Qty";
            col.Name = "reserved_qty";
            col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            col.EditorType = typeof(GridLabelXEditControl);
            panel_prodloc.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "For Picking Qty";
            col.Name = "to_be_picked_qty";
            col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            col.EditorType = typeof(GridLabelXEditControl);
            panel_prodloc.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = (comboBox1.Text == "Items per Location") ? "Available Qty": "Lot Number";
            col.Name = "available_qty";
            col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            col.EditorType = typeof(GridLabelXEditControl);
            panel_prodloc.Columns.Add(col);

            if (comboBox1.Text == "Detailed Items per Location")
            {
                col = new GridColumn();
                col.HeaderText = "Date Expiry";
                col.Name = "expiry";
                col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
                col.EditorType = typeof(GridLabelXEditControl);
                panel_prodloc.Columns.Add(col);
            }

            GridRow gRow_prodloc = new GridRow();
            foreach (DataRow dRow_locprod in DataSupport.RunDataSet(String.Format("SELECT * FROM LocationProductsLedger WHERE product = '{0}' AND location = '{1}' order by product", param[0], param[1])).Tables[0].Rows)
            {
                if (dRow_locprod["qty"].ToString() != "0" || dRow_locprod["reserved_qty"].ToString() != "0" || dRow_locprod["to_be_picked_qty"].ToString() != "0" || dRow_locprod["available_qty"].ToString() != "0")
                {
                    gRow_prodloc = new GridRow();
                    gRow_prodloc.Cells.Add(new GridCell(dRow_locprod["uom"]));
                    gRow_prodloc.Cells.Add(new GridCell(dRow_locprod["qty"]));
                    gRow_prodloc.Cells.Add(new GridCell(dRow_locprod["reserved_qty"]));
                    gRow_prodloc.Cells.Add(new GridCell(dRow_locprod["to_be_picked_qty"]));
                    if (comboBox1.Text == "Items per Location")
                    {
                        gRow_prodloc.Cells.Add(new GridCell(dRow_locprod["available_qty"]));
                    }
                    else if (comboBox1.Text == "Detailed Items per Location")
                    {
                        gRow_prodloc.Cells.Add(new GridCell(dRow_locprod["lot_no"]));
                        gRow_prodloc.Cells.Add(new GridCell(Convert .ToDateTime(dRow_locprod["expiry"]).ToShortDateString()));
                    }

                    panel_prodloc.Rows.Add(gRow_prodloc);
                }
            }
            if (panel_prodloc.Rows.Count != 0)
                gRow.Rows.Add(panel_prodloc);
        }
        private void GridMainParent(GridPanel panel)
        {
            panel.Columns.Clear();
            panel.Rows.Clear();
            GridColumn col = new GridColumn();
            col.HeaderText = "Location ID";
            col.Name = "location_id";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Description";
            col.Name = "description";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);
        }
        #endregion

        #region Buttons
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadInventory();
        }
        private void btnAddReceipt_Click(object sender, EventArgs e)
        {
            NewReceiptsWindow dialog = new NewReceiptsWindow();          
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnNewPutaway_Click(object sender, EventArgs e)
        {
            NewPutawayWindow dialog = new NewPutawayWindow();
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnConfirmPutaway_Click(object sender, EventArgs e)
        {
            DeclarePutawayScanIDWindow dialog = new DeclarePutawayScanIDWindow();
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            MakeReleaseOrderWindow dialog = new MakeReleaseOrderWindow();
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnPicklist_Click(object sender, EventArgs e)
        {
            NewPicklistWindow dialog = new NewPicklistWindow();
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnConfirmPicklist_Click(object sender, EventArgs e)
        {
            DeclarePicklistScanID dialog = new DeclarePicklistScanID();
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnReleasing_Click(object sender, EventArgs e)
        {
            ScanReleaseIDWindow dialog = new ScanReleaseIDWindow();
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnPhysicalCount_Click(object sender, EventArgs e)
        {
            NewPhysicalCountWindow dialog = new NewPhysicalCountWindow();
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnDeclarePhysicalCou_Click(object sender, EventArgs e)
        {
            ScanPhysicalCountWindow dialog = new ScanPhysicalCountWindow();
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnForResolution_Click(object sender, EventArgs e)
        {
            ForResolutionsWindow dialog = new ForResolutionsWindow();
            dialog.ShowDialog();
            LoadInventory();
        }

        /// Inventory Audits and Reports
        private void btnBadStockDeclarations_Click(object sender, EventArgs e)
        {
            DeclareBadStockWindow dialog = new DeclareBadStockWindow();
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnForOrderResolutions_Click(object sender, EventArgs e)
        {
            OrdersForResolutionsWindow dialog = new OrdersForResolutionsWindow();
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnPutawayCancelledPallet_Click(object sender, EventArgs e)
        {
            CancelledPalletPutawayWindow dialog = new CancelledPalletPutawayWindow();
            dialog.ShowDialog();
            LoadInventory();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (cmbReports.Text == "PHYSICAL COUNT CALENDAR")
            {
                PhysicalCountCalendarReport dialog = new PhysicalCountCalendarReport();
                dialog.ShowDialog();
            }

            if (cmbReports.Text == "STOCKS AGE REPORT")
            {
                StocksAgeReport dialog = new StocksAgeReport();
                dialog.ShowDialog();
            }

            if (cmbReports.Text == "ACTUAL STOCK REPORT")
            {
                ActualStockReport dialog = new ActualStockReport();
                dialog.ShowDialog();
            }

        }

        private void btnStockCheck_Click(object sender, EventArgs e)
        {
            StockCheckingWindow dialog = new StockCheckingWindow();
            dialog.ShowDialog();
        }
        private void btnNewCaseBreak_Click(object sender, EventArgs e)
        {
            BinReplishmentWindow dialog = new BinReplishmentWindow();
            dialog.ShowIcon = false;
            dialog.ShowInTaskbar = false;
            dialog.Icon = this.Icon;
            dialog.ShowDialog();
            //NewCaseBreakWindow dialog = new NewCaseBreakWindow();
            //dialog.ShowIcon = false;
            //dialog.ShowInTaskbar = false;
            //dialog.Icon = this.Icon;
            //dialog.ShowDialog();
        }

        private void btnConfirmCaseBreak_Click(object sender, EventArgs e)
        {
            DeclareCaseBreakPickListScanID dialog = new DeclareCaseBreakPickListScanID();
            dialog.ShowIcon = false;
            dialog.ShowInTaskbar = false;
            dialog.Icon = this.Icon;
            dialog.ShowDialog();
            LoadInventory();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            BinMasterFile dialog = new BinMasterFile();
            dialog.ShowIcon = false;
            dialog.ShowInTaskbar = false;
            dialog.Icon = this.Icon;
            dialog.ShowDialog();
        }
    }
}
