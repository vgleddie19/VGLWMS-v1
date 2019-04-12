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
    public partial class ScanReleaseIDWindow : Form
    {
        public ScanReleaseIDWindow()
        {
            InitializeComponent();
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable order_dt = FAQ.GetTripDetails(txtBarcode.Text);
                if (order_dt.Rows.Count == 0)
                {
                    MessageBox.Show("Barcode not recognized");
                    txtBarcode.Text = "";
                    return;
                }

                // Populate 

                if (!FAQ.DoesReleasingExist(txtBarcode.Text))
                {

                    String release_id = DataSupport.GetNextMenuCodeInt("RL").ToString();
                    String trip_id = txtBarcode.Text;
                    String now = DateTime.Now.ToString();
                    String sql = "";

                    sql += DataSupport.GetInsert("Releases", Utils.ToDict(
                        "release_id", release_id
                        , "trip", trip_id
                        , "released_on", now
                        ));

                    foreach (DataRow row in order_dt.Rows)
                    {
                        String status = "FOR RELEASING";
                        if (order_dt.Rows.IndexOf(row) == 0)
                            status = "RELEASING";

                        sql += DataSupport.GetInsert("ReleaseDetails", Utils.ToDict(
                        "release", release_id
                        , "order_id", row["order_id"]
                        , "drop_sequence", row["drop_sequence"]
                        , "status", status
                        ));

                        DataTable items_dt = FAQ.GetPickedOrder(row["order_id"].ToString());
                        foreach (DataRow item_row in items_dt.Rows)
                        {
                            sql += DataSupport.GetInsert("ReleaseDetailItems", Utils.ToDict(
                                "release", release_id
                                , "line", items_dt.Rows.IndexOf(item_row)
                                , "order_id", item_row["order_id"]
                                , "product", item_row["product"]
                                , "expiry", item_row["expiry"]
                                , "lot_no", item_row["lot_no"]
                                , "order_qty", item_row["qty"]
                                , "uom", item_row["uom"]
                                , "scanned_qty", 0
                                ));
                        }

                    }
                    DataSupport.RunNonQuery(sql, IsolationLevel.ReadCommitted);
                }


                ReleasesWindow dialog = new ReleasesWindow();
                dialog.txtTrip.Text = txtBarcode.Text;
                dialog.ShowDialog();
            }
        }
    }
}
