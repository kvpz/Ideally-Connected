using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public class Location
    {
        private string locationsCSVFile = "C:\\Users\\kp12g_000\\Documents\\Visual Studio 2017\\Projects\\CSharpFinalProject\\IdeallyConnected.Utility\\uscitiesv1.1.csv";

        public string ZipCode { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int Population { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }


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

        public void LoadLocationCSVData()
        {
            List<Location> records = LoadLocationsCSVFile(locationsCSVFile);
            string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=LocationsDb; Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "LocationReader"
                };

                foreach (Location locationRecord in records)
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@ZipCode", locationRecord.ZipCode);
                    sqlCommand.Parameters.AddWithValue("@State", locationRecord.State);
                    sqlCommand.Parameters.AddWithValue("@StateAbbreviation", locationRecord.StateAbbreviation);
                    sqlCommand.Parameters.AddWithValue("@City", locationRecord.City);
                    sqlCommand.Parameters.AddWithValue("@County", locationRecord.County);
                    sqlCommand.Parameters.AddWithValue("@Population", locationRecord.Population);
                    sqlCommand.Parameters.AddWithValue("@Latitude", locationRecord.Latitude);
                    sqlCommand.Parameters.AddWithValue("@Longitude", locationRecord.Longitude);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// This loads about 25,000 records / second into the database. No logging. Data is cleaned to be valid; no null values.
        /// </summary>
        public int QuickInsertLocations()
        {
            List<Location> recordsToLoad = LoadLocationsCSVFile(locationsCSVFile);
            string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=LocationsDb; Trusted_Connection=True;";
            int recordsInserted = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // Create a Data Table
                DataTable locationDataTable = new DataTable("LocationData");
                locationDataTable.Columns.Add("ZipCode", typeof(string)).MaxLength = 5;
                locationDataTable.Columns.Add("State", typeof(string)).MaxLength = 100;
                locationDataTable.Columns.Add("StateAbbreviation", typeof(string)).MaxLength = 100;
                locationDataTable.Columns.Add("City", typeof(string)).MaxLength = 200;
                locationDataTable.Columns.Add("County", typeof(string)).MaxLength = 200;
                locationDataTable.Columns.Add("Population", typeof(int));
                locationDataTable.Columns.Add("Latitude", typeof(decimal));
                locationDataTable.Columns.Add("Longitude", typeof(decimal));

                // Load the data
                foreach (Location locationRecord in recordsToLoad)
                {
                    DataRow row = locationDataTable.NewRow();
                    row["ZipCode"] = locationRecord.ZipCode.Length > 5 ? locationRecord.ZipCode.Substring(0, 5) : locationRecord.ZipCode;
                    row["State"] = locationRecord.State;
                    row["StateAbbreviation"] = locationRecord.StateAbbreviation;
                    row["City"] = locationRecord.City;
                    row["County"] = locationRecord.County;
                    row["Population"] = locationRecord.Population;
                    row["Latitude"] = locationRecord.Latitude;
                    row["Longitude"] = locationRecord.Longitude;

                    // prevent duplicate zip codes in one column; cleaning data
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

                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "AddLocations",
                    Parameters = { new SqlParameter() { ParameterName = "@LocationData", SqlDbType = SqlDbType.Structured, Value = locationDataTable } }
                };

                recordsInserted = sqlCommand.ExecuteNonQuery();
            }

            return recordsInserted;
        }
    }
}
