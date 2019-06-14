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
    public partial class MakeReleaseOrderWindow : Form
    {
        public MakeReleaseOrderWindow()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var header =  JSONSupport.DeserializeObject(textBox1.Text);
            var details = JSONSupport.DeserializeToDataTable(header["details"].ToString());
            details.Columns.Add("release_order");
            header.Remove("details");

            String order_id = DataSupport.GetNextMenuCodeInt("ORD");
            header.Add("order_id", order_id);

            foreach (DataRow row in details.Rows)
                row["release_order"] = order_id;
            String sql = DataSupport.GetInsert("ReleaseOrders", header);
            foreach (DataRow row in details.Rows)
            {
                var detail = row.AsDictionary<String, Object>();
                sql += DataSupport.GetInsert("ReleaseOrderDetails", detail);
            }
            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("Success");
        }

        private void btnStockCheck_Click(object sender, EventArgs e)
        {
            DataTable ordersDT = DataSupport.RunDataSet("SELECT * FROM ReleaseOrders WHERE status = 'FOR STOCK CHECKING'").Tables[0];

            foreach (DataRow row in ordersDT.Rows)
            {
                var order_id = row["order_id"].ToString();
                var result = FAQ.DoesOrderHaveStocks(order_id);

                if (result == false)
                {
                    MessageBox.Show("Can't Reserve order " + order_id);
                    continue;
                }

                String sql = " UPDATE ReleaseOrders SET status = 'FOR SCHEDULING' WHERE order_id = '"+order_id+"'; ";

                DataTable detailsDT = FAQ.GetOrderDetails(order_id);
                foreach (DataRow detail in detailsDT.Rows)
                {
                    var dt= FAQ.WhereAreProductsInWarehouse(detail["product"].ToString(), detail["uom"].ToString());
                    
                    int qty_to_be_reserved = int.Parse(detail["qty"].ToString());

                    foreach (DataRow selected_row in dt.Rows)
                    {
                        int qty_in_location = int.Parse(selected_row["available_qty"].ToString());
                        int qty_reserved = qty_in_location;
                        if (qty_to_be_reserved < qty_in_location)
                            qty_reserved = qty_to_be_reserved;

                        

                        sql += " UPDATE LocationProductsLedger SET reserved_qty = reserved_qty + " + qty_reserved +
                               " WHERE product = '" + detail["product"].ToString() + "' AND uom = '" + detail["uom"].ToString() + "' " +
                               " AND lot_no = '" + selected_row["lot_no"].ToString() + "' AND expiry = '" + selected_row["expiry"].ToString() + "' " +
                               " AND location='" + selected_row["location"].ToString() + "'; ";

                        qty_to_be_reserved -= qty_reserved;
                        if (qty_to_be_reserved <= 0)
                            break;

                    }


                }

                DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
                MessageBox.Show("It works");
            }

        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            DataTable ordersDT = DataSupport.RunDataSet("SELECT * FROM ReleaseOrders WHERE status = 'FOR SCHEDULING'").Tables[0];

            String trip_id = new Random().Next(1, 2000000).ToString();
            // Eddie
            String sql = " INSERT INTO ReleaseTrips VALUES ('"+trip_id+"', 'FOR RELEASING', 'RANDOM GUY', '"+DateTime.Now.AddDays(5).ToShortDateString()+"' )";

            foreach (DataRow row in ordersDT.Rows)
            {
                // Eddie
                sql += " INSERT INTO ReleaseTripDetails VALUES('" + trip_id + "', '" + row["order_id"] + "', '"+ordersDT.Rows.IndexOf(row)+"'); ";
                // Ours
                sql += " UPDATE ReleaseOrders SET status='FOR PICKING', scheduled_release_date ='" + DateTime.Now.AddDays(5).ToShortDateString() + "' WHERE order_id ='" + row["order_id"]+"' ";
            }

            DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
            MessageBox.Show("TMS Schedule Received!");
            textBox2.Text = trip_id;
        }

        private void MakeReleaseOrderWindow_Load(object sender, EventArgs e)
        {
            textBox1.Text = @"{
""client"":""steven"",
""reference"":""DD1234"",
""reference_date"":""Jan 18, 2018"",
""order_date"":""Jul 4, 2018"",
""recipient"":""VGL-TMS1111"",
""total_invoice_amount"":""10000"",
""customer"":""Eddie"",

""details"":
  [
    {""product"":""NPC23"",""uom"":""CS"",""qty"":""2""}
  ]
}";
        }
    }
}
