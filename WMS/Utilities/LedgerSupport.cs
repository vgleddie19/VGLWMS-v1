using Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class LedgerSupport
{
    static DataTable producttopick = null;
    static DataTable casebreak = null;
    static DataTable putaway = null;
    public static bool StockCheck()
    {
        DataSupport oms_dh = new DataSupport(String.Format(@"Initial Catalog={0};Data Source= {1};User Id = {2}; Password = {3}", Utils.DBConnection["OMS"]["DBNAME"], Utils.DBConnection["OMS"]["SERVER"], Utils.DBConnection["OMS"]["USERNAME"], Utils.DBConnection["OMS"]["PASSWORD"]));
        DataTable ordersDT = DataSupport.RunDataSet(String.Format("SELECT * FROM ReleaseOrders WHERE status = 'FOR STOCK CHECKING'")).Tables[0];

        foreach (DataRow row in ordersDT.Rows)
        {
            var order_id = row["order_id"].ToString();
            var result = FAQ.DoesOrderHaveStocks(order_id);

            if (result == false)
            {
                oms_dh.ExecuteNonQuery("UPDATE OutgoingShipmentRequests SET status = 'INSUFFICIENT STOCKS' WHERE out_shipment_id = '" + row["oms_shipment_id"].ToString() + "';", IsolationLevel.ReadCommitted);
                MessageBox.Show("Can't Reserve order " + order_id);
                continue;
            }

            StringBuilder sql = new StringBuilder();

            DataTable detailsDT = FAQ.GetOrderDetails(order_id);

            if (!isstocksreadyfororder(order_id))
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("You cancelled the Automated Casebreak procedure!\nUnable to serve this Order due to insufficient UOM Quantity!\n", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            sql = new StringBuilder();
            sql.Append(" UPDATE ReleaseOrders SET status = 'FOR SCHEDULING' WHERE order_id = '" + order_id + "'; ");

            foreach (DataRow detail in detailsDT.Rows)
            {
                var dt = FAQ.WhereAreProductsInWarehouse(detail["product"].ToString(), detail["uom"].ToString());
                int qty_to_be_reserved = int.Parse(detail["qty"].ToString());

                foreach (DataRow selected_row in dt.Rows)
                {

                    int qty_in_location = int.Parse(selected_row["available_qty"].ToString());
                    int qty_reserved = qty_in_location;
                    if (qty_to_be_reserved < qty_in_location)
                    {
                        qty_reserved = qty_to_be_reserved;
                    }
                    sql.Append(" UPDATE LocationProductsLedger SET reserved_qty = reserved_qty + " + qty_reserved +
                           " WHERE product = '" + detail["product"].ToString() + "' AND uom = '" + detail["uom"].ToString() + "' " +
                           " AND lot_no = '" + selected_row["lot_no"].ToString() + "' AND expiry = '" + selected_row["expiry"].ToString() + "' " +
                           " AND location='" + selected_row["location"].ToString() + "'; ");

                    qty_to_be_reserved -= qty_reserved;
                    if (qty_to_be_reserved <= 0)
                        break;
                }
            }

            DataSupport.RunNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);
            oms_dh.ExecuteNonQuery("UPDATE OutgoingShipmentRequests SET status = 'FOR SCHEDULING' WHERE out_shipment_id = '" + row["oms_shipment_id"].ToString() + "';", IsolationLevel.ReadCommitted);
        }
        return true;
    }

    public static bool CheckBin(String product, String uom, String qty)
    {
        bool result = true;

        if (uom.ToUpper() == "PC" || uom.ToUpper() == "PCS")
        {
            DataTable dt = DataSupport.RunDataSet(@"SELECT SUM(available_qty)
                        FROM LocationProductsLedger 
                        WHERE  product = @product AND uom = @uom
                        AND available_qty >0
                        ", "product", product, "uom", uom).Tables[0];


            int totalqty = dt.Rows[0][0].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dt.Rows[0][0]);

            //if (Convert.ToInt32(qty) > totalqty)
            //    result = false;

            if (!dt.Rows[0][0].Equals(DBNull.Value))
            {
                int pieces_in_warehouse = int.Parse(dt.Rows[0][0].ToString());
                int pieces_in_order = FAQ.HowManyPiecesInUOM(product, uom, int.Parse(qty));
                if (pieces_in_warehouse < pieces_in_order)
                    result = false;
            }
        }
        return result;        
    }
    
    public static DataTable GetLocationLedgerDT()
    {
        DataTable result = new DataTable();
        result.Columns.Add("location");
        result.Columns.Add("transaction_datetime");
        result.Columns.Add("transaction_type");
        result.Columns.Add("transaction_name");
        result.Columns.Add("transaction_id");
        return result;
    }


    public static String UpdateLocationLedger(DataTable dt)
    {
        String sql = "";
        foreach (DataRow row in dt.Rows)
        {
            sql += DataSupport.GetUpsert("LocationLedger", Utils.ToDict(
                "location", row["location"]
               , "transaction_datetime", row["transaction_datetime"]
               , "transaction_type", row["transaction_type"]
               , "transaction_name", row["transaction_name"]
               , "transaction_id", row["transaction_id"]
                ), "location", "transaction_datetime", "transaction_id") + "\r\n\r\n";
        }
        return sql;
    }


    public static DataTable GetLocationProductsLedgerDT()
    {
        DataTable result = new DataTable();
        result.Columns.Add("location");
        result.Columns.Add("product");
        result.Columns.Add("qty");
        result.Columns.Add("uom");
        result.Columns.Add("lot_no");
        result.Columns.Add("expiry");
        result.Columns.Add("reserved_qty");
        result.Columns.Add("to_be_picked_qty");
        return result;
    }
    public static String UpdateLocationProductsLedger(DataTable dt)
    {
        return UpdateLocationProductsLedger(dt,false);
    }


    public static DataTable ConsolidateDT(DataTable originalDT, params Object[] keys)
    {
        DataTable dt = new DataTable();
        foreach (DataColumn col in originalDT.Columns)
            dt.Columns.Add(col.ColumnName);

        foreach (DataRow row in originalDT.Rows)
        {
            Boolean is_found = false;

            foreach (DataRow new_row in dt.Rows)
            {
                try
                {
                    foreach (String key in keys)
                    {
                        if (new_row[key].ToString() != row[key].ToString())
                            throw new Exception();
                    }
                    is_found = true;
                }
                catch (Exception)
                {

                }

                if (is_found)
                {
                    new_row["qty"] = int.Parse(new_row["qty"].ToString()) + int.Parse(row["qty"].ToString());
                    break;
                }
            }

            if (!is_found)
                dt.Rows.Add(row.ItemArray);
        }


        return dt;
    }
    public static String UpdateLocationProductsLedger(DataTable dt, Boolean is_overwrite)
    {
        String sql = "";
        if (!is_overwrite)
        {
            if (dt.Rows.Count == 0)
                return "";

            if (dt.Rows[0]["reserved_qty"].ToString() == "")
                dt = ConsolidateDT(dt, "location", "product", "uom", "lot_no", "expiry");

            foreach (DataRow row in dt.Rows)
            {
                if (FAQ.IsNewLine(row["location"].ToString(), row["product"].ToString(), row["uom"].ToString(), row["lot_no"].ToString(), row["expiry"].ToString()))
                {
                    sql += " UPDATE LocationProductsLedger SET qty = qty + " + row["qty"].ToString() + " WHERE location = '" + row["location"].ToString() + "' AND product='" + row["product"].ToString() + "' AND uom ='" + row["uom"].ToString() + "' AND lot_no = '" + row["lot_no"].ToString() + "' AND expiry='" + row["expiry"].ToString() + "'\r\n\r\n\r\n\r\n";
                  
                }
                else
                {
                    sql += DataSupport.GetInsert("LocationProductsLedger", Utils.ToDict(
                          "location", row["location"].ToString()
                         , "product", row["product"].ToString()
                         , "qty", row["qty"].ToString()
                         , "uom", row["uom"].ToString()
                         , "lot_no", row["lot_no"].ToString()
                         , "expiry", row["expiry"].ToString()
                        ));
                }

                if (row["location"].ToString() == "STAGING-OUT" || row["location"].ToString() == "FOR-RESOLUTION" || row["location"].ToString() == "RELEASED" || row["location"].ToString() == "CANCELLED_PALLET")
                    sql += " UPDATE LocationProductsLedger SET reserved_qty = qty WHERE location = '" + row["location"].ToString() + "' AND product='" + row["product"].ToString() + "' AND uom ='" + row["uom"].ToString() + "' AND lot_no = '" + row["lot_no"].ToString() + "' AND expiry='" + row["expiry"].ToString() + "'\r\n\r\n\r\n\r\n";

                if (row["reserved_qty"].ToString() != "")
                    sql += " UPDATE LocationProductsLedger SET reserved_qty = reserved_qty + " + row["reserved_qty"].ToString() + " WHERE location = '" + row["location"].ToString() + "' AND product='" + row["product"].ToString() + "' AND uom ='" + row["uom"].ToString() + "' AND lot_no = '" + row["lot_no"].ToString() + "' AND expiry='" + row["expiry"].ToString() + "'\r\n\r\n\r\n\r\n";
                if (row["to_be_picked_qty"].ToString() != "")
                    sql += " UPDATE LocationProductsLedger SET to_be_picked_qty = to_be_picked_qty + " + row["to_be_picked_qty"].ToString() + " WHERE location = '" + row["location"].ToString() + "' AND product='" + row["product"].ToString() + "' AND uom ='" + row["uom"].ToString() + "' AND lot_no = '" + row["lot_no"].ToString() + "' AND expiry='" + row["expiry"].ToString() + "'\r\n\r\n\r\n\r\n";

                sql += " UPDATE LocationProductsLedger SET reserved_qty = qty WHERE location = (SELECT location_id FROM Locations WHERE location = location_id AND type='STORAGE - BAD STOCKS'); ";
            }
        }

        return sql;
    }


    public static bool isstocksreadyfororder(String order_id)
    {
        DataTable Order = DataSupport.RunDataSet(@"SELECT ROD.*,PU.qty[uomconv] FROM ReleaseOrderDetails ROD INNER JOIN 
                                        ProductUOMs PU ON ROD.product = PU .product and ROD.uom = PU.uom  
                                        WHERE release_order = @id", "id", order_id).Tables[0];
        int binstocks = 0;
        int productorder = 0;
        StringBuilder sql = new StringBuilder();

        foreach (DataRow dRow in Order.Rows)
        {
            productorder = int.Parse(dRow["qty"].ToString());
            DataTable dt = DataSupport.RunDataSet(@"SELECT pl.*,l.type FROM [LocationProductsLedger] pl join locations l on pl.location = l.location_id
                                        WHERE product = @product and uom = @uom ORDER BY expiry DESC", "product", dRow["product"].ToString(), "uom", dRow["uom"].ToString()).Tables[0]; ;
            foreach (DataRow sRow in dt.Rows)
            {
                if (binstocks > productorder)
                {
                    binstocks = productorder;
                    break;
                }
                else
                {
                    binstocks += int.Parse(sRow["available_qty"].ToString());
                }
            }
            if (productorder > binstocks)
            {
                sql.Append(automatedcasebreakperitem(dRow["product"].ToString(), dRow["uom"].ToString(), (productorder - binstocks).ToString()));
            }
        }
        try
        {
            if (sql.Length > 1)
            {
                WMS.reportviewer viewer = new WMS.reportviewer();
                viewer.StartPosition = FormStartPosition.CenterScreen;
                CrystalDecisions.CrystalReports.Engine.ReportDocument rviewer = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rviewer = new WMS.crtpicklistforcasebreak();
                rviewer.SetDataSource(producttopick);
                rviewer.Subreports["crtcasebreak.rpt"].SetDataSource(casebreak);
                rviewer.Subreports["crtputawaycasebreak.rpt"].SetDataSource(putaway);

                viewer.viewer.ReportSource = rviewer;
                viewer.viewer.Zoom(110);

                if (viewer.ShowDialog() != DialogResult.OK)
                    return false;

                else
                {
                    string[] transid = new string[3];
                    int count = 0;
                    foreach (KeyValuePair<String,String> item in saveautomatedcasebreak())
                    {
                        sql.Append(item.Value);
                        transid[count] = item.Key;
                        count++;
                    }
                    viewer = new WMS.reportviewer();
                    viewer.StartPosition = FormStartPosition.CenterScreen;
                    rviewer = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rviewer = new WMS.crtpicklistforcasebreak();

                    BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
                    barcode.BarWidth = 5;
                    DataColumn pick = new DataColumn("picklistbarcode", System.Type.GetType("System.Byte[]"));
                    pick.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, transid[0]), System.Drawing.Imaging.ImageFormat.Jpeg);
                    DataColumn caseb = new DataColumn("casebreakbarcode", System.Type.GetType("System.Byte[]"));
                    caseb.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, transid[1]), System.Drawing.Imaging.ImageFormat.Jpeg);
                    DataColumn putbar = new DataColumn("putawaybarcode", System.Type.GetType("System.Byte[]"));
                    putbar.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, transid[2]), System.Drawing.Imaging.ImageFormat.Jpeg);
                    producttopick.Columns.Add(pick);
                    producttopick.Columns.Add(caseb);
                    producttopick.Columns.Add(putbar);

                    pick = new DataColumn("picklistbarcode", System.Type.GetType("System.Byte[]"));
                    pick.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, transid[0]), System.Drawing.Imaging.ImageFormat.Jpeg);
                    caseb = new DataColumn("casebreakbarcode", System.Type.GetType("System.Byte[]"));
                    caseb.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, transid[1]), System.Drawing.Imaging.ImageFormat.Jpeg);
                    putbar = new DataColumn("putawaybarcode", System.Type.GetType("System.Byte[]"));
                    putbar.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, transid[2]), System.Drawing.Imaging.ImageFormat.Jpeg);
                    casebreak.Columns.Add(pick);
                    casebreak.Columns.Add(caseb);
                    casebreak.Columns.Add(putbar);

                    pick = new DataColumn("picklistbarcode", System.Type.GetType("System.Byte[]"));
                    pick.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, transid[0]), System.Drawing.Imaging.ImageFormat.Jpeg);
                    caseb = new DataColumn("casebreakbarcode", System.Type.GetType("System.Byte[]"));
                    caseb.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, transid[1]), System.Drawing.Imaging.ImageFormat.Jpeg);
                    putbar = new DataColumn("putawaybarcode", System.Type.GetType("System.Byte[]"));
                    putbar.DefaultValue = Utils.ConvertImageToByteArray(barcode.Encode(BarcodeLib.TYPE.CODE39, transid[2]), System.Drawing.Imaging.ImageFormat.Jpeg);
                    putaway.Columns.Add(pick);
                    putaway.Columns.Add(caseb);
                    putaway.Columns.Add(putbar);

                    producttopick.Columns.Remove("picklistid");
                    producttopick.Columns.Remove("casebreakid");
                    producttopick.Columns.Remove("putawayid");
                    DataColumn dc = new DataColumn("picklistid");
                    dc.DefaultValue = transid[0];
                    producttopick.Columns.Add(dc);
                    dc = new DataColumn("casebreakid");
                    dc.DefaultValue = transid[1];
                    producttopick.Columns.Add(dc);
                    dc = new DataColumn("putawayid");
                    dc.DefaultValue = transid[2];
                    producttopick.Columns.Add(dc);
                    rviewer.SetDataSource(producttopick);

                    casebreak.Columns.Remove("picklistid");
                    casebreak.Columns.Remove("casebreakid");
                    casebreak.Columns.Remove("putawayid");
                    dc = new DataColumn("picklistid");
                    dc.DefaultValue = transid[0];
                    casebreak.Columns.Add(dc);
                    dc = new DataColumn("casebreakid");
                    dc.DefaultValue = transid[1];
                    casebreak.Columns.Add(dc);
                    dc = new DataColumn("putawayid");
                    dc.DefaultValue = transid[2];
                    casebreak.Columns.Add(dc);
                    rviewer.Subreports["crtcasebreak.rpt"].SetDataSource(casebreak);

                    putaway.Columns.Remove("picklistid");
                    putaway.Columns.Remove("casebreakid");
                    putaway.Columns.Remove("putawayid");
                    dc = new DataColumn("picklistid");
                    dc.DefaultValue = transid[0];
                    putaway.Columns.Add(dc);
                    dc = new DataColumn("casebreakid");
                    dc.DefaultValue = transid[1];
                    putaway.Columns.Add(dc);
                    dc = new DataColumn("putawayid");
                    dc.DefaultValue = transid[2];
                    putaway.Columns.Add(dc);
                    rviewer.Subreports["crtputawaycasebreak.rpt"].SetDataSource(putaway);

                    viewer.viewer.ReportSource = rviewer;
                    viewer.viewer.Zoom(110);
                    viewer.btnCancel.Text = "Close";
                    viewer.btnPrintPreview.Text = "Print";
                    viewer.ShowDialog();

                }
                DataSupport.RunNonQuery(sql.ToString(), IsolationLevel.ReadCommitted);
            }
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }
    public static String automatedcasebreakperitem(String product,String uom, String qty_to_be_replenish)
    {
        StringBuilder sql = new StringBuilder();
        Dictionary<List<String>, int> product_casebreak = new Dictionary<List<string>, int>();
        Dictionary<String, DataRow> products = Utils.BuildIndex("SELECT * FROM Products", "product_id");
        Dictionary<String, DataRow> uomconv = Utils.BuildIndex("SELECT (product+'-'+uom)[search],qty FROM ProductUOMs", "search");
        DataTable result = new DataTable();
        result.Columns.Add("binid");
        result.Columns.Add("location");
        result.Columns.Add("product");
        result.Columns.Add("uom");
        result.Columns.Add("lot");
        result.Columns.Add("expiry");
        result.Columns.Add("qty");
        result.Columns.Add("binuom");
        result.Columns.Add("locuomconv");
        result.Columns.Add("binuomconv");

        int total_qty_to_be_replenish = int.Parse(qty_to_be_replenish) * int.Parse(uomconv[String.Format("{0}-{1}", product, uom)]["qty"].ToString());
        DataTable dt = DataSupport.RunDataSet(@"SELECT pl.*,l.type,p.description FROM [LocationProductsLedger] pl join locations l on pl.location = l.location_id join products p on p.product_id = pl.product
                                        WHERE (type = 'STORAGE' or l.location_id = 'STAGING-IN') and product = @product and uom = 'CS'  ORDER BY expiry DESC", "product", product).Tables[0];
        foreach(DataRow dRow in dt.Rows)
        {
            decimal conv = int.Parse(uomconv[String.Format("{0}-{1}", product, dRow["uom"])]["qty"].ToString());
            int locqty_inpcs = int.Parse(dRow["available_qty"].ToString()) *  (int)conv;
            List<String> productdetails = new List<string>();

            if (locqty_inpcs >= total_qty_to_be_replenish)
            {
                productdetails.Add(dRow["location"].ToString());
                productdetails.Add(dRow["product"].ToString());
                productdetails.Add(dRow["uom"].ToString());
                productdetails.Add(dRow["lot_no"].ToString());
                productdetails.Add(dRow["expiry"].ToString());
                productdetails.Add(dRow["description"].ToString());
                productdetails.Add(conv.ToString());
                productdetails.Add(uom);
                decimal s = Convert.ToDecimal((decimal)total_qty_to_be_replenish / conv);
                product_casebreak.Add(productdetails, (int)Math.Ceiling(s));
            }
            else
            {
                productdetails.Add(dRow["location"].ToString());
                productdetails.Add(dRow["product"].ToString());
                productdetails.Add(dRow["uom"].ToString());
                productdetails.Add(dRow["lot_no"].ToString());
                productdetails.Add(dRow["expiry"].ToString());
                productdetails.Add(dRow["description"].ToString());
                productdetails.Add(conv.ToString());
                productdetails.Add(uom);

                decimal s = Convert.ToDecimal(Convert.ToDecimal(dRow["available_qty"].ToString()) / conv);
                product_casebreak.Add(productdetails, (int)Math.Ceiling(s));
            }
        }        
        sql.Append(forcasebreak(product_casebreak));

        return sql.ToString();
    }

    public static String forcasebreak(Dictionary<List<String>,int> product_to_be_reserved)
    {
        StringBuilder result = new StringBuilder();
        producttopick = new DataTable();
        producttopick.Columns.Add("Location");
        producttopick.Columns.Add("Product");
        producttopick.Columns.Add("Description");
        producttopick.Columns.Add("Qty1");
        producttopick.Columns.Add("Uom1");
        producttopick.Columns.Add("Lot no");
        producttopick.Columns.Add("Expiry");
        producttopick.Columns.Add("putawayid");
        producttopick.Columns.Add("casebreakid");
        producttopick.Columns.Add("picklistid");
        casebreak = new DataTable();
        casebreak.Columns.Add("Product");
        casebreak.Columns.Add("Description");
        casebreak.Columns.Add("Qty1");
        casebreak.Columns.Add("Uom1");
        casebreak.Columns.Add("Qty2");
        casebreak.Columns.Add("Uom2");
        casebreak.Columns.Add("Lot no");
        casebreak.Columns.Add("Expiry");
        casebreak.Columns.Add("putawayid");
        casebreak.Columns.Add("casebreakid");
        casebreak.Columns.Add("picklistid");
        putaway = new DataTable();
        putaway.Columns.Add("Product");
        putaway.Columns.Add("Description");
        putaway.Columns.Add("Qty2");
        putaway.Columns.Add("Uom2");
        putaway.Columns.Add("Lot no");
        putaway.Columns.Add("Expiry");
        putaway.Columns.Add("Location");
        putaway.Columns.Add("putawayid");
        putaway.Columns.Add("casebreakid");
        putaway.Columns.Add("picklistid");

        foreach (KeyValuePair<List<String>,int> item in product_to_be_reserved)
        {            
            result.Append(" UPDATE LocationProductsLedger SET to_be_picked_qty = to_be_picked_qty + " + item.Value + ", [reserved_qty] = [reserved_qty] + " + item.Value + " WHERE location='" + item.Key[0] + "' AND product='" + item.Key[1] + "' AND uom='" + item.Key[2] + "' AND lot_no='" + item.Key[3] + "' AND expiry='" + item.Key[4] + "'; ");
            DataTable dt = DataSupport.RunDataSet(@"SELECT pl.*,l.type FROM [LocationProductsLedger] pl join locations l on pl.location = l.location_id
                                          WHERE l.type = 'BIN' AND product = @product AND lot_no = @lotno AND expiry = @expiry"
                                          , "location", item.Key[0]
                                          , "product", item.Key[1]
                                          , "uom", item.Key[2]
                                          , "lotno", item.Key[3]
                                          , "expiry", item.Key[4]).Tables[0];
            string loc2 = "";
            if (dt.Rows.Count == 0)
            {
                Dictionary<String, String> product = new Dictionary<string, string>();
                product.Add("product", item.Key[1]);
                product.Add("uom", item.Key[7]);
                product.Add("lot", item.Key[3]);
                product.Add("expiry", item.Key[4]);
                result.Append(defaultbin(product));

                loc2 = "BIN-DEF";
                result.Append(String.Format(@"INSERT INTO LocationProductsLedger (Location, Product, qty, uom, lot_no, expiry, reserved_qty, to_be_picked_qty, casebreak_qty) 
                                            VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", "BIN-DEF", item.Key[1], 0, item.Key[7], item.Key[3], item.Key[4], 0, 0, item.Value * int.Parse(item.Key[6].ToString())));

            }
            else
            {
                loc2 = dt.Rows[0]["Location"].ToString();
                result.Append(String.Format(@"UPDATE LocationProductsLedger SET casebreak_qty = casebreak_qty + {5} 
                                           WHERE product = '{0}' AND uom = '{1}' 
                                           AND lot_no = '{2}' AND expiry = '{3}' 
                                           AND location='{4}'; ", item.Key[1], item.Key[7], item.Key[3], item.Key[4], dt.Rows[0]["Location"], item.Value * int.Parse(item.Key[6].ToString())));

            }
            if (item.Key[2].ToUpper().Trim() == item.Key[7].ToUpper().Trim())
            {
                producttopick.Rows.Add(item.Key[0], item.Key[1], item.Key[5], item.Value, item.Key[2], item.Key[3], item.Key[4], "[issued on saved]", "[issued on saved]", "[issued on saved]");
                putaway.Rows.Add(item.Key[1], item.Key[5], item.Value, item.Key[2], item.Key[3], item.Key[4], loc2, "[issued on saved]", "[issued on saved]", "[issued on saved]");
            }
            else
            {
                producttopick.Rows.Add(item.Key[0], item.Key[1], item.Key[5], item.Value, item.Key[2], item.Key[3], item.Key[4], "[issued on saved]", "[issued on saved]", "[issued on saved]");
                casebreak.Rows.Add(item.Key[1], item.Key[5], item.Value , item.Key[2], item.Value * int.Parse(item.Key[6].ToString()), item.Key[7], item.Key[3], item.Key[4], "[issued on saved]", "[issued on saved]", "[issued on saved]");
                putaway.Rows.Add(item.Key[1], item.Key[5], item.Value * int.Parse(item.Key[6].ToString()), item.Key[7], item.Key[3], item.Key[4], loc2, "[issued on saved]", "[issued on saved]", "[issued on saved]");
            }
        }
        return result.ToString();
    }

    private static String defaultbin(Dictionary<String, String> product)
    {
        StringBuilder sql = new StringBuilder();
        Dictionary<String, DataRow> locations = Utils.BuildIndex("SELECT * FROM Locations ORDER BY location_id", "location_id");
        if (locations.ContainsKey("BIN-DEF"))
        {
            sql.Append(DataSupport.GetUpdate("[BinProducts]", Utils.ToDict(
            "location", "BIN-DEF"
           , "product", product["product"]
           , "uom", product["uom"]
           , "lot_no", product["lot"]
           , "expiry", product["expiry"]
            ), new List<string> { "location" }));
            if (FAQ.isbinproductledgerexist("BIN-DEF", product["product"], product["uom"], product["lot"], product["expiry"]))
            {
                sql.Append(DataSupport.GetUpdate("[BinProductLedger]", Utils.ToDict(
                            "location", "BIN-DEF"
                           , "product", product["product"]
                           , "uom", product["uom"]
                           , "lot_no", product["lot"]
                           , "expiry", product["expiry"]
                           , "status", "ACTIVE"
                            ), new List<string> { "location", "product", "uom", "lot_no", "expiry" }));
            }
            else
            {
                sql.Append(DataSupport.GetInsert("[BinProductLedger]", Utils.ToDict(
                            "location", "BIN-DEF"
                           , "product", product["product"]
                           , "uom", product["uom"]
                           , "lot_no", product["lot"]
                           , "expiry", product["expiry"]
                           , "actualqty", 0
                           , "min_qty", 0
                           , "max_qty", 0
                           , "qty_to_replenished", 0
                           , "status", "ACTIVE"
                            )));
            }
        }
        else
        {
            sql.Append(DataSupport.GetInsert("[Locations]", Utils.ToDict(
            "location_id", "BIN-DEF"
           , "description", "BIN AUTOMATED DEFAULT"
           , "type", "BIN"
           , "status", "ACTIVE"
            )));

            sql.Append(DataSupport.GetInsert("[BinProducts]", Utils.ToDict(
                            "location", "BIN-DEF"
                           , "product", product["product"]
                           , "uom", product["uom"]
                           , "lot_no", product["lot"]
                           , "expiry", product["expiry"]
                           , "min_qty", 0
                           , "max_qty", 0
                            )));
            sql.Append(DataSupport.GetInsert("[BinProductLedger]", Utils.ToDict(
                            "location", "BIN-DEF"
                           , "product", product["product"]
                           , "uom", product["uom"]
                           , "lot_no", product["lot"]
                           , "expiry", product["expiry"]
                           , "actualqty", 0
                           , "min_qty", 0
                           , "max_qty", 0
                           , "qty_to_replenished", 0
                           , "status", "ACTIVE"
                            )));
        }
        return sql.ToString();
    }

    private static Dictionary<String,String> saveautomatedcasebreak()
    {
        Dictionary<String, String> result = new Dictionary<string, string>();

        String pickid = DataSupport.GetNextMenuCodeInt("PL");        
        // Save Transaction
        String sql = DataSupport.GetInsert("Picklists", Utils.ToDict(
            "picklist_id", pickid
           , "status", "TO BE PICKED"
            ));

        int count = 0;
        foreach (DataRow row in producttopick.Rows)
        {
            sql += DataSupport.GetInsert("PicklistDetails", Utils.ToDict(
                  "picklist", pickid
                 , "line", count ++
                 , "order_id", "0"
                 , "product", row["product"].ToString()
                 , "qty", row["qty1"].ToString()
                 , "uom", row["uom1"].ToString()
                 , "lot_no", row["lot no"].ToString()
                 , "expiry", row["expiry"].ToString()
                 , "location", row["location"].ToString()
                ));
        }
        result.Add(pickid, sql);


        String caseid = DataSupport.GetNextMenuCodeInt("CBPL");
        // Save Transaction
        sql = DataSupport.GetInsert("CaseBreak", Utils.ToDict(
            "casebreak_id", caseid
            , "approved_on", DateTime.Now.ToShortDateString()
            , "encoded_on", DateTime.Now
            , "approved_by", RegistrationSupport.username
           , "status", "TO BE PICKED"
            ));
        count = 0;
        foreach (DataRow row in casebreak.Rows)
        {
            sql += DataSupport.GetInsert("CaseBreakDetails", Utils.ToDict(
                  "casebreak", caseid
                 , "line", count++
                 , "product", row["product"].ToString()
                 , "qty", row["qty1"].ToString()
                 , "uom", row["uom1"].ToString()
                 , "lot_no", row["lot no"].ToString()
                 , "expiry", row["expiry"].ToString()
                 , "location", "STOCKS-P2"
                 , "breakto_uom", row["uom2"].ToString()
                 , "expected_qty", row["qty2"].ToString()
                ));
        }
        result.Add(caseid, sql);


        String putid = DataSupport.GetNextMenuCodeInt("PA");
        DateTime now = DateTime.Now;

        // Save Transaction
        sql = DataSupport.GetInsert("Putaways", Utils.ToDict(
            "putaway_id", putid
           , "container", "CEB1-BIN"
           , "encoded_on", now
            ));

        foreach (DataRow row in putaway.Rows)
        {
            sql += DataSupport.GetInsert("PutawayDetails", Utils.ToDict(
                  "putaway", putid
                 , "product", row["product"].ToString()
                 , "expected_qty", row["qty2"].ToString()
                 , "uom", row["uom2"].ToString()
                 , "lot_no", row["lot no"].ToString()
                 , "expiry", row["expiry"].ToString()
                 , "location", row["location"].ToString()
                ));
        }

        sql += String.Format("UPDATE Picklists SET casebreak_id = '{0}', putaway_id = '{1}' WHERE picklist_id ='{2}';", caseid, putid, pickid);
        sql += String.Format("UPDATE casebreak SET putaway_id = '{0}', picklist_id = '{1}' WHERE casebreak_id ='{2}';", putid, pickid, caseid);
        sql += String.Format("UPDATE putaways SET casebreak_id = '{0}', picklist_id = '{1}' WHERE putaway_id ='{2}';", caseid, pickid, putid);

        result.Add(putid, sql);


        return result;
    }
}


