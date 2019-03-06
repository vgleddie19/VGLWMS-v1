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
            try
            {
                var row = headerGrid.SelectedRows[0];

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
                MessageBox.Show("Stock Check Complete");
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
        }
    }
}
