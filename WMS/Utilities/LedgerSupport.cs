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


    public static void StockCheck()
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

            String sql = " UPDATE ReleaseOrders SET status = 'FOR SCHEDULING' WHERE order_id = '" + order_id + "'; ";

            DataTable detailsDT = FAQ.GetOrderDetails(order_id);
            foreach (DataRow detail in detailsDT.Rows)
            {
                var dt = FAQ.WhereAreProductsInWarehouse(detail["product"].ToString(), detail["uom"].ToString());

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
            //MessageBox.Show("It works");

            oms_dh.ExecuteNonQuery("UPDATE OutgoingShipmentRequests SET status = 'FOR SCHEDULING' WHERE out_shipment_id = '"+row["oms_shipment_id"].ToString()+"';", IsolationLevel.ReadCommitted);
        }
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
}

