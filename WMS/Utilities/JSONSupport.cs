using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json.Linq;


public static class JSONSupport
{


    public static Dictionary<K,V> AsDictionary<K,V>(this DataRow row) 
    {
        Dictionary<K, V> result = new Dictionary<K, V>();
        DataTable dt = row.Table;
        foreach (DataColumn col in dt.Columns)
            result.Add((K)((Object)col.ColumnName),(V) ((Object)row[col].ToString()));
        return result;
    }

    public static Dictionary<String, Object> ConvertRowToDict(this DataTable dt, int index)
    {
        Dictionary<String, Object> result = new Dictionary<String, Object>();
        DataRow row = dt.Rows[index];
        foreach (DataColumn col in dt.Columns)
        {
            result.Add(col.ColumnName, row[col].ToString());
        }
        return result;
    }

    public static Dictionary<K, V> ConvertRowToDict<K, V>(this DataTable dt, int index)
    {
        Dictionary<K, V> result = new Dictionary<K, V>();
        DataRow row = dt.Rows[index];
        foreach (DataColumn col in dt.Columns)
            result.Add((K)((Object)col.ColumnName), (V)((Object)row[col].ToString()));
        return result;
    }

    public static Dictionary<String, Object> ConvertColumnToDict(this DataTable dt, String key_column, String value_column)
    {
        var result = new Dictionary<String, Object>();
        foreach (DataRow row in dt.Rows)
            result.Add(row[key_column].ToString(), row[value_column].ToString());
        return result;
    }

    public static Dictionary<K, V> ConvertColumnToDict<K,V>(this DataTable dt, String key_column, String value_column)
    {
        var result = new Dictionary<K, V>();
        foreach (DataRow row in dt.Rows)
            result.Add((K)row[key_column],(V)row[value_column]);
        return result;
    }

    public static String ToStringJson(this DataRow obj)
    {
        var dict = obj.Table.ToJSON(obj.Table.Rows.IndexOf(obj));
        return JsonConvert.SerializeObject(dict);
    }

    public static String ToStringJson(this Object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static DataTable DeserializeToDataTable(this String str)
    {
        DataTable result = new DataTable();
        try
        {
            var arr = JsonConvert.DeserializeObject<List<Dictionary<String, Object>>>(str);
            var first_row = arr[0];
            int rows = arr.Count;
            foreach (String col in first_row.Keys)
                result.Columns.Add(col);

            foreach (Dictionary<String, Object> dict in arr)
            {
                var new_row = result.Rows.Add();
                foreach (String col in dict.Keys)
                {
                    new_row[col] = dict[col];
                }
            }
                
        }
        catch (Exception)
        { 
            
        }
        return result;
    }

    public static String SerializeObject (this Object o)
    {
        String result = "";
        result = JsonConvert.SerializeObject(o);
        return result;
    }

    public static Dictionary<String, Object> DeserializeObject(this String str)
    {
        return JsonConvert.DeserializeObject<Dictionary<String, Object>>(str);
    }
              
    public static Dictionary<String, Object> ToJSON(this DataTable dt, int index)
    {
        Dictionary<String, Object> row;
        DataRow dr = dt.Rows[index];
        row = new Dictionary<String, Object>();
        foreach (DataColumn col in dt.Columns)
        {
            row.Add(col.ColumnName, dr[col]);
        }
        return row;
    }

    public static List<List<Dictionary<String, Object>>> ToJSON(this DataSet set)
    {
        List<List<Dictionary<String, Object>>> result = new List<List<Dictionary<string, object>>>();
        foreach (DataTable dt in set.Tables)
            result.Add(ToJSON(dt));
        return result;
    }


    public static Dictionary<String, Object> ToJSON(this DataTable dt, String value_column, String display_column)
    {
        var result = new Dictionary<String, Object>();
        foreach (DataRow row in dt.Rows)
            result.Add(row[value_column].ToString(), row[display_column]);
        return result;
    }

    public static String ToStringJSON(this DataTable dt)
    {
        return dt.ToJSON().ToStringJson();
    }

    public static List<Dictionary<String, Object>> ToJSON(this DataTable dt)
    {
        List<Dictionary<String, Object>> rows = new List<Dictionary<String, Object>>();
        Dictionary<String, Object> row;
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<String, Object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        return rows;
    }
}
    
