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
        public DataTable mainoutstock = null;
        public DataTable mainoutstock_details = null;
        public StockCheckingWindow()
        {
            InitializeComponent();
        }

        private void btnStockCheck_Click(object sender, EventArgs e)
        {
            if (headerGrid.Rows.Count == 0)
                return;

            try
            {
                bool isselected = false;

                StringBuilder errormessage = new StringBuilder();

                foreach (GridRow row in grd.PrimaryGrid.GetSelectedRows())
                {
                    //foreach (DataRow searchrow in mainoutstock_details.Rows)
                    //{
                    //    if (searchrow["out_shipment_id"].ToString() == row.Cells["out_shipment_id"].Value.ToString())
                    //    {
                    //        if (int.Parse(searchrow["qty"].ToString()) > int.Parse(searchrow["aqty"].ToString()))
                    //        {
                    //            errormessage.Append(String.Format("Product code : {0}  you order {1} {2} available quantity is {3}\n", searchrow["product"].ToString(), int.Parse(searchrow["qty"].ToString()), searchrow["uom"].ToString(), int.Parse(searchrow["aqty"].ToString())));
                    //        }
                                                            
                    //    }
                    //}
                    //if(errormessage.Length > 1)
                    //{
                    //    MessageBox.Show(String.Format("Can't Reserve order {0}\n{1}" , row.Cells["out_shipment_id"].Value.ToString(),errormessage.ToString()));
                    //    return;
                    //}

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

                    header.Add("client", row.Cells["clientcode"].Value);
                    header.Add("reference", row.Cells["reference_no1"].Value);
                    header.Add("reference_date", row.Cells["reference_date1"].Value);
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
                if (isselected)
                    MessageBox.Show("Stock Check Complete");
                else
                    MessageBox.Show("Please select Order!");
                initializegrid();
                //dt = FAQ.GetOMSOutgoing();
                //headerGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

            mainoutstock_details = new DataTable();
            mainoutstock = new DataTable();
            mainoutstock.Columns.Add("out_shipment_id");
            mainoutstock.Columns.Add("out_shipment_date");
            mainoutstock.Columns.Add("reference_no1");
            mainoutstock.Columns.Add("reference_date1");
            mainoutstock.Columns.Add("client");
            mainoutstock.Columns.Add("customer_name");
            mainoutstock.Columns.Add("customer_invoice_address");
            mainoutstock.Columns.Add("authorized_tms");
            mainoutstock.Columns.Add("customer_id");
            mainoutstock.Columns.Add("invoice_amount");
            mainoutstock_details.Columns.Add("out_shipment_id");
            mainoutstock_details.Columns.Add("product");
            mainoutstock_details.Columns.Add("description");
            mainoutstock_details.Columns.Add("uom");
            mainoutstock_details.Columns.Add("qty");
            mainoutstock_details.Columns.Add("aqty");

            foreach (DataRow dRow in FAQ.GetOMSOutgoing().Rows)
            {
                mainRow = new GridRow();
                mainRow.RowHeight = 50;

                DataRow mos = mainoutstock.NewRow();
                mos["out_shipment_id"] = dRow["out_shipment_id"];
                mos["out_shipment_date"] = dRow["out_shipment_date"];
                mos["reference_no1"] = dRow["reference_no1"];                
                mos["reference_date1"] = dRow["reference_date1"];
                mos["client"] = dRow["clientcode"];
                mos["customer_name"] = dRow["customer_name"];
                mos["customer_invoice_address"] = dRow["customer_invoice_address"];
                mos["authorized_tms"] = dRow["authorized_tms"];
                mos["customer_id"] = dRow["customer_id"];
                mos["invoice_amount"] = dRow["invoice_amount"];
                mainoutstock.Rows.Add(mos);

                mainRow.Cells.Add(new GridCell(dRow["out_shipment_id"]));
                mainRow.Cells.Add(new GridCell(dRow["out_shipment_date"]));
                mainRow.Cells.Add(new GridCell(dRow["reference_no1"]));
                mainRow.Cells.Add(new GridCell(dRow["reference_date1"]));
                mainRow.Cells.Add(new GridCell(dRow["clientcode"]));
                mainRow.Cells.Add(new GridCell(dRow["customer_name"]));
                mainRow.Cells.Add(new GridCell(dRow["customer_invoice_address"]));
                mainRow.Cells.Add(new GridCell(dRow["authorized_tms"]));
                mainRow.Cells.Add(new GridCell(dRow["customer_id"]));
                mainRow.Cells.Add(new GridCell(dRow["invoice_amount"]));

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

                col = new GridColumn();
                col.HeaderText = "Available Quantity";
                col.Name = "aqty";
                col.AutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
                col.EditorType = typeof(GridLabelXEditControl);
                productpanel.Columns.Add(col);

                foreach (DataRow dRow_details in FAQ.GetOMSOutgoingDetails(dRow["out_shipment_id"].ToString()).Rows)
                {
                    DataRow dmos = mainoutstock_details.NewRow();
                    dmos["out_shipment_id"] = dRow["out_shipment_id"];
                    dmos["product"] = dRow_details["product"];
                    dmos["uom"] = dRow_details["uom"];
                    dmos["qty"] = dRow_details["expected_qty"];

                    gRow_prod = new GridRow();
                    gRow_prod.RowHeight = 50;
                    gRow_prod.Cells.Add(new GridCell(dRow_details["product"]));
                    gRow_prod.Cells.Add(new GridCell(DataSupport.RunDataSet(String.Format("SELECT top 1 description FROM Products WHERE product_id = '{0}'", dRow_details["product"])).Tables[0].Rows[0]["description"]));
                    gRow_prod.Cells.Add(new GridCell(dRow_details["uom"]));
                    gRow_prod.Cells.Add(new GridCell(dRow_details["expected_qty"]));
                    int qty = 0;
                    DataTable dt = null;

                    dt = DataSupport.RunDataSet(@"SELECT SUM((available_qty))[available_qty]
                        FROM LocationProductsLedger 
                        WHERE  product = @product AND uom = @uom
                        AND (available_qty) > 0
                        AND location !='RELEASED'
                        ", "product", dRow_details["product"], "uom", dRow_details["uom"]).Tables[0];

                    foreach (DataRow sitem in dt.Rows)
                    {
                        if (sitem["available_qty"] != DBNull.Value)
                            qty = int.Parse(sitem["available_qty"].ToString());
                    }
                    //foreach (DataRow cRow in mainoutstock_details.Rows)
                    //{
                    //    if(cRow["product"].ToString() == dRow_details["product"].ToString() && cRow["out_shipment_id"].ToString() == dRow["out_shipment_id"].ToString())
                    //    {
                    //        if (dRow_details["uom"].ToString().ToUpper() == "CS")
                    //        {
                    //            if(cRow["uom"].ToString() == "CS")
                    //            {
                    //                qty = qty - int.Parse(dRow_details["uom"].ToString());
                    //            }
                    //            else
                    //            {
                    //                //decimal conv = FAQ.HowManyPiecesInUOM(dRow_details["product"].ToString(), dRow_details["uom"].ToString());
                    //                //decimal s = Convert.ToDecimal((decimal)total_qty_to_be_replenish / conv);
                    //                //product_casebreak.Add(productdetails, (int)Math.Ceiling(s));

                    //            }
                    //        }
                    //        else
                    //        {
                    //            //qty = 
                    //        }
                    //    }
                    //}

                    gRow_prod.Cells.Add(new GridCell(qty));
                    dmos["aqty"] = qty;

                    productpanel.Rows.Add(gRow_prod);
                    mainoutstock_details.Rows.Add(dmos);
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
            col.HeaderText = "Invoice Number";
            col.Name = "reference_no1";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Invoice Date";
            col.Name = "reference_date1";
            col.EditorType = typeof(GridLabelXEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.HeaderText = "Client";
            col.Name = "clientcode";
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
            col.Name = "invoice_amount";
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
