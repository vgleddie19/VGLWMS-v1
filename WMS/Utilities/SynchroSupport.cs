using Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


public static class SynchroSupport
{

    public static void UpdateOrderStatus(String release_id)
    {
        var dt = DataSupport.RunDataSet("SELECT ORDER_ID[Order], drop_sequence[Drop], Status FROM ReleaseDetails WHERE release = @release_id ORDER BY drop_sequence", "release_id", release_id).Tables[0];
        foreach (DataRow row in dt.Rows)
        {
            String order_id = row["Order"].ToString();
            var index = dt.Rows.IndexOf(row);
            if (row["Status"].ToString() == "RELEASING")
            {
                var remaining =   int.Parse( DataSupport.RunDataSet("SELECT SUM(order_qty-scanned_qty)[remaining] FROM ReleaseDetailItems WHERE release = @release AND order_id = @order_id", "release", release_id, "order_id", order_id ).Tables[0].Rows[0][0].ToString());
                if (remaining <= 0)
                {
                    DataSupport.RunNonQuery("UPDATE ReleaseDetails SET Status='RELEASED' WHERE release = @release_id AND order_id = @order_id", "release_id", release_id, "order_id", order_id);
                    if (index == dt.Rows.Count - 1)
                        DataSupport.RunNonQuery("UPDATE Releases SET Status='RELEASED' WHERE release_id = @release_id", "release_id", release_id);
                    else
                    {
                        var next_row = dt.Rows[index + 1];
                        DataSupport.RunNonQuery("UPDATE ReleaseDetails SET Status='RELEASING' WHERE release = @release_id AND order_id = @order_id", "release_id", release_id, "order_id", next_row["Order"].ToString());
                       
                    }
                }

                return;
            }
        }
    }


    public static String ToUpsert(this DataTable dt, String table, params String[] primary_keys)
    {
        StringBuilder result = new StringBuilder();
        var list = primary_keys.ToList();


        foreach (DataRow row in dt.Rows)
        {
            Dictionary<String, Object> insert_list = new Dictionary<string, object>();
            List<String> primary_list = new List<string>();
            foreach (DataColumn col in dt.Columns)
            {
                insert_list.Add(col.ColumnName, row[col]);
                if(list.Contains(col.ColumnName))
                    primary_list.Add(col.ColumnName);
            }

            result.Append(DataSupport.GetUpsert(table, insert_list, primary_list));
        }
        return result.ToString();
    }


    public static String ToInsert(this DataTable dt, String table)
    {
        StringBuilder result = new StringBuilder();
        foreach (DataRow row in dt.Rows)
        {
            Dictionary<String, Object> insert_list = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
                insert_list.Add(col.ColumnName, row[col]);
            result.Append( DataSupport.GetInsert(table, insert_list));
        }
        return result.ToString();
    }



}

