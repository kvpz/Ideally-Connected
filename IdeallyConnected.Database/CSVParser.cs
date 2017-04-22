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
        private string locationsCSVFile = "C:\\Users\\kp12g_000\\Documents\\Visual Studio 2017\\Projects\\CSharpFinalProject\\IdeallyConnected.Utility\\uscitiesv1.1.csv";

        /// <summary>
        /// Load the data from a csv file representing geolocation data. Procedure duration is approximately 800 records / second.
        /// CSV data provided by http://simplemaps.com/data/us-cities.
        /// Results are not accessed until they are enumerated.
        /// </summary>
        /// <param name="fileLocation"></param>
        /// <returns></returns>
        public List<Location> LoadLocationsCSVFile(string fileLocation)
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            List<Location> result = new List<Location>();
            StreamReader fstream = File.OpenText(fileLocation); 
            CsvReader csvstream = new CsvReader(fstream);
            csvstream.Read();

            while (csvstream.Read())
            {
                Location record = new Location();
                record.ZipCode = csvstream.GetField(0); // zip code
                record.State = csvstream.GetField(1); // State
                record.StateAbbreviation = csvstream.GetField(2); // State abbreviation
                record.City = csvstream.GetField(3); // City
                record.County = csvstream.GetField(4); // County
                int population;
                record.Population = csvstream.TryGetField<int>(5, out population) ? population : 0; // Population
                record.Latitude = csvstream.GetField<decimal>(6); // latitude
                record.Longitude = csvstream.GetField<decimal>(7); // longitude

                result.Add(record);
            }

            return result;
        }

        /// <summary>
        /// This loads about 25,000 records / second into the database.
        /// </summary>
        public void QuickLoadLocations()
        {
            List<Location> recordsToLoad = LoadLocationsCSVFile(locationsCSVFile);
            string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=LocationsDb; Trusted_Connection=True;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(); // based on ADO.NET
                sqlCommand.CommandText = "AddLocations";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@LocationData";
                sqlParameter.SqlDbType = System.Data.SqlDbType.Structured;
                sqlCommand.Parameters.Add(sqlParameter);

                // Load data
                DataTable locationDataTable = new DataTable("LocationData");
                locationDataTable.Columns.Add("ZipCode", typeof(string)).MaxLength = 5;
                locationDataTable.Columns.Add("State", typeof(string)).MaxLength = 100;
                locationDataTable.Columns.Add("StateAbbreviation", typeof(string)).MaxLength = 100;
                locationDataTable.Columns.Add("City", typeof(string)).MaxLength = 200;
                locationDataTable.Columns.Add("County", typeof(string)).MaxLength = 200;
                locationDataTable.Columns.Add("Population", typeof(int));
                locationDataTable.Columns.Add("Latitude", typeof(decimal));
                locationDataTable.Columns.Add("Longitude", typeof(decimal));
                foreach(Location locationRecord in recordsToLoad)
                {
                    DataRow row = locationDataTable.NewRow();
                    row["ZipCode"] = locationRecord.ZipCode.Length > 5 ? locationRecord.ZipCode.Substring(0,5) : locationRecord.ZipCode;
                    row["State"] = locationRecord.State;
                    row["StateAbbreviation"] = locationRecord.StateAbbreviation;
                    row["City"] = locationRecord.City;
                    row["County"] = locationRecord.County;
                    row["Population"] = locationRecord.Population;
                    row["Latitude"] = locationRecord.Latitude;
                    row["Longitude"] = locationRecord.Longitude;

                    // prevent duplicate zip codes in one column
                    if (locationRecord.ZipCode.Length > 5)
                    {
                        foreach (string zipcode in locationRecord.ZipCode.Split(' ').ToList())
                        {
                            row["ZipCode"] = zipcode; 
                            locationDataTable.Rows.Add(row.ItemArray);
                        }
                    }
                    else
                    {
                        locationDataTable.Rows.Add(row);
                    }
                }

                sqlCommand.Parameters["@LocationData"].Value = locationDataTable;
                int queriesExecuted = 0;
                try
                {
                    queriesExecuted = sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    Console.WriteLine($"\nTotal queries executed: {queriesExecuted}");
                }
            }
        }

        public void QuickLoad<T>(List<T> recordsToLoad, string connectionString, string sqlCommandName, string sqlParameterName, string tableName, Dictionary<string, Type> columns) where T: new()
        {
            //var recordsToLoad = records;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlCommandName;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = connection;
                SqlParameter sqlParameter = new SqlParameter(sqlParameterName, SqlDbType.Structured);
                sqlCommand.Parameters.Add(sqlParameter);
                
                DataTable dataTable = new DataTable(tableName);
                foreach(KeyValuePair<string, Type> column in columns)
                {
                    dataTable.Columns.Add(column.Key, column.Value);
                }

                foreach(T record in recordsToLoad)
                {
                    DataRow row = dataTable.NewRow();
                    foreach(string c in columns.Keys)
                    {
                        row[c] = record.GetType().GetProperty(c).GetValue(record);
                    }
                    dataTable.Rows.Add(row);
                }

                sqlCommand.Parameters[sqlParameterName].Value = dataTable;
                int queriesExecuted = 0;
                try
                {
                    queriesExecuted = sqlCommand.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    Console.WriteLine($"Queries executed: {queriesExecuted}");
                }
            }
        }

        public void LoadLocationCSVData()
        {
            List<Location> records = LoadLocationsCSVFile(locationsCSVFile);
            string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=LocationsDb; Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "LocationReader";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                foreach(var locationRecord in records)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ZipCode", locationRecord.ZipCode);
                    cmd.Parameters.AddWithValue("@State", locationRecord.State);
                    cmd.Parameters.AddWithValue("@StateAbbreviation", locationRecord.StateAbbreviation);
                    cmd.Parameters.AddWithValue("@City", locationRecord.City);
                    cmd.Parameters.AddWithValue("@County", locationRecord.County);
                    cmd.Parameters.AddWithValue("@Population", locationRecord.Population);
                    cmd.Parameters.AddWithValue("@Latitude", locationRecord.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", locationRecord.Longitude);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }

}
