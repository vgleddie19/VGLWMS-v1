using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework;

namespace WMS
{
    public partial class OrdersForResolutionsWindow : Form
    {
        public OrdersForResolutionsWindow()
        {
            InitializeComponent();
        }

        private void OrdersForResolutionsWindow_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        public void LoadData()
        {
            DataTable dt = DataSupport.RunDataSet(@"SELECT order_id[Order ID]
                                                       ,holding_transaction[Issue Source]
                                                       ,holding_datetime[Issue Datetime]
                                                       ,holding_reason[Reason]
	                                                   ,Customer
	                                                   ,Client
	                                                   ,total_invoice_amount[Invoice Value]
                                                       , status [Order Status]
                                                FROM ReleaseOrders 
                                                WHERE holding_transaction IS NOT NULL").Tables[0];
            
            header_grid.DataSource = dt;

            
        }

        private void btnReleaseAnyway_Click(object sender, EventArgs e)
        {
            var row = header_grid.SelectedRows[0];
            String order_id = row.Cells["Order ID"].Value.ToString();
            DataSupport.RunNonQuery("UPDATE ReleaseOrders SET status='FOR RELEASING' WHERE order_id= @id;  ", "id", order_id);
            LoadData();
        }

        public ReasonForCancellingWindow dialog = null;
        private void btnCancel_Click(object sender, EventArgs e)
        {

            dialog = new ReasonForCancellingWindow();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            CancelOrderConfirmation confirm_dialog = new CancelOrderConfirmation();
            confirm_dialog.parent = this;
            if (confirm_dialog.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
            if (confirm_dialog.btnCancel.Visible == false)
                DialogResult = DialogResult.OK;

            LoadData();

        }
    }
}
