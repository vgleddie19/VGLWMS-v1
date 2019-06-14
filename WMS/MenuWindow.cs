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
            initgrd_design(grd.PrimaryGrid);
            initgrd_design(grdorderpick.PrimaryGrid);
            //initgrd_design(grdpendingtrip.PrimaryGrid);
        }
        void initgrd_design(GridPanel panel)
        {
            grd.PrimaryGrid.ShowTreeLines = false;
            grd.PrimaryGrid.ShowTreeButton = false;
            panel.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            panel.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            panel.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            panel.DefaultVisualStyles.ColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            panel.DefaultVisualStyles.ColumnHeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            panel.DefaultVisualStyles.ColumnHeaderStyles.Default.Padding = new DevComponents.DotNetBar.SuperGrid.Style.Padding(0, 5, 0, 5);
            panel.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            panel.DefaultVisualStyles.GridPanelStyle.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            panel.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            panel.DefaultVisualStyles.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            panel.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            panel.DefaultRowHeight = 50;
            grd.PrimaryGrid.ReadOnly = true;
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
                DataTable dt = DataSupport.RunDataSet(@"SELECT Location, Product + ' - ' + (SELECT top 1 description FROM Products WHERE product = product_id)[Product],  Uom, 
                        SUM(Qty) [Physical Qty], SUM(reserved_qty)[Reserved Qty], SUM(to_be_picked_qty)[For Picking Qty], SUM(available_qty) [Available Qty]
                        FROM LocationProductsLedger
                        WHERE available_qty > 1 or qty >= 1 or reserved_qty >= 1
                        GROUP BY location, product, uom").Tables[0];

                grd.PrimaryGrid.DataSource = dt;
            }

            if (comboBox1.Text == "Detailed Items per Location")
            {
                DataTable dt = DataSupport.RunDataSet(@"SELECT Location, Product + ' - ' + (SELECT description FROM Products WHERE product = product_id)[Product],  Uom, lot_no[Lot No], Expiry, 
                        Qty [Physical Qty], reserved_qty[Reserved Qty], to_be_picked_qty[For Picking Qty]
                        FROM LocationProductsLedger
                        WHERE available_qty > 1 or qty >= 1 or reserved_qty >= 1").Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    row["Expiry"] = DateTime.Parse(row["Expiry"].ToString()).ToShortDateString();
                }

                grd.PrimaryGrid.DataSource = dt;
            }
            LoadPendingTrips();
            PendingSOPick();
        }

        #region "Pending Trips"
        private void LoadPendingTrips()
        {
            Products = Utils.BuildIndex("SELECT * FROM [Products]", "product_id");
            GridPanel manipanel = grdpendingtrip.PrimaryGrid;
            manipanel.DefaultRowHeight = 50;
            GridMainParent(manipanel);
            GridRow mainRow = new GridRow();
            foreach (DataRow dRow_loc in DataSupport.RunDataSet(@"SELECT DISTINCT trip_id,[authorized_receiver],[receiving_date],[releaseto]  FROM [ReleaseTrips] rt 
                                                                JOIN ReleaseTripDetails rtd on rt.trip_id = rtd.trip 
                                                                JOIN ReleaseOrders ro ON rtd.[order_id] = ro.order_id WHERE ro.status != 'RELEASED'").Tables[0].Rows)
            {
                mainRow = new GridRow();

                mainRow.Cells.Add(new GridCell(dRow_loc["trip_id"]));
                mainRow.Cells.Add(new GridCell(dRow_loc["authorized_receiver"]));
                mainRow.Cells.Add(new GridCell(dRow_loc["receiving_date"]));
                mainRow.Cells.Add(new GridCell(dRow_loc["releaseto"]));

                //mainRow.CellStyles.Default.Padding

                StringBuilder currentprod = new StringBuilder();
                GridPanel orderpanel = new GridPanel();
                GridColumn col = new GridColumn();
                col.HeaderText = "Order ID";
                col.Name = "order_id";
                col.EditorType = typeof(GridLabelXEditControl);
                col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCellsExceptHeader;
                orderpanel.Columns.Add(col);

                col = new GridColumn();
                col.HeaderText = "Order Date";
                col.Name = "order_date";
                col.AutoSizeMode = ColumnAutoSizeMode.AllCells;
                col.EditorType = typeof(GridLabelXEditControl); ;
                orderpanel.Columns.Add(col);

                col = new GridColumn();
                col.HeaderText = "Client";
                col.Name = "client";
                col.EditorType = typeof(GridLabelXEditControl);
                col.AutoSizeMode = ColumnAutoSizeMode.AllCells;
                orderpanel.Columns.Add(col);

                col = new GridColumn();
                col.HeaderText = "Reference Number";
                col.Name = "reference";
                col.EditorType = typeof(GridLabelXEditControl);
                col.AutoSizeMode = ColumnAutoSizeMode.AllCells;
                orderpanel.Columns.Add(col);

                col = new GridColumn();
                col.HeaderText = "Reference Date";
                col.Name = "reference_date";
                col.AutoSizeMode = ColumnAutoSizeMode.AllCells;
                col.EditorType = typeof(GridLabelXEditControl);
                orderpanel.Columns.Add(col);

                col = new GridColumn();
                col.HeaderText = "Status";
                col.Name = "status";
                col.EditorType = typeof(GridLabelXEditControl);
                col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCellsExceptHeader;
                col.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                col.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                orderpanel.Columns.Add(col);
                orderpanel.ShowTreeButtons = true;
                orderpanel.ShowTreeLines = true;
                orderpanel.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                orderpanel.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                orderpanel.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                orderpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                orderpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                orderpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.Padding = new DevComponents.DotNetBar.SuperGrid.Style.Padding(0, 5, 0, 5);
                orderpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                orderpanel.DefaultVisualStyles.GridPanelStyle.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                orderpanel.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                orderpanel.DefaultVisualStyles.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                orderpanel.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                orderpanel.RowDoubleClickBehavior = RowDoubleClickBehavior.ExpandCollapse;
                GridRow gRow_order = new GridRow();

                foreach (DataRow dRow_locprod in DataSupport.RunDataSet(String.Format("SELECT * FROM ReleaseTripDetails rtd JOIN ReleaseOrders ro ON rtd.order_id = ro.order_id WHERE trip = '{0}' and ro.status != 'RELEASED' order by ro.order_id", dRow_loc["trip_id"])).Tables[0].Rows)
                {
                    gRow_order = new GridRow();
                    //orderpanel = new GridPanel();

                    gRow_order.Cells.Add(new GridCell(dRow_locprod["order_id"]));
                    gRow_order.Cells.Add(new GridCell(dRow_locprod["order_date"]));
                    gRow_order.Cells.Add(new GridCell(dRow_locprod["client"]));
                    gRow_order.Cells.Add(new GridCell(dRow_locprod["reference"]));
                    gRow_order.Cells.Add(new GridCell(dRow_locprod["reference_date"]));
                    col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCellsExceptHeader;
                    gRow_order.Cells.Add(new GridCell(dRow_locprod["Status"]));

                    getInvoiceLedger(gRow_order, new List<string> { dRow_locprod["order_id"].ToStringNull() });
                    orderpanel.Rows.Add(gRow_order);
                }
                if (orderpanel.Rows.Count != 0)
                    mainRow.Rows.Add(orderpanel);

                manipanel.Rows.Add(mainRow);
            }
        }

        private void getInvoiceLedger(GridRow gRow, List<String> param)
        {
            GridPanel panel_prodloc = new GridPanel();
            GridColumn col = new GridColumn();
            col.HeaderText = "Product ID";
            col.Name = "product";
            col.EditorType = typeof(GridLabelXEditControl);
            panel_prodloc.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Description";
            col.Name = "description";
            col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            col.EditorType = typeof(GridLabelXEditControl);
            panel_prodloc.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "UOM";
            col.Name = "uom";
            col.EditorType = typeof(GridLabelXEditControl);
            panel_prodloc.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Qty";
            col.Name = "qty";
            col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            col.EditorType = typeof(GridLabelXEditControl);
            panel_prodloc.Columns.Add(col);

            GridRow gRow_prodloc = new GridRow();
            foreach (DataRow dRow_locprod in DataSupport.RunDataSet(String.Format("SELECT * FROM [ReleaseOrderDetails] WHERE release_order = '{0}' order by product", param[0])).Tables[0].Rows)
            {
                gRow_prodloc = new GridRow();
                gRow_prodloc.Cells.Add(new GridCell(dRow_locprod["product"]));
                DataRow s = null;
                if (Products.TryGetValue(dRow_locprod["product"].ToString(), out s))
                    gRow_prodloc.Cells.Add(new GridCell(s["description"]));

                gRow_prodloc.Cells.Add(new GridCell(dRow_locprod["uom"]));
                gRow_prodloc.Cells.Add(new GridCell(dRow_locprod["qty"]));
                panel_prodloc.Rows.Add(gRow_prodloc);
            }
            if (panel_prodloc.Rows.Count != 0)
                gRow.Rows.Add(panel_prodloc);
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
            col.HeaderText = (comboBox1.Text == "Items per Location") ? "Available Qty" : "Lot Number";
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
                        gRow_prodloc.Cells.Add(new GridCell(Convert.ToDateTime(dRow_locprod["expiry"]).ToShortDateString()));
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
            col.HeaderText = "Trip ID";
            col.Name = "trip_id";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Authorized Receiver";
            col.Name = "authorized_receiver";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Received Date";
            col.Name = "receiving_date";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Release To";
            col.Name = "releaseto";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);
        }
        #endregion

        #region Pending SO For Picking
        private void PendingSOPick()
        {
            Products = Utils.BuildIndex("SELECT * FROM [Products]", "product_id");
            GridPanel manipanel = grdorderpick.PrimaryGrid;
            GridMainParent(manipanel);
            GridRow mainRow = new GridRow();
            foreach (DataRow dRow_loc in DataSupport.RunDataSet(@"SELECT DISTINCT *  FROM [ReleaseTrips] rt 
                                                                JOIN ReleaseTripDetails rtd on rt.trip_id = rtd.trip 
                                                                JOIN ReleaseOrders ro ON rtd.[order_id] = ro.order_id WHERE ro.status = 'FOR PICKING'").Tables[0].Rows)
            {
                mainRow = new GridRow();

                mainRow.Cells.Add(new GridCell(dRow_loc["order_id"]));
                mainRow.Cells.Add(new GridCell(dRow_loc["order_date"]));
                mainRow.Cells.Add(new GridCell(dRow_loc["reference"]));
                mainRow.Cells.Add(new GridCell(dRow_loc["reference_date"]));

                //mainRow.CellStyles.Default.Padding

                StringBuilder currentprod = new StringBuilder();
                GridPanel orderpanel = new GridPanel();
                GridColumn col = new GridColumn();
                col.HeaderText = "PRODUCT";
                col.Name = "product";
                col.EditorType = typeof(GridLabelXEditControl);
                col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCellsExceptHeader;
                orderpanel.Columns.Add(col);

                col = new GridColumn();
                col.HeaderText = "DESCRIPTION";
                col.Name = "description";
                col.AutoSizeMode = ColumnAutoSizeMode.AllCells;
                col.EditorType = typeof(GridLabelXEditControl); ;
                orderpanel.Columns.Add(col);

                col = new GridColumn();
                col.HeaderText = "UOM";
                col.Name = "uom";
                col.EditorType = typeof(GridLabelXEditControl);
                col.AutoSizeMode = ColumnAutoSizeMode.AllCells;
                orderpanel.Columns.Add(col);

                col = new GridColumn();
                col.HeaderText = "QUANTITY";
                col.Name = "qty";
                col.EditorType = typeof(GridLabelXEditControl);
                col.AutoSizeMode = ColumnAutoSizeMode.AllCells;
                orderpanel.Columns.Add(col);

                orderpanel.ShowTreeButtons = true;
                orderpanel.ShowTreeLines = true;
                orderpanel.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                orderpanel.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                orderpanel.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                orderpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                orderpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                orderpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.Padding = new DevComponents.DotNetBar.SuperGrid.Style.Padding(0, 5, 0, 5);
                orderpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                orderpanel.DefaultVisualStyles.GridPanelStyle.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                orderpanel.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                orderpanel.DefaultVisualStyles.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                orderpanel.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                orderpanel.DefaultRowHeight = 40;
                orderpanel.RowDoubleClickBehavior = RowDoubleClickBehavior.ExpandCollapse;
                GridRow gRow_order = new GridRow();

                foreach (DataRow dRow_locprod in DataSupport.RunDataSet(String.Format("SELECT * FROM ReleaseTripDetails rtd JOIN ReleaseOrders ro ON rtd.order_id = ro.order_id WHERE trip = '{0}' and ro.status != 'RELEASED' order by ro.order_id", dRow_loc["trip_id"])).Tables[0].Rows)
                {
                    gRow_order = new GridRow();

                    getInvoiceLedger(gRow_order, new List<string> { dRow_locprod["order_id"].ToStringNull() });
                    orderpanel.Rows.Add(gRow_order);
                }
                if (orderpanel.Rows.Count != 0)
                    mainRow.Rows.Add(orderpanel);

                manipanel.Rows.Add(mainRow);
            }
        }
        #endregion
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
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
            if (cmbReports.Text == "TRANSACTION HISTORY")
            {
                reportviewer dialog = new reportviewer();
                DataTable dt = DataSupport.RunDataSet(@"SELECT distinct location,transaction_type,transaction_id,transaction_datetime,user_completename
                                                      FROM [LocationLedger] ORDER BY transaction_datetime ASC").Tables[0];
                CrystalDecisions.CrystalReports.Engine.ReportDocument rviewer = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rviewer = new crttransactionhistoryreport();
                rviewer.SetDataSource(dt);

                dialog.viewer.ReportSource = rviewer;
                dialog.viewer.RefreshReport();
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }

        private void btnStockCheck_Click(object sender, EventArgs e)
        {
            StockCheckingWindow dialog = new StockCheckingWindow();
            dialog.ShowDialog();
            LoadInventory();
        }
        private void btnNewCaseBreak_Click(object sender, EventArgs e)
        {
            BinReplishmentWindow dialog = new BinReplishmentWindow();
            dialog.ShowIcon = false;
            dialog.ShowInTaskbar = false;
            dialog.Icon = this.Icon;
            dialog.ShowDialog();
            LoadInventory();
            //NewCaseBreakWindow dialog = new NewCaseBreakWindow();
            //dialog.ShowIcon = false;
            //dialog.ShowInTaskbar = false;
            //dialog.Icon = this.Icon;
            //dialog.ShowDialog();
        }

        private void btnConfirmCaseBreak_Click(object sender, EventArgs e)
        {
            //DeclareCaseBreakPickListScanID dialog = new DeclareCaseBreakPickListScanID();
            //dialog.ShowIcon = false;
            //dialog.ShowInTaskbar = false;
            //dialog.Icon = this.Icon;
            //dialog.ShowDialog();
            //LoadInventory();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            BinMasterFile dialog = new BinMasterFile();
            dialog.ShowIcon = false;
            dialog.ShowInTaskbar = false;
            dialog.Icon = this.Icon;
            dialog.ShowDialog();
            LoadInventory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            newstocklocationtransfers dialog = new newstocklocationtransfers();
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewCaseBreak dialog = new NewCaseBreak();
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();
               
        }
    }
}
