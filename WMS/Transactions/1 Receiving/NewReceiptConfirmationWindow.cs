using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS
{   
    public partial class NewReceiptConfirmationWindow : Form
    {
        public NewReceiptsWindow parent = null;
        DataTable receivingreport = null;
        public DataTable oms_productrec = null;
        DataTable discrepancy = new DataTable();
        Dictionary<String, int> uomqty = new Dictionary<string, int>();
        List<String> listuom = null;

        #region form initialization
        public NewReceiptConfirmationWindow()
        {
            InitializeComponent();
        }

        private void NewReceiptConfirmationWindow_Load(object sender, EventArgs e)
        {
            listuom = new List<string>();
            listuom.Add("CS");
            foreach (DataRow dRow in Connection.GetOMSConnection.ExecuteDataSet("SELECT DISTINCT [uom],qty FROM [itemPrice] WHERE uom != 'PC' AND uom != 'CS' ORDER BY uom,qty").Tables[0].Rows)
                listuom.Add(dRow["uom"].ToString());
            listuom.Add("PC");


            btnPrintPreview.Select();
            receivingreport = new DataTable();
            receivingreport.Columns.Add("rrno");
            receivingreport.Columns.Add("shippingid");
            receivingreport.Columns.Add("receivedby");
            receivingreport.Columns.Add("receivedon", typeof(DateTime));
            receivingreport.Columns.Add("receivedfrom");
            receivingreport.Columns.Add("refno");
            receivingreport.Columns.Add("refdate", typeof(DateTime));
            receivingreport.Columns.Add("remarks");
            receivingreport.Columns.Add("Product");
            receivingreport.Columns.Add("desc");
            receivingreport.Columns.Add("Qty", typeof(int));
            receivingreport.Columns.Add("Uom");
            receivingreport.Columns.Add("Lot");
            receivingreport.Columns.Add("Expiry", typeof(DateTime));
            receivingreport.Columns.Add("prodremarks");
            receivingreport.Columns.Add("hasdiscrepancy", typeof(Boolean));
            receivingreport.Columns.Add("shippername");
            receivingreport.Columns.Add("vanno");

            discrepancy = new DataTable();
            discrepancy.Columns.Add("shippingid");
            discrepancy.Columns.Add("receivedby");
            discrepancy.Columns.Add("receivedon", typeof(DateTime));
            discrepancy.Columns.Add("receivedfrom");
            discrepancy.Columns.Add("refno");
            discrepancy.Columns.Add("refdate", typeof(DateTime));
            discrepancy.Columns.Add("remarks");
            discrepancy.Columns.Add("Product");
            discrepancy.Columns.Add("desc");
            discrepancy.Columns.Add("qty", typeof(int));
            discrepancy.Columns.Add("uom");
            discrepancy.Columns.Add("qtyactual", typeof(int));
            discrepancy.Columns.Add("uomactual");
            discrepancy.Columns.Add("Lot");
            discrepancy.Columns.Add("Expiry", typeof(DateTime));
            discrepancy.Columns.Add("prodremarks");
            discrepancy.Columns.Add("shortage");
            discrepancy.Columns.Add("overage");
            discrepancy.Columns.Add("totalperskuover");
            discrepancy.Columns.Add("totalperskushort");
            discrepancy.Columns.Add("isextracopy",typeof(Boolean));

            foreach (DataGridViewRow row in parent.headerGrid.Rows)
            {
                if (oms_productrec != null)
                {
                    if (row.Cells["_lineno"].Value.ToString() != "")
                    {
                        if (Convert.ToInt32(row.Cells["quantity"].Value) >= 1)
                        {
                            receivingreport.Rows.Add(parent.txtrrno.Text, "(issued on save)", parent.cboreceivedby.Text, parent.dtpreceivedon.Value.ToShortDateString(), parent.cboreceivedfrom.Text, parent.txtrefno.Text
                                                     , parent.dtprefdate.Value.ToShortDateString(), parent.txtremarks.Text, row.Cells["product_id"].Value, row.Cells["product"].Value, row.Cells["quantity"].Value, row.Cells["uom"].Value
                                                     , row.Cells["lot"].Value, Convert.ToDateTime(row.Cells["expiry"].Value).ToShortDateString(), row.Cells["remarks"].Value, true, parent.txtshippername.Text, parent.txtvanno.Text);

                            if (uomqty.ContainsKey(row.Cells["uom"].Value.ToString()) && row.Cells["uom"].Value.ToString() != "")
                                uomqty[row.Cells["uom"].Value.ToString()] = uomqty[row.Cells["uom"].Value.ToString()] + Convert.ToInt32(row.Cells["quantity"].Value.ToString());
                            else
                                uomqty.Add(row.Cells["uom"].Value.ToString(), Convert.ToInt32(row.Cells["quantity"].Value));
                        }
                        foreach (DataRow drow in oms_productrec.Select(String.Format("(product = '{0}' AND lot_no = '{1}' AND expiry = '{2}' AND _lineno = '{3}') AND (uom <> '{4}' OR expected_qty <> '{5}')", row.Cells["product_id"].Value, row.Cells["lot"].Value, row.Cells["expiry"].Value, row.Cells["_lineno"].Value, row.Cells["uom"].Value, row.Cells["quantity"].Value)))
                        {
                            int qty = 0;
                            if (row.Cells["uom"].Value == drow["uom"])
                            {
                                if (Convert.ToInt32(drow["expected_qty"]) > Convert.ToInt32(row.Cells["quantity"].Value))
                                {
                                    qty = Convert.ToInt32(drow["expected_qty"]) - Convert.ToInt32(row.Cells["quantity"].Value);
                                    discrepancy.Rows.Add("(issued on save)", parent.cboreceivedby.Text, parent.dtpreceivedon.Value.ToShortDateString(), parent.cboreceivedfrom.Text, "(issued on save)"
                                                         , DateTime.Now.ToShortDateString(), parent.txtremarks.Text, row.Cells["product_id"].Value, row.Cells["product"].Value, drow["expected_qty"], drow["uom"]
                                                         , row.Cells["quantity"].Value, row.Cells["uom"].Value, row.Cells["lot"].Value, Convert.ToDateTime(row.Cells["expiry"].Value).ToShortDateString(), row.Cells["remarks"].Value, qty, null);
                                }
                                else
                                {
                                    qty = Convert.ToInt32(row.Cells["quantity"].Value) - Convert.ToInt32(drow["expected_qty"]);
                                    discrepancy.Rows.Add("(issued on save)", parent.cboreceivedby.Text, parent.dtpreceivedon.Value.ToShortDateString(), parent.cboreceivedfrom.Text, "(issued on save)"
                                                         , DateTime.Now.ToShortDateString(), parent.txtremarks.Text, row.Cells["product_id"].Value, row.Cells["product"].Value, drow["expected_qty"], drow["uom"]
                                                          , row.Cells["quantity"].Value, row.Cells["uom"].Value, row.Cells["lot"].Value, Convert.ToDateTime(row.Cells["expiry"].Value).ToShortDateString(), row.Cells["remarks"].Value, null, qty);

                                }
                            }
                            else
                            {
                                //discrepancy.Rows.Add("(issued on save)", parent.cboreceivedby.Text, parent.dtpreceivedon.Value.ToShortDateString(), parent.cboreceivedfrom.Text, "(issued on save)"
                                //                     , DateTime.Now.ToShortDateString(), parent.txtremarks.Text, row.Cells["product_id"].Value, row.Cells["product"].Value, drow["expected_qty"], drow["uom"]
                                //                     , row.Cells["quantity"].Value, row.Cells["uom"].Value, row.Cells["lot"].Value, Convert.ToDateTime(row.Cells["expiry"].Value).ToShortDateString(), row.Cells["remarks"].Value, drow["expected_qty"], row.Cells["quantity"].Value);

                                discrepancy.Rows.Add("(issued on save)", parent.cboreceivedby.Text, parent.dtpreceivedon.Value.ToShortDateString(), parent.cboreceivedfrom.Text, "(issued on save)"
                                                     , DateTime.Now.ToShortDateString(), parent.txtremarks.Text, row.Cells["product_id"].Value, row.Cells["product"].Value, drow["expected_qty"], drow["uom"]
                                                     , 0, row.Cells["uom"].Value, row.Cells["lot"].Value, Convert.ToDateTime(row.Cells["expiry"].Value).ToShortDateString(), row.Cells["remarks"].Value, drow["expected_qty"], null);

                                discrepancy.Rows.Add("(issued on save)", parent.cboreceivedby.Text, parent.dtpreceivedon.Value.ToShortDateString(), parent.cboreceivedfrom.Text, "(issued on save)"
                                                     , DateTime.Now.ToShortDateString(), parent.txtremarks.Text, row.Cells["product_id"].Value, row.Cells["product"].Value, 0, drow["uom"]
                                                     , row.Cells["quantity"].Value, row.Cells["uom"].Value, row.Cells["lot"].Value, Convert.ToDateTime(row.Cells["expiry"].Value).ToShortDateString(), row.Cells["remarks"].Value, null, row.Cells["quantity"].Value);
                            }
                        }
                    }
                    else
                    {
                        discrepancy.Rows.Add("(issued on save)", parent.cboreceivedby.Text, parent.dtpreceivedon.Value.ToShortDateString(), parent.cboreceivedfrom.Text, "(issued on save)"
                                             , DateTime.Now.ToShortDateString(), parent.txtremarks.Text, row.Cells["product_id"].Value, row.Cells["product"].Value, 0, row.Cells["uom"].Value
                                             , row.Cells["quantity"].Value, row.Cells["uom"].Value, row.Cells["lot"].Value, Convert.ToDateTime(row.Cells["expiry"].Value).ToShortDateString(), row.Cells["remarks"].Value, null, row.Cells["quantity"].Value);
                    }
                }
                else
                {
                    if (Convert.ToInt32(row.Cells["quantity"].Value) >= 1)
                    {
                        receivingreport.Rows.Add(parent.txtrrno.Text, "(issued on save)", parent.cboreceivedby.Text, parent.dtpreceivedon.Value.ToShortDateString(), parent.cboreceivedfrom.Text, parent.txtrefno.Text
                                                 , parent.dtprefdate.Value.ToShortDateString(), parent.txtremarks.Text, row.Cells["product_id"].Value, row.Cells["product"].Value, row.Cells["quantity"].Value, row.Cells["uom"].Value
                                                 , row.Cells["lot"].Value, Convert.ToDateTime(row.Cells["expiry"].Value).ToShortDateString(), row.Cells["remarks"].Value, false, parent.txtshippername.Text, parent.txtvanno.Text);

                        if (uomqty.ContainsKey(row.Cells["uom"].Value.ToString()) && row.Cells["uom"].Value.ToString() != "")
                            uomqty[row.Cells["uom"].Value.ToString()] = uomqty[row.Cells["uom"].Value.ToString()] + Convert.ToInt32(row.Cells["quantity"].Value.ToString());
                        else
                            uomqty.Add(row.Cells["uom"].Value.ToString(), Convert.ToInt32(row.Cells["quantity"].Value));
                    }
                }
            }

            Dictionary<String, int> orderuomqty = new Dictionary<string, int>();
            foreach (String item in listuom)
            {
                if(uomqty.ContainsKey(item))
                {
                    orderuomqty.Add(item, uomqty[item]);
                }
            }

            StringBuilder summaryuomqty = new StringBuilder();
            int count = 1;
            foreach (KeyValuePair<string, int> item in orderuomqty)
            {
                if (orderuomqty.Count != count)
                    summaryuomqty.Append(String.Format("{0}={1}, ", item.Key, item.Value));
                else
                    summaryuomqty.Append(String.Format("{0}={1}", item.Key, item.Value));

                count++;
            }

            bool isdiscrepancy = false;

            if (discrepancy.Rows.Count >= 1)
            {
                //grd.DataSource = discrepancy;
                Dictionary<String, int> uomqtyover = new Dictionary<string, int>();
                Dictionary<String, int> uomqtyshort = new Dictionary<string, int>();
                foreach (DataRow drow in discrepancy.Rows)
                {
                    if (drow["uom"] == drow["uomactual"])
                    {
                        if (Convert.ToInt32(drow["qty"]) > Convert.ToInt32(drow["qtyactual"].ToString()))
                        {
                            int shorts = (Convert.ToInt32(drow["qty"].ToString()) - Convert.ToInt32(drow["qtyactual"].ToString()));
                            if (uomqtyshort.ContainsKey(drow["uom"].ToString()))
                                uomqtyshort[drow["uom"].ToString()] = uomqtyshort[drow["uom"].ToString()] + shorts;
                            else
                                uomqtyshort.Add(drow["uom"].ToString(), shorts);
                        }
                        else
                        {
                            int over = (Convert.ToInt32(drow["qtyactual"].ToString()) - Convert.ToInt32(drow["qty"].ToString()));
                            if (uomqtyover.ContainsKey(drow["uomactual"].ToString()))
                                uomqtyover[drow["uomactual"].ToString()] = uomqtyover[drow["uomactual"].ToString()] + over;
                            else
                                uomqtyover.Add(drow["uomactual"].ToString(), over);
                        }
                    }
                    else
                    {
                        if (uomqtyshort.ContainsKey(drow["uom"].ToString()))
                            uomqtyshort[drow["uom"].ToString()] = uomqtyshort[drow["uom"].ToString()] + Convert.ToInt32(drow["qty"].ToString());
                        else
                            uomqtyshort.Add(drow["uom"].ToString(), Convert.ToInt32(drow["qty"].ToString()));

                        //MessageBox.Show(drow["qty"].ToString());

                        if (uomqtyover.ContainsKey(drow["uomactual"].ToString()))
                            uomqtyover[drow["uomactual"].ToString()] = uomqtyover[drow["uomactual"].ToString()] + Convert.ToInt32(drow["qtyactual"].ToString());
                        else
                            uomqtyover.Add(drow["uomactual"].ToString(), Convert.ToInt32(drow["qtyactual"].ToString()));
                    }
                }

                Dictionary<String, int> orderuomqtyover = new Dictionary<string, int>();
                foreach (String item in listuom)
                {
                    if (uomqtyover.ContainsKey(item))
                    {
                        orderuomqtyover.Add(item, uomqtyover[item]);
                    }
                }
                StringBuilder summaryuomqtyover = new StringBuilder();
                count = 1;
                foreach (KeyValuePair<string, int> item in orderuomqtyover)
                {
                    if (orderuomqtyover.Count != count)
                        summaryuomqtyover.Append(String.Format("{0}={1}, ", item.Key, item.Value));
                    else
                        summaryuomqtyover.Append(String.Format("{0}={1}", item.Key, item.Value));

                    count++;
                }

                Dictionary<String, int> orderuomqtyshort = new Dictionary<string, int>();
                foreach (String item in listuom)
                {
                    if (uomqtyshort.ContainsKey(item))
                    {
                        orderuomqtyshort.Add(item, uomqtyshort[item]);
                    }
                }
                StringBuilder summaryuomqtyshort = new StringBuilder();
                count = 1;
                foreach (KeyValuePair<string, int> item in orderuomqtyshort)
                {
                    if (orderuomqtyshort.Count != count)
                        summaryuomqtyshort.Append(String.Format("{0}={1}, ", item.Key, item.Value));
                    else
                        summaryuomqtyshort.Append(String.Format("{0}={1}", item.Key, item.Value));
                    count++;
                }

                discrepancy.Columns.Remove("totalperskuover");
                DataColumn dc = new DataColumn("totalperskuover");
                dc.DefaultValue = summaryuomqtyover.ToString(); ;
                discrepancy.Columns.Add(dc);

                discrepancy.Columns.Remove("totalperskushort");
                dc = new DataColumn("totalperskushort");
                dc.DefaultValue = summaryuomqtyshort.ToString(); ;
                discrepancy.Columns.Add(dc);

                discrepancy.Columns.Remove("isextracopy");
                dc = new DataColumn("isextracopy", typeof(Boolean));
                dc.DefaultValue = false;
                discrepancy.Columns.Add(dc);


                discrepancyform dialog = new discrepancyform();
                dialog.discrepancy = discrepancy;
                dialog.StartPosition = FormStartPosition.CenterScreen;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    discrepancy = dialog.discrepancy;
                    isdiscrepancy = true;
                }
            }
            else
            {
                discrepancy = null;
                isdiscrepancy = true;
            }

            if (isdiscrepancy)
            {
                CrystalDecisions.CrystalReports.Engine.ReportDocument rviewer = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rviewer = new crtreceivingreport();

                rviewer.SetDataSource(receivingreport);
                if (discrepancy != null)
                    rviewer.Subreports["crtdiscrepancyreport.rpt"].SetDataSource(discrepancy);
                rviewer.SetParameterValue("totalperskuuomqty", summaryuomqty.ToString());
                rviewer.SetParameterValue("watermarks", "");
                viewer.ReportSource = rviewer;
            }
            else
                this.Close();
        }
        #endregion

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (btnPrintPreview.Text != "Print")
            {
                SaveData();
            }
            else
            {
                viewer.PrintReport();
            }
        }

        private void SaveData()
        {
            String id = DataSupport.GetNextMenuCodeInt("RC");
            String discrepancy_id = DataSupport.GetNextMenuCodeInt("DCP");

            // Save Transaction
            StringBuilder sql = new StringBuilder();
                sql.Append(DataSupport.GetInsert("Receipts", Utils.ToDict(
                "receipt_id", id
               , "rrno", parent.txtrrno.Text
               , "received_from", parent.cboreceivedfrom.Text
               , "received_on", parent.dtpreceivedon.Value.ToShortDateString()
               , "received_by", parent.cboreceivedby.Text
               , "empid", parent.cboreceivedby.SelectedValue
               , "encoded_on", DateTime.Now
               , "sourceid", parent.cboreceivedfrom.SelectedValue
               , "sourceaddress", parent.lblclientadd.Text
               , "sourcetype", (parent.rbCustomer.Checked) ?  "CUSTOMER":"CLIENT"
               , "refno", parent.txtrefno.Text
               , "refdate", parent.dtprefdate.Value.ToShortDateString()
               , "remarks", parent.txtremarks.Text
               ,"shippername", parent.txtshippername.Text
               ,"vanno", parent.txtvanno .Text
                )));

            foreach (DataGridViewRow row in parent.headerGrid.Rows)
            {
                if (Convert.ToInt32(row.Cells["quantity"].Value) >= 1)
                {
                    sql.Append(DataSupport.GetInsert("ReceiptDetails", Utils.ToDict(
                      "receipt", id
                     , "line", parent.headerGrid.Rows.IndexOf(row) + 1
                     , "product", row.Cells["product_id"].Value.ToString()
                     , "qty", row.Cells["Quantity"].Value.ToString()
                     , "uom", row.Cells["uom"].Value.ToString()
                     , "lot_no", row.Cells["lot"].Value.ToString()
                     , "expiry", row.Cells["expiry"].Value.ToString()
                     , "remarks", row.Cells["remarks"].Value.ToString())));
                }
            }
            if (discrepancy != null)
            {
                if (discrepancy.Rows.Count >= 1)
                {
                    discrepancy.Columns.Remove("shippingid");
                    DataColumn dc = new DataColumn("shippingid");
                    dc.DefaultValue = discrepancy_id;
                    discrepancy.Columns.Add(dc);

                    discrepancy.Columns.Remove("refno");
                    dc = new DataColumn("refno");
                    dc.DefaultValue = id;
                    discrepancy.Columns.Add(dc);


                    sql.Append(DataSupport.GetInsert("Discrepancy", Utils.ToDict(
                                                        "discrepancy_id", discrepancy_id
                                                       , "received_from", parent.cboreceivedfrom.Text
                                                       , "received_on", parent.dtpreceivedon.Value.ToShortDateString()
                                                       , "received_by", parent.cboreceivedby.Text
                                                       , "empid", parent.cboreceivedby.SelectedValue
                                                       , "encoded_on", DateTime.Now
                                                       , "sourceid", parent.cboreceivedfrom.SelectedValue
                                                       , "sourceaddress", parent.lblclientadd.Text
                                                       , "sourcetype", (parent.rbCustomer.Checked) ? "CUSTOMER" : "CLIENT"
                                                       , "refno", discrepancy.Rows[0]["refno"].ToString()
                                                       , "refdate", discrepancy.Rows[0]["refdate"].ToString()
                                                       , "remarks", discrepancy.Rows[0]["remarks"].ToString()
                                                        )));

                    int lineno = 0;
                    foreach (DataRow row in discrepancy.Rows)
                    {
                        lineno++;
                        sql.Append(DataSupport.GetInsert("DiscrepancyDetails", Utils.ToDict(
                          "discrepancy", discrepancy_id
                         , "line", lineno
                         , "product", row["product"].ToString()
                         , "qty", row["qty"].ToString()
                         , "uom", row["uom"].ToString()
                         , "qtyactual", row["qtyactual"].ToString()
                         , "uomactual", row["uomactual"].ToString()
                         , "lot_no", row["lot"].ToString()
                         , "expiry", row["expiry"].ToString()
                         , "remarks", row["prodremarks"].ToString())));
                    }

                }
            }
            // Update Location Ledger
            sql.Append(DataSupport.GetInsert("LocationLedger", Utils.ToDict(
                "location", "STAGING-IN"
               , "transaction_datetime", parent.dtpreceivedon.Value.ToShortDateString()
               , "transaction_type", "IN"
               , "transaction_name", "RECEIPT"
               , "transaction_id", id
                )));

            // Update Location Products Ledger
            foreach (DataGridViewRow row in parent.headerGrid.Rows)
            {
                if (Convert.ToInt32(row.Cells["quantity"].Value) >= 1)
                {
                    if (FAQ.IsNewLine("STAGING-IN", row.Cells["product_id"].Value.ToString(), row.Cells["uom"].Value.ToString(), row.Cells["lot"].Value.ToString(), row.Cells["expiry"].Value.ToString()))
                    {
                        sql.Append("UPDATE LocationProductsLedger SET qty = qty + " + row.Cells["Quantity"].Value.ToString() + " WHERE location = '" + "STAGING-IN" + "' AND product='" + row.Cells["product_id"].Value.ToString() + "' AND uom ='" + row.Cells["uom"].Value.ToString() + "' AND lot_no = '" + row.Cells["lot"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "'");
                    }
                    else
                    {
                        sql.Append(DataSupport.GetInsert("LocationProductsLedger", Utils.ToDict(
                              "location", "STAGING-IN"
                             , "product", row.Cells["product_id"].Value.ToString()
                             , "qty", row.Cells["Quantity"].Value.ToString()
                             , "uom", row.Cells["uom"].Value.ToString()
                             , "lot_no", row.Cells["lot"].Value.ToString()
                             , "expiry", row.Cells["expiry"].Value.ToString()
                            )));
                    }
                }
            }
            if (parent.oms_shipment_id != "")
            {
                sql.Append("UPDATE [oms_db].[dbo].IncomingShipmentRequests SET status = 'RECEIVED', receivedon = '" + DateTime.Now + "' WHERE shipment_id = '" + parent.oms_shipment_id + "'; ");
                foreach (DataGridViewRow row in parent.headerGrid.Rows)
                {
                    if (Convert.ToInt32(row.Cells["quantity"].Value) >= 1)
                        sql.Append("UPDATE [oms_db].[dbo].IncomingShipmentRequestDetails SET received_qty = '" + row.Cells["Quantity"].Value.ToString() + "' WHERE shipment = '" + parent.oms_shipment_id + "' AND product = '" + row.Cells["product_id"].Value.ToString() + "' AND uom = '" + row.Cells["uom"].Value.ToString() + "' AND lot_no='" + row.Cells["lot"].Value.ToString() + "' AND expiry='" + row.Cells["expiry"].Value.ToString() + "';");
                }
            }
            else
            {
                Dictionary<String, Object> header = new Dictionary<string, object>();
                header.Add("receivingid", id);
                header.Add("sourceid", parent.cboreceivedfrom.SelectedValue);
                header.Add("sourcename", parent.cboreceivedfrom.Text);
                header.Add("warehousecode", DataSupport.GetWarehouseCode());
                header.Add("warehousename", "");
                header.Add("warehouseadd", "");
                header.Add("refno", parent.txtrefno.Text);
                header.Add("refdate", parent.dtprefdate.Value.ToShortDateString());
                header.Add("shippername", parent.txtshippername.Text);
                header.Add("vanno", parent.txtvanno.Text);
                header.Add("receivedby", parent.cboreceivedby.Text);
                header.Add("remarks", parent.txtremarks.Text);
                header.Add("eta", DateTime.Now);
                header.Add("etd", DateTime.Now);
                header.Add("incomingtype", (parent.rbclient.Checked) ? "REPLENISHMENT":"RETURN STOCKS");
                header.Add("transactiontype", (parent.rbclient.Checked) ? "INCOMING" : "RETURN");
                header.Add("sourcetype", (parent.rbclient.Checked) ? "CLIENT" : "CUSTOMER");
                header.Add("status", "FOR CLASIFICATION");

                sql.Append(DataSupport.GetInsert("[oms_db].[dbo].[pendingincomingbywarehouse]", header));

                foreach (DataGridViewRow row in parent.headerGrid.Rows)
                {
                    if (Convert.ToInt32(row.Cells["quantity"].Value) >= 1)
                    {
                        Dictionary<String, Object> detail = new Dictionary<string, object>();
                        detail.Add("id", "MAX(id)");
                        detail.Add("product", row.Cells["product_id"].Value.ToString());
                        detail.Add("uom", row.Cells["uom"].Value.ToString());
                        detail.Add("lot_no", row.Cells["lot"].Value.ToString());
                        detail.Add("expiry", row.Cells["expiry"].Value.ToString());
                        if (!String.IsNullOrWhiteSpace(row.Cells["remarks"].Value as string))
                            detail.Add("remarks", row.Cells["remarks"].Value.ToString());

                        detail.Add("expected_qty", row.Cells["Quantity"].Value.ToString());
                        detail.Add("received_qty", row.Cells["Quantity"].Value.ToString());
                        sql.Append(DataSupport.GetInsertWithIndex("[oms_db].[dbo].[pendingincomingbywarehousedetails]", detail, "[oms_db].[dbo].[pendingincomingbywarehouse]", "id"));
                    }
                }
            }

            try
            {
                DataSupport.RunNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);
                MessageBox.Show("Success");


                StringBuilder summaryuomqty = new StringBuilder();
                int count = 1;
                foreach (KeyValuePair<string, int> item in uomqty)
                {
                    if (uomqty.Count != count)
                        summaryuomqty.Append(String.Format("{0}={1}, ", item.Key, item.Value));
                    else
                        summaryuomqty.Append(String.Format("{0}={1}", item.Key, item.Value));

                    count++;
                }


                receivingreport.Columns.Remove("shippingid");
                DataColumn dc = new DataColumn("shippingid");
                dc.DefaultValue = id;
                receivingreport.Columns.Add(dc);

                CrystalDecisions.CrystalReports.Engine.ReportDocument rviewer = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rviewer = new crtreceivingreport();
                rviewer.SetDataSource(receivingreport);
                if (discrepancy != null)
                {
                    rviewer.Subreports["crtdiscrepancyreport.rpt"].SetDataSource(discrepancy);
                }
                rviewer.SetParameterValue("totalperskuuomqty", summaryuomqty.ToString());
                rviewer.SetParameterValue("watermarks", "");

                viewer.ReportSource = rviewer;
                viewer.RefreshReport();
                viewer.PrintReport();
                btnPrintPreview.Text = "Print";
                btnCancel.Text = "Close";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }             

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewReceiptConfirmationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (btnPrintPreview.Text == "Print")
                DialogResult = DialogResult.OK;
        }
    }
}
