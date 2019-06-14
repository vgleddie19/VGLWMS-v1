using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class reportform : Form
    {
        #region MyGridButtonXEditControl

        /// <summary>
        /// GridButtonXEditControl Class that controls the
        /// ButtonX color initialization and user button clicks.
        /// </summary>
        private class MyGridButtonXEditControl : GridButtonXEditControl
        {
            private String _buttonText
            { get; set; }
            /// <summary>
            /// Constructor
            /// </summary>
            /// 
            public MyGridButtonXEditControl()
            {
                // We want to be notified when the user clicks the button
                // so that we can change the underlying cell value to reflect
                // the mouse click.
                Click += MyGridButtonXEditControlClick;
            }

            #region InitializeContext

            /// <summary>
            /// Initializes the color table for the button
            /// </summary>
            /// <param name="cell"></param>
            /// <param name="style"></param>
            public override void
                InitializeContext(GridCell cell, CellVisualStyle style)
            {
                base.InitializeContext(cell, style);
            }

            #endregion

            #region MyGridButtonXEditControlClick

            /// <summary>
            /// Handles user clicks of the button
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void MyGridButtonXEditControlClick(object sender, EventArgs e)
            {
                _buttonText = (EditorCell.Value != null && _buttonText == null) ? EditorCell.Value.ToString() : _buttonText;
                string updatebuttonText = _buttonText + " ";
                EditorCell.Value = (EditorCell.Value.ToString() == updatebuttonText) ? _buttonText : updatebuttonText;
            }

            #endregion
        }
        #endregion

        public reportform()
        {
            InitializeComponent();
            grd_incoming.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            grd_incoming.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
        }

        //private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_rrno;
        //private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_shippingid;
        //private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_receivedfrom;
        //private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_receivedon;
        //private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_refno;
        //private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_refdate;
        //private DevComponents.DotNetBar.SuperGrid.GridColumn recextra_action;

        private void reportform_Load(object sender, EventArgs e)
        {
            grd_incoming.PrimaryGrid.DataSource = DataSupport.RunDataSet("SELECT rrno[recextra_rrno],receipt_id[recextra_shippingid], received_from[recextra_receivedfrom], refno[recextra_refno], refdate[recextra_refdate],'VIEW'[recextra_action] FROM [receipts]").Tables[0];
            GridPanel panel = grd_incoming.PrimaryGrid;
            panel.DefaultRowHeight = 50;
            GridColumn column = panel.Columns[recextra_action.Name];
            column.HeaderText = "";
            column.DisplayIndex = panel.Columns.Count - 1;
            column.EditorType = typeof(MyGridButtonXEditControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grd_incoming_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            if (e.GridCell.ColumnIndex == grd_incoming.PrimaryGrid.Columns[recextra_action.Name].ColumnIndex)
            {
                List<String> listuom = new List<string>();
                listuom.Add("CS");
                foreach (DataRow dRow in Connection.GetOMSConnection.ExecuteDataSet("SELECT DISTINCT [uom],qty FROM [itemPrice] WHERE uom != 'PC' AND uom != 'CS' ORDER BY uom,qty").Tables[0].Rows)
                    listuom.Add(dRow["uom"].ToString());
                listuom.Add("PC");

                DataTable receivingreport = new DataTable();
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

                DataTable discrepancy = new DataTable();
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

                Dictionary<String, int> uomqty = new Dictionary<string, int>();
                string receivingid = grd_incoming.PrimaryGrid.GetCell(e.GridCell.RowIndex, grd_incoming.PrimaryGrid.Columns[recextra_shippingid.Name].ColumnIndex).Value.ToString();
                foreach (DataRow item in DataSupport.RunDataSet("SELECT top 1 * FROM [receipts] where receipt_id = '" + receivingid + "'").Tables[0].Rows)
                {
                    foreach (DataRow ditem in DataSupport.RunDataSet("SELECT DISTINCT rd.*,p.description FROM [receiptdetails] rd join products p on p.product_id = product where receipt = '" + receivingid + "'").Tables[0].Rows)
                    {
                        receivingreport.Rows.Add(item["rrno"], item["receipt_id"], item["received_by"], item["received_on"], item["received_from"]
                                                , item["refno"], item["refdate"], item["remarks"], ditem["product"], ditem["description"]
                                                , ditem["qty"], ditem["uom"], ditem["lot_no"], ditem["expiry"], ditem["remarks"],false, ditem["shippername"], ditem["vanno"]);

                        if (uomqty.ContainsKey(ditem["uom"].ToString()))
                            uomqty[ditem["uom"].ToString()] = uomqty[ditem["uom"].ToString()] + Convert.ToInt32(ditem["qty"].ToString());
                        else
                            uomqty.Add(ditem["uom"].ToString(), Convert.ToInt32(ditem["qty"]));
                    }
                }

                Dictionary<String, int> uomqtyover = new Dictionary<string, int>();
                Dictionary<String, int> uomqtyshort = new Dictionary<string, int>();
                foreach (DataRow item in DataSupport.RunDataSet("SELECT top 1 * FROM [Discrepancy] where refno = '" + receivingid + "'").Tables[0].Rows)
                {
                    foreach (DataRow ditem in DataSupport.RunDataSet("SELECT DISTINCT dd.*,p.description FROM [Discrepancydetails] dd join products p on dd.product = p.product_id where discrepancy = '" + item["discrepancy_id"]+ "'").Tables[0].Rows)
                    {
                        if (ditem["uom"] == ditem["uomactual"])
                        {
                            if (Convert.ToInt32(ditem["qty"]) > Convert.ToInt32(ditem["qtyactual"].ToString()))
                            {
                                int shorts = (Convert.ToInt32(ditem["qty"].ToString()) - Convert.ToInt32(ditem["qtyactual"].ToString()));

                                if (uomqtyshort.ContainsKey(ditem["uom"].ToString()))
                                    uomqtyshort[ditem["uom"].ToString()] = uomqtyshort[ditem["uom"].ToString()] + shorts;
                                else
                                    uomqtyshort.Add(ditem["uom"].ToString(), shorts);

                                discrepancy.Rows.Add(item["discrepancy_id"], item["received_by"], item["received_on"], item["received_from"]
                                                    , item["refno"], item["refdate"], item["remarks"], ditem["product"], ditem["description"]
                                                    , ditem["qty"], ditem["uom"], ditem["qtyactual"], ditem["uomactual"], ditem["lot_no"], ditem["expiry"], ditem["remarks"], shorts, 0);
                            }
                            else
                            {
                                int over = (Convert.ToInt32(ditem["qtyactual"].ToString()) - Convert.ToInt32(ditem["qty"].ToString()));
                                if (uomqtyover.ContainsKey(ditem["uomactual"].ToString()))
                                    uomqtyover[ditem["uomactual"].ToString()] = uomqtyover[ditem["uomactual"].ToString()] + over;
                                else
                                    uomqtyover.Add(ditem["uomactual"].ToString(), over);

                                discrepancy.Rows.Add(item["discrepancy_id"], item["received_by"], item["received_on"], item["received_from"]
                                                    , item["refno"], item["refdate"], item["remarks"], ditem["product"], ditem["description"]
                                                    , ditem["qty"], ditem["uom"], ditem["qtyactual"], ditem["uomactual"], ditem["lot_no"], ditem["expiry"], ditem["remarks"], 0, over);

                            }
                        }
                        else
                        {
                            if (uomqtyshort.ContainsKey(ditem["uom"].ToString()))
                                uomqtyshort[ditem["uom"].ToString()] = uomqtyshort[ditem["uom"].ToString()] + Convert.ToInt32(ditem["qty"].ToString());
                            else
                                uomqtyshort.Add(ditem["uom"].ToString(), Convert.ToInt32(ditem["qty"].ToString()));

                            //MessageBox.Show(drow["qty"].ToString());

                            if (uomqtyover.ContainsKey(ditem["uomactual"].ToString()))
                                uomqtyover[ditem["uomactual"].ToString()] = uomqtyover[ditem["uomactual"].ToString()] + Convert.ToInt32(ditem["qtyactual"].ToString());
                            else
                                uomqtyover.Add(ditem["uomactual"].ToString(), Convert.ToInt32(ditem["qtyactual"].ToString()));

                            discrepancy.Rows.Add(item["discrepancy_id"], item["received_by"], item["received_on"], item["received_from"]
                                                    , item["refno"], item["refdate"], item["remarks"], ditem["product"], ditem["description"]
                                                    , ditem["qty"], ditem["uom"], null, ditem["uomactual"], ditem["lot_no"], ditem["expiry"], ditem["remarks"], ditem["qty"],null);

                            discrepancy.Rows.Add(item["discrepancy_id"], item["received_by"], item["received_on"], item["received_from"]
                                                    , item["refno"], item["refdate"], item["remarks"], null, null
                                                    , null, ditem["uom"], ditem["qtyactual"], ditem["uomactual"], null, null, null, null, ditem["qtyactual"]);


                        }
                    }
                }

                Dictionary<String, int> orderuomqtyover = new Dictionary<string, int>();
                foreach (String item in listuom)
                {
                    if (orderuomqtyover.ContainsKey(item))
                    {
                        orderuomqtyover.Add(item, uomqtyover[item]);
                    }
                }
                StringBuilder summaryuomqtyover = new StringBuilder();
                int count = 1;
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


                Dictionary<String, int> orderuomqty = new Dictionary<string, int>();
                foreach (String item in listuom)
                {
                    if (uomqty.ContainsKey(item))
                    {
                        orderuomqty.Add(item, uomqty[item]);
                    }
                }
                StringBuilder summaryuomqty = new StringBuilder();
                count = 1;
                foreach (KeyValuePair<string, int> item in orderuomqty)
                {
                    if (orderuomqty.Count != count)
                        summaryuomqty.Append(String.Format("{0}={1}, ", item.Key, item.Value));
                    else
                        summaryuomqty.Append(String.Format("{0}={1}", item.Key, item.Value));

                    count++;
                }
                if (discrepancy != null)
                {
                    receivingreport.Columns.Remove("hasdiscrepancy");
                    DataColumn dc1 = new DataColumn("hasdiscrepancy",typeof(Boolean));
                    dc1.DefaultValue = true;
                    receivingreport.Columns.Add(dc1);
                }

                discrepancy.Columns.Remove("totalperskuover");
                DataColumn dc = new DataColumn("totalperskuover");
                dc.DefaultValue = summaryuomqtyover.ToString(); 
                discrepancy.Columns.Add(dc);

                discrepancy.Columns.Remove("totalperskushort");
                dc = new DataColumn("totalperskushort");
                dc.DefaultValue = summaryuomqtyshort.ToString(); 
                discrepancy.Columns.Add(dc);

                discrepancy.Columns.Remove("isextracopy");
                dc = new DataColumn("isextracopy",typeof(Boolean));
                dc.DefaultValue = true;
                discrepancy.Columns.Add(dc);

                reportviewer viewer = new reportviewer();
                CrystalDecisions.CrystalReports.Engine.ReportDocument rviewer = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rviewer = new crtreceivingreport();

                rviewer.SetDataSource(receivingreport);
                if (discrepancy != null)
                    rviewer.Subreports["crtdiscrepancyreport.rpt"].SetDataSource(discrepancy);
                rviewer.SetParameterValue("totalperskuuomqty", summaryuomqty.ToString());
                rviewer.SetParameterValue("watermarks","EXTRA COPY");
                viewer.viewer.ReportSource = rviewer;
                viewer.ShowDialog();
            }
        }
    }
}
