using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Framework;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;


namespace Framework
{
    public static class WebControlSupport
    {
        
        public static Boolean In(this String str, params Object[] parameters)
        {            
            foreach (Object obj in parameters)
                if (obj.ToString().Trim() == str.Trim())
                    return true;
            return false;
        }

        public static DataTable Sort(this DataTable dt, String expression)
        {
            DataView dv = dt.DefaultView;
            dv.Sort = expression;
            return dv.ToTable();
             
        }

        public static String FormatFilter(this List<String> list)
        {
            return FormatFilter(list, ",");
        }
        public static String FormatFilter(this List<String> list, String delimiter)
        {
            return FormatFilter(list, delimiter, "'");
        }

        public static String FormatFilter(this List<String> list, String delimiter, String quote)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                String value = list[i];
                result.Append(quote +  value.EscapeString() + quote);
                if (i < list.Count - 1)
                    result.Append(delimiter);
            }
            return result.ToString();
        }

        public static List<String> ToList(this DataTable dt, String column)
        {
            List<String> result = new List<string>();
            foreach (DataRow row in dt.Rows)
                result.Add(row[column].ToString());
            return result;
        }

        public static String EscapeString(this string source)
        { 
            String result = source.Replace("'", "''"); // MSSQL Escaping
            result = System.Security.SecurityElement.Escape(result); // XML Escaping
            result = new SqlParameter("val", result).SqlValue.ToString(); ; // Generic SQL Server Parameter Escaping     
            return result;
        }
        public static DataTable FormatMoneyColumn(this DataTable dt,int decimals, params String[] columns)
        {
            String format = "0,0.";
            for (int i = 0; i < decimals; i++)
                format += "0";
            foreach (DataRow row in dt.Rows)
                foreach (String col in columns)
                {
                    double amount = 0;
                    if (dt.Columns.Contains(col))
                        if (double.TryParse(row[col].ToString(), out amount))
                            row[col] = amount.ToString(format); 
                }
            return dt;
        }

        public static DataTable FormatMoneyColumn(this DataTable dt, params String[] columns)
        {
            foreach (DataRow row in dt.Rows)
                foreach (String col in columns)
                {
                    double amount = 0;
                    if (dt.Columns.Contains(col))
                        if (double.TryParse(row[col].ToString(), out amount))
                            row[col] = FormatMoney(amount);
                }
            return dt;
        }

        public static DataTable MergeColumns(this DataTable dt, String dest_col, String src_col, String delimiter)
        {
            foreach (DataRow row in dt.Rows)
                row[dest_col] =  row[src_col] + delimiter + row[dest_col];
            dt.Columns.Remove(src_col);
            return dt;
        }

        public static DataTable FormatAttribute(this DataTable dt, String attribute, params String[] columns)
        {
            foreach (DataRow row in dt.Rows)
                foreach (String col in columns)
                    row[col] = "<div " + attribute + " >" + row[col] + "</div>";
            return dt;
        }

        public static DataTable FormatStyle(this DataTable dt, String style, params String[] columns)
        {
            foreach (DataRow row in dt.Rows)
                foreach (String col in columns)
                    row[col] = "<div style='"+style+"'>" + row[col] + "</div>";
            return dt;
        }
       

        public static String RemoveHTMLTags(String str)
        {
            return new System.Text.RegularExpressions.Regex("<[^>]*>").Replace(str, "");
        }

        public static String FormatMoney(this double amount)
        {
            return amount.ToString("0,0.00");
        }
        

        public static String CleanFormat(this string source, params object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
                parameters[i] = EscapeString(parameters[i].ToString());
            return String.Format(source, parameters);
        }

        public static String AttachPaging( ref int page, ref int page_size)
        {
            String result = "";
            if (page != -1)
                result = @" OFFSET (@page-1) * @page_size ROWS FETCH NEXT @page_size ROWS ONLY;";
            else
                page_size = page = -1;
            return result;
        }
        public static List<int> GetSurrouding(this int current, int count, int start, int end)
        {
            List<int> result = new List<int>();
            int original_count = count;
            int counter = 0;
            for (int i = current; i >= start; i--)
            {

                result.Add(i);
                count--;
                if (count == 0)
                    return result;
                counter++;
                if (counter == original_count / 2)
                    break;
            }
            counter = 0;

            for (int i = current + 1; i <= end; i++)
            {
                result.Add(i);
                count--;
                if (count == 0)
                    return result;
                counter++;
                if (counter == original_count / 2)
                    break;
            }
            for (int i = current; i >= start; i--)
            {
                if (result.Contains(i))
                    continue;
                result.Add(i);
                count--;
                if (count == 0)
                    return result;
            }
            for (int i = current + 1; i <= end; i++)
            {
                if (result.Contains(i))
                    continue;
                result.Add(i);
                count--;
                if (count == 0)
                    return result;
            }
            return result;
        }

        public static void Blacklist(this Dictionary<String,Object> dict, List<String> list)
        {
            foreach (String key in list)
                if (dict.Keys.Contains(key))
                    dict.Remove(key);
        }

        public static void Whitelist(this Dictionary<String, Object> dict, List<String> list)
        {
            List<String> keys = dict.Keys.ToList();
            foreach (String key in keys)
                if (!list.Contains(key))
                    dict.Remove(key);
        }

        public static String ToStringNull(this Object obj)
        {
            return (obj == null) ? "" : obj.ToString();
        }

        /// <summary>
        /// Gets an Uppercast list of column names
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<String> GetColumnList(this DataTable dt)
        {
            var result = new List<String>();
            foreach (DataColumn column in dt.Columns)
            {
                result.Add(column.ColumnName.ToUpper());
            }
            return result;
        }


        public static String[] ToArray(this DataTable dt, String column)
        {
            List<String> result = new List<String>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(row[column].ToString());
            }
            return result.ToArray();
        }

        /// <summary>
        /// Group By Execution for Datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="key_col">grouping label column</param>
        /// <param name="value_col">value column to be grouped</param>
        /// <returns></returns>
        public static Dictionary<String, double> CollapseTable(DataTable dt, String key_col, String value_col)
        {
            Dictionary<String, double> result = new Dictionary<String, double>();

            foreach (DataRow row in dt.Rows)
            {
                String key = row[key_col].ToString();
                double value = 0;
                double.TryParse(row[value_col].ToString(), out value);
                if (result.Keys.Contains(key))
                {
                    result[key] += value;
                }
                else
                {
                    result.Add(key, value);
                }
            }


            return result;
        }

        public static Object GetValue(this Dictionary<String, Object> dict, String key, String default_value)
        {
            if (dict.Keys.Contains(key))
                return dict[key];
            return default_value;
        }

        public static Object GetValue(this Dictionary<String, Object> dict, String key)
        {
            if (dict.Keys.Contains(key))
                return dict[key];
            return "";
        }

        public static Object[] GetValueDictAndDeleteKey(this Dictionary<String, Object> dict, String key)
        {
            return (Object[])GetValueAndDeleteKey(dict, key);
        }

        public static Object GetValueAndDeleteKey(this Dictionary<String, Object> dict, String key)
        {
            Object result = "";
            if (dict.Keys.Contains(key))
            {
                result =  dict[key];
                dict.Remove(key);
            }
            return result;
        }

        /// <summary>
        /// Format a list into a comma separated string with values enclosed in single quotes
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static String FormatList(String list)
        {
            String result = "";
            List<String> arr = list.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (String str in arr)
            {
                result += "'" + str.Trim() + "'";
                if (arr.IndexOf(str) < arr.Count - 1)
                    result += ",";
            }
            return result;
        }

        public static List<String> GetUniqueValues(DataTable dt, String column)
        {
            List<String> result = new List<String>();
            foreach (DataRow row in dt.Rows)
            {
                if (!result.Contains(row[column].ToString()))
                    result.Add(row[column].ToString());
            }
            return result;
        }


        /// <summary>
        /// Get an HTML Select that counts from a count
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static String GetHTMLSelect(int count)
        {
            String result = "";
            result = "<select style='width:50px;'>";
            for (int i = 0; i <= count; i++)
            {
                result += String.Format("<option value='{0}'>{0}</option>", i);
            }
            result += "</select>";
            return result;
        }

        /// <summary>
        /// Sort a datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="column"></param>
        /// <param name="type">type of sorting</param>
        public static void SortDT(DataTable dt, String column, String type)
        {
            switch (type)
            {
                case "DECIMAL":
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 1; j < dt.Rows.Count; j++)
                        {
                            if (decimal.Parse(dt.Rows[j][column].ToString()) < decimal.Parse(dt.Rows[j - 1][column].ToString()))
                            {
                                Object[] temp = dt.Rows[j].ItemArray;
                                CopyRow(dt, j, j - 1);
                                CopyToRow(dt.Rows[j - 1], temp);

                            }
                        }
                    }

                    break;
            }

        }

        public static void CopyRow(DataTable dt, int to, int from)
        {
            foreach (DataColumn col in dt.Columns)
            {
                dt.Rows[to][col] = dt.Rows[from][col];
            }
        }

        public static void CopyToRow(DataRow row, Object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
        }
        
        public static String GetCaptcha(String base_string)
        {
            String result = "";

            String[] arr = base_string.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arr.Length; i++)
            {
                String str = arr[i];
                int x = int.Parse(str);
                x += i * 2;
                result += x.ToString();
                if (i < arr.Length - 1)
                    result += ",";

            }
            return result;
        }

        /// <summary>
        /// Deep Copy clone of the datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable CloneDT(this DataTable dt)
        {
            DataTable result = new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                result.Columns.Add(col.ColumnName);
            }
            foreach (DataRow row in dt.Rows)
            {
                DataRow new_row = result.Rows.Add(new Object[] { });
                foreach (DataColumn col in dt.Columns)
                {
                    new_row[col.ColumnName] = row[col].ToString();
                }
            }

            return result;
        }

    

        

      


        

        /// <summary>
        /// Format a datetime accordingly
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="format"></param>
        public static void FormatDateTime(ref String datetime, String format)
        {
            try
            {
                datetime = DateTime.Parse(datetime).ToString(format);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Format money columns
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cols"></param>
        public static void FormatMoneyColumn(DataTable dt, List<int> cols)
        {
            foreach (DataRow row in dt.Rows)
            {
                foreach (int col in cols)
                {
                    double temp = 0.0;
                    if (double.TryParse(row[col].ToString(), out temp))
                    {
                        row[col] = temp.ToString("00.00");
                    }
                }
            }
        }
     
        /// <summary>
        /// Get a matching row with a particular value
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <param name="column_key">Column name to be searched</param>
        /// <param name="column_value">Value to be searched</param>
        /// <returns></returns>
        public static DataRow GetMatchingRow(DataTable sourceTable, String column_key, String column_value)
        {
            DataRow result = null;
            foreach (DataRow row in sourceTable.Rows)
            {
                if (row[column_key].ToString() == column_value)
                    return row;
            }

            return result;
        }

        /// <summary>
        /// Render an html table that has a thead and tbody. OPTIONS column is by default rendered as html
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="name">html id of the table</param>
        /// <returns></returns>
        public static String RenderSmartGrid(this DataTable dt, String name)
        {
            return RenderSmartGrid(dt, name, new List<String>() { "OPTIONS"});
        }

        public static String RenderSmartGrid(this DataTable dt, String name, Boolean is_all_html)
        {
            var list = new List<String>() { "OPTIONS" };
            if (is_all_html)
                foreach (DataColumn column in dt.Columns)
                    list.Add(column.ColumnName);
            return RenderSmartGrid(dt, name, list);
        }

        /// <summary>
        /// Render an html table that has thead and tbody.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="name">html id of the table</param>
        /// <param name="html_columns">list of columns to be rendered as html (not text)</param>
        /// <returns></returns>
        public static String RenderSmartGrid(this DataTable dt, String name, List<String> html_columns)
        {
            StringBuilder result = new StringBuilder();
            result.Append(String.Format("<table id='{0}' class='table table-striped table-bordered'>\r\n", name));
            
            // Render the column headers
            result.Append("<thead>");
            result.Append("<tr>");
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                DataColumn col = dt.Columns[j];
                result.Append(String.Format("<th>{0}</th>", col.ColumnName.ToUpper()));
            }

            result.Append("</tr>");
            result.Append("</thead>");
            result.Append("<tbody>");
            // Render the rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                result.Append( String.Format("<tr id='{0}' >  ", name + "_tr_" + i, name));


                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    DataColumn col = dt.Columns[j];
                    String contents = row[col].ToString();
                    result.Append(String.Format("<td id='{0}' >{1}</td>", name + "_td_" + i + "_" + j, contents));
                }
                result.Append("</tr>\r\n");
            }
            result.Append("</tbody>");
            result.Append( "</table>\r\n");
            return result.ToString();
        }

         /// <summary>
         /// Enumerates datetime objects
         /// </summary>
         /// <param name="date_start"></param>
         /// <param name="date_end"></param>
         /// <returns></returns>
        public static List<DateTime> GetDateTimeRangeDetails(DateTime date_start, DateTime date_end)
        {
            List<DateTime> dates = new List<DateTime>();
            for (DateTime i = date_start; i < date_end; i = i.AddDays(1))
            {
                dates.Add(i);
            }
            return dates;
        }

    }
    
}
