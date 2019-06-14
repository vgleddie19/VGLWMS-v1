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
    public partial class OrderHoldingWindow : Form
    {
        public OrderHoldingWindow()
        {
            InitializeComponent();
        }

        public Dictionary<String,DataTable> orders_dict = new Dictionary<string, DataTable>();
        public DataTable BadStockDT = new DataTable();
        public DeclarePicklistScanningWindow parent = null;

        private void SyncLacking()
        {
            foreach (DataGridViewRow row in products_grid.Rows)
            {
                int x = int.Parse(row.Cells["qty_ordered"].Value.ToString()) - int.Parse(row.Cells["qty_picked"].Value.ToString());
                if (x < 0)
                    x = 0;
                row.Cells["qty_lacking"].Value = x;
            }
        }

        private void LoadOrders()
        {
            orders_dict = new Dictionary<string, DataTable>();

            foreach (DataGridViewRow row in products_grid.Rows)
            {
                String product = row.Cells["product"].Value.ToString();
                orders_dict.Add(product, DataSupport.RunDataSet(
                    @"SELECT 
                        P.order_id[Order ID]
                        , R.total_invoice_amount[Total Invoice Amount]
                        , R.client[Client]
                        , R.customer[Customer]
                        , P.qty[Qty Ordered]
                        , 'ACTIVE'[Status]
                         FROM PicklistDetails P
                        INNER JOIN ReleaseOrders R ON R.order_id = P.order_id 

                        WHERE product = '"+product+@"'
                          AND uom = '"+ row.Cells["uom"].Value.ToString() + @"'
                          AND lot_no = '"+ row.Cells["lot_no"].Value.ToString() + @"'
                          AND expiry = '"+ row.Cells["expiry"].Value.ToString() + "'"
                    ).Tables[0]);
            }
        }

        private void OrderHoldingWindow_Load(object sender, EventArgs e)
        {
            SyncLacking();
            LoadOrders();
            SyncOrders();

        }


        private void SyncOrders()
        {
            if (products_grid.SelectedRows.Count == 0 || orders_dict.Count==0)
                return;

            var selected_row = products_grid.SelectedRows[0];
            String product = selected_row.Cells["product"].Value.ToString();
            DataTable dt = orders_dict[product];
            orders_grid.Columns.Clear();
            orders_grid.DataSource = dt;

        }

        private void products_grid_SelectionChanged(object sender, EventArgs e)
        {
            SyncOrders();
        }


        private void SyncProducts()
        {
            foreach (DataGridViewRow product_row in products_grid.Rows)
            {
                String product = product_row.Cells["product"].Value.ToString();
                DataTable dt = orders_dict[product];
                int qty_ordered = int.Parse(product_row.Cells["qty_ordered"].Value.ToString());
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Status"].ToString() == "HOLD")
                        qty_ordered -= int.Parse( row["Qty Ordered"].ToString());
                }
                product_row.Cells["qty_ordered"].Value = qty_ordered.ToString();
            }
            SyncLacking();
        }


        private void btnHoldOrder_Click(object sender, EventArgs e)
        {
            var selected_row = orders_grid.SelectedRows[0];
            String order_id = selected_row.Cells["Order ID"].Value.ToString();

            foreach (String key in orders_dict.Keys.ToList())
            {
                DataTable dt = orders_dict[key];
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Order ID"].ToString() == order_id)
                        row["Status"] = "HOLD";
                }
            }

            SyncProducts();
        }

        private void btnActivateSelectedOrder_Click(object sender, EventArgs e)
        {
            var selected_row = orders_grid.SelectedRows[0];
            String order_id = selected_row.Cells["Order ID"].Value.ToString();

            foreach (String key in orders_dict.Keys.ToList())
            {
                DataTable dt = orders_dict[key];
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Order ID"].ToString() == order_id)
                        row["Status"] = "ACTIVE";
                }
            }

            SyncProducts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int qty_lacking = 0;
            foreach (DataGridViewRow row in products_grid.Rows)
            {
                qty_lacking += int.Parse(row.Cells["qty_lacking"].Value.ToString());
            }
            if (qty_lacking > 0)
            {
                MessageBox.Show("Qty Lacking must be Zero");
                return;
            }



            DeclarePicklistIncompleteConfirmationWindow dialog = new DeclarePicklistIncompleteConfirmationWindow();
            dialog.parent = this;
            if (dialog.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
            if (dialog.btnCancel.Visible == false)
                DialogResult = DialogResult.OK;


        }
    }
}
