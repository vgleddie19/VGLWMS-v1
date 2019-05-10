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
    public partial class StockCheckingWindow : Form
    {
        public StockCheckingWindow()
        {
            InitializeComponent();
        }

        private void btnStockCheck_Click(object sender, EventArgs e)
        {
            if (headerGrid.Rows.Count == 0)
                return;

            //try
            //{
                bool isselected = false;
                
                //bool isbinok = true;
                //foreach (GridRow row in grd.PrimaryGrid.GetSelectedRows())
                //{
                //    foreach (DataRow dRow in FAQ.GetOMSOutgoingDetails(row.Cells["out_shipment_id"].Value.ToString()).Rows)
                //    {
                //        isbinok = LedgerSupport.CheckBin(dRow["product"].ToString(), dRow["uom"].ToString(), dRow["expected_qty"].ToString());
                //        if (!isbinok)
                //            break;
                //    }
                //    if (!isbinok)
                //        break;
                //}
                //if (!isbinok)
                //{
                //    MessageBox.Show("Replenish the bin first before proceeding to stocks check!", "Unable to stock check");
                //    return;
                //}

                foreach (GridRow row in grd.PrimaryGrid.GetSelectedRows())
                {
                    isselected = true;
                    StringBuilder sql = new StringBuilder();
                    Dictionary<String, Object> header = new Dictionary<string, object>();
                    DataTable dt = FAQ.GetOMSOutgoingDetails(row.Cells["out_shipment_id"].Value.ToString());

                    if (FAQ.IsAlreadyDownloaded(row.Cells["out_shipment_id"].Value.ToString()))
                    {
                        LedgerSupport.StockCheck();
                        return;
                    }
                    String order_id = row.Cells["out_shipment_id"].Value.ToString();
                    header.Add("order_id", order_id);

                    header.Add("client", row.Cells["client"].Value);
                    header.Add("reference", row.Cells["document_reference"].Value);
                    header.Add("reference_date", row.Cells["document_reference_date"].Value);
                    header.Add("order_date", row.Cells["datetime"].Value);
                    header.Add("recipient", row.Cells["authorized_tms"].Value);
                    header.Add("customer", row.Cells["customer_id"].Value);
                    header.Add("oms_shipment_id", row.Cells["out_shipment_id"].Value);
                    sql.Append(DataSupport.GetInsert("ReleaseOrders", header));

                    foreach (DataRow detail_row in dt.Rows)
                    {
                        Dictionary<String, Object> detail = new Dictionary<string, object>();

                        detail.Add("release_order", order_id);
                        detail.Add("product", detail_row["product"]);
                        detail.Add("uom", detail_row["uom"]);
                        detail.Add("qty", detail_row["expected_qty"]);

                        sql.Append(DataSupport.GetInsert("ReleaseOrderDetails", detail));
                    }

                    DataSupport.RunNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);
                    LedgerSupport.StockCheck();
                }
                if(isselected)
                    MessageBox.Show("Stock Check Complete");
                else
                    MessageBox.Show("Please select Order!");
                initializegrid();
                //dt = FAQ.GetOMSOutgoing();
                //headerGrid.DataSource = dt;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void StockCheckingWindow_Load(object sender, EventArgs e)
        {
            var dt = FAQ.GetOMSOutgoing();
            headerGrid.DataSource = dt;

            initializegrid();
        }

        void initializegrid()
        {
            grd.PrimaryGrid.Rows.Clear();
            grd.PrimaryGrid.Columns.Clear();
            GridPanel mainpanel = grd.PrimaryGrid;
            initparentheadergrid(mainpanel);
            GridRow mainRow = new GridRow();
            foreach (DataRow dRow in FAQ.GetOMSOutgoing().Rows)
            {
                mainRow = new GridRow();
                mainRow.RowHeight = 50;

                mainRow.Cells.Add(new GridCell(dRow["out_shipment_id"]));
                mainRow.Cells.Add(new GridCell(dRow["datetime"]));
                mainRow.Cells.Add(new GridCell(dRow["document_reference"]));
                mainRow.Cells.Add(new GridCell(dRow["document_reference_date"]));
                mainRow.Cells.Add(new GridCell(dRow["client"]));
                mainRow.Cells.Add(new GridCell(dRow["customer_name"]));
                mainRow.Cells.Add(new GridCell(dRow["customer_invoice_address"]));
                mainRow.Cells.Add(new GridCell(dRow["authorized_tms"]));
                mainRow.Cells.Add(new GridCell(dRow["customer_id"]));
                mainRow.Cells.Add(new GridCell(dRow["totalA"]));

                GridPanel productpanel = new GridPanel();
                productpanel.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                productpanel.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                productpanel.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                productpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                productpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                productpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.Padding = new DevComponents.DotNetBar.SuperGrid.Style.Padding(0, 5, 0, 5);
                productpanel.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                productpanel.DefaultVisualStyles.GridPanelStyle.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                productpanel.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                productpanel.DefaultVisualStyles.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
                productpanel.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;

                GridRow gRow_prod = new GridRow();
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

                col = new GridColumn();
                col.HeaderText = "Unit of Measure";
                col.Name = "uom";
                col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
                col.EditorType = typeof(GridLabelXEditControl);
                productpanel.Columns.Add(col);

                col = new GridColumn();
                col.HeaderText = "Quantity";
                col.Name = "qty";
                col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
                col.EditorType = typeof(GridLabelXEditControl);
                productpanel.Columns.Add(col);

                foreach (DataRow dRow_details in FAQ.GetOMSOutgoingDetails(dRow["out_shipment_id"].ToString()).Rows)
                {
                    gRow_prod = new GridRow();
                    gRow_prod.RowHeight = 50;
                    gRow_prod.Cells.Add(new GridCell(dRow_details["product"]));
                    gRow_prod.Cells.Add(new GridCell(DataSupport.RunDataSet(String.Format("SELECT top 1 description FROM Products WHERE product_id = '{0}'", dRow_details["product"])).Tables[0].Rows[0]["description"]));
                    gRow_prod.Cells.Add(new GridCell(dRow_details["uom"]));
                    gRow_prod.Cells.Add(new GridCell(dRow_details["expected_qty"]));

                    productpanel.Rows.Add(gRow_prod);
                }

                mainRow.Rows.Add(productpanel);
                mainpanel.Rows.Add(mainRow);
            }
        }
        void initparentheadergrid(GridPanel panel)
        {
            panel.Columns.Clear();
            panel.Rows.Clear();
            GridColumn col = new GridColumn();
            col.HeaderText = "Document ID";
            col.Name = "out_shipment_id";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Document Date";
            col.Name = "datetime";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Reference Doc. #";
            col.Name = "document_reference";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Reference Date";
            col.Name = "document_reference_date";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Client Name";
            col.Name = "client";
            col.Width = 150;
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Customer Name";
            col.Name = "customer_name";
            col.Width = 250;
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Delivery Address";
            col.Name = "customer_invoice_address";
            col.EditorType = typeof(GridLabelXEditControl);
            col.Width = 250;
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "TMS";
            col.Name = "authorized_tms";
            col.EditorType = typeof(GridLabelXEditControl);
            col.Visible = false;
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "custid";
            col.Name = "customer_id";
            col.EditorType = typeof(GridLabelXEditControl);
            col.Visible = false;
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Invoice Amount";
            col.Name = "invoiceamount";
            col.EditorType = typeof(GridLabelXEditControl);
            col.Width = 250;
            panel.Columns.Add(col);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
