using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Reflection;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using IdeallyConnected.TestDatabases;

namespace IdeallyConnected.DatabaseManager.Tools
{
    public class CSVParser
    {
        /// <summary>
        /// Rapidly import a bulk dataset into the database using a stored procedure. This method does not check
        /// for constraints upon insert.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="recordsToLoad">A collection of records to insert.</param>
        /// <param name="connectionString">Database connection string.</param>
        /// <param name="procedureName">Name of the stored procedure.</param>
        /// <param name="sqlParameterName">Name of the parameter in the stored procedure.</param>
        /// <param name="tableName">Name of the table in the database.</param>
        /// <param name="columns">Set of column names and their respective data type.</param>
        /// <returns></returns>
        public int QuickImport<T>(List<T> recordsToLoad, string connectionString, string procedureName, string sqlParameterName, string tableName, Dictionary<string, Type> columns) where T: new()
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a datatable similar to the existing database table
                DataTable dataTable = new DataTable(tableName);
                foreach (KeyValuePair<string, Type> column in columns)
                {
                    dataTable.Columns.Add(column.Key, column.Value);
                }

                // Create the SQL command
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = procedureName,
                    Parameters = { new SqlParameter(sqlParameterName, SqlDbType.Structured) { Value = dataTable } },
                };

                // Load the records in the database 
                foreach (T record in recordsToLoad)
                {
                    DataRow row = dataTable.NewRow();
                    foreach(string c in columns.Keys)
                    {
                        row[c] = record.GetType().GetProperty(c).GetValue(record);
                    }
                    dataTable.Rows.Add(row);
                }

                rowsAffected = sqlCommand.ExecuteNonQuery();
                connection.Close();
            }

            return rowsAffected;
        }
    }

}
