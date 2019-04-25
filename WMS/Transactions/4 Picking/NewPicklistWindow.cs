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
    public partial class NewPicklistWindow : Form
    {
        DataTable dt = null;        
        public NewPicklistWindow()
        {
            InitializeComponent();
            picklist_grid.Rows.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (order_details_grid.Rows.Count == 0)
                return;

             if (order_details_grid.SelectedRows[0].Cells["ADDED"].Value.ToString() == "YES")
            {
                MessageBox.Show("Order is already Added");
                return;
            }

            String order_id = order_details_grid.SelectedRows[0].Cells["ORDER ID"].Value.ToString();
            DataTable dt = DataSupport.RunDataSet("SELECT * FROM ReleaseOrderDetails WHERE release_order = @order_id", "order_id", order_id).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                DataTable reservedDT = FAQ.WhereAreReservedProductsInWarehouse(row["product"].ToString(), row["uom"].ToString());
                int qty_to_be_picked = int.Parse(row["qty"].ToString());

                foreach (DataRow reserved_row in reservedDT.Rows)
                {
                    foreach (DataGridViewRow picklist_row in picklist_grid.Rows)
                    {
                        if (
                            picklist_row.Cells["location"].Value.ToString() == reserved_row["location"].ToString()
                         && picklist_row.Cells["lot_no"].Value.ToString() == reserved_row["lot_no"].ToString()
                          && picklist_row.Cells["product"].Value.ToString() == row["product"].ToString()
                          && picklist_row.Cells["uom"].Value.ToString() == row["uom"].ToString()
                         && picklist_row.Cells["expiry"].Value.ToString() == reserved_row["expiry"].ToString()
                         && picklist_row.Cells["order_id"].Value.ToString() == row["release_order"].ToString()
                            )
                        {
                            reserved_row["reserved_qty"] = int.Parse(reserved_row["reserved_qty"].ToString()) - int.Parse(picklist_row.Cells["qty"].Value.ToString());
                        }
                    }

                    if (int.Parse(reserved_row["reserved_qty"].ToString()) <= 0)
                        continue; 

                    int reserved_qty = int.Parse(reserved_row["reserved_qty"].ToString());
                    if (qty_to_be_picked < reserved_qty)
                        reserved_qty = qty_to_be_picked;


                    picklist_grid.Rows.Add(order_id, row["product"].ToString(), DataSupport.RunDataSet("SELECT TOP 1 * FROM Products WHERE product_id = @product_id", "product_id", row["product"].ToString()).Tables[0].Rows[0]["description"],  row["uom"], reserved_qty, reserved_row["lot_no"], reserved_row["expiry"], reserved_row["location"]);
                    qty_to_be_picked -= reserved_qty;
                    if (qty_to_be_picked <= 0)
                        break;
                }               
            }
            order_details_grid.SelectedRows[0].Cells["ADDED"].Value = "YES";
            picklist_grid.Select();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (order_details_grid.Rows.Count == 0)
                return;

            if (order_details_grid.SelectedRows[0].Cells["ADDED"].Value.ToString() == "NO")
            {
                MessageBox.Show("Order is not Added");
                return;
            }

            String order_id = order_details_grid.SelectedRows[0].Cells["ORDER ID"].Value.ToString();

            List<DataGridViewRow> for_deletion = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in picklist_grid.Rows)
            {
                if (row.Cells["order_id"].Value.ToString() == order_id)
                    for_deletion.Add(row);
            }

            foreach (var row in for_deletion)
                picklist_grid.Rows.Remove(row);


            order_details_grid.SelectedRows[0].Cells["ADDED"].Value = "NO";

        }

        private void NewPicklistWindow_Load(object sender, EventArgs e)
        {
            dt = DataSupport.RunDataSet("SELECT order_id[ORDER ID], client[CLIENT], reference[DOCUMENT REF ID], recipient[RECIPIENT], 'NO' [ADDED]  FROM ReleaseOrders WHERE status = 'FOR PICKING' ORDER BY order_date ASC").Tables[0];
            order_details_grid.DataSource = dt;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (picklist_grid.Rows.Count >= 1)
            {
                NewPicklistConfirmationWindow dialog = new NewPicklistConfirmationWindow();
                dialog.parent = this;
                if (dialog.ShowDialog() == DialogResult.OK)
                    DialogResult = DialogResult.OK;
            }
            //if (dialog.btnCancel.Visible == false)
            //    DialogResult = DialogResult.OK;
        }

        private void order_details_grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                btnAdd.Select();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
