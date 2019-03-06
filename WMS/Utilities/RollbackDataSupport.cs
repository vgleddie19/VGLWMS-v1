using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Web;
using Framework;

namespace Framework
{
    public class RollbackDataSupport
    {

        public SqlTransaction trans;
        public SqlConnection conn;

        public RollbackDataSupport()
        {
            DataSupport dh = new DataSupport();
            conn = new SqlConnection(dh.ConnectionString);
            conn.Open();
            trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void CommitData()
        {
            trans.Commit();
            conn.Close();
        }




        private static DataSet ConvertDataReaderToDataSet(SqlDataReader reader)
        {
            DataSet dataSet = new DataSet();
            do
            {
                // Create new data table

                DataTable schemaTable = reader.GetSchemaTable();
                DataTable dataTable = new DataTable();

                if (schemaTable != null)
                {
                    // A query returning records was executed

                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        DataRow dataRow = schemaTable.Rows[i];
                        // Create a column name that is unique in the data table
                        string columnName = (string)dataRow["ColumnName"]; //+ "<C" + i + "/>";
                        // Add the column definition to the data table
                        DataColumn column = new DataColumn(columnName);
                        try
                        {
                            dataTable.Columns.Add(column);
                        }
                        catch (DuplicateNameException)
                        {
                            int count = 0;
                            while (dataTable.Columns[columnName] != null)
                            {
                                columnName += count;
                                count++;
                            }
                            column.ColumnName = columnName;
                            dataTable.Columns.Add(column);
                        }
                    }

                    dataSet.Tables.Add(dataTable);

                    // Fill the data table we just created

                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                            dataRow[i] = reader.GetValue(i);

                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    // No records were returned

                    DataColumn column = new DataColumn("RowsAffected");
                    dataTable.Columns.Add(column);
                    dataSet.Tables.Add(dataTable);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = reader.RecordsAffected;
                    dataTable.Rows.Add(dataRow);
                }
            }
            while (reader.NextResult());

            foreach (DataTable dt in dataSet.Tables)
            {
                dt.AcceptChanges();
            }
            reader.Close();
            return dataSet;
        }

        public DataSet RunDataSet(String sql)
        {
            DataSet result = null;
            try
            {
                SqlCommand command = conn.CreateCommand();
                command.Transaction = trans;
                command.CommandText = sql;
                result = ConvertDataReaderToDataSet(command.ExecuteReader());

            }
            catch (SqlException ex)
            {
                trans.Rollback();
                ex.ToString();
                result = null;
                throw;
            }
            return result;
        }

        public void RunNonQuery(String sql)
        {
            try
            {
                SqlCommand command = conn.CreateCommand();
                command.Transaction = trans;
                command.CommandText = sql;
                command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                trans.Rollback();
                ex.ToString();
                throw;
            }
        }


    }
}
