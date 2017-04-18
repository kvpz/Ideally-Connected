using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Reflection;

namespace IdeallyConnected.Utility
{
    public class LocationRecord
    {
        public string City { get; set; }
        public string StateAcronym { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZipCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }

    public class CSVParser
    {
        public List<LocationRecord> LoadLocationsFile(string fileLocation)
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            List<LocationRecord> result = new List<LocationRecord>();
            StreamReader fstream = File.OpenText(fileLocation); //  "uscitiesv1.1.csv");
            CsvReader csvstream = new CsvReader(fstream);

            while (csvstream.Read())
            {
                LocationRecord record = new LocationRecord();
                record.City = csvstream.GetField(0);
                result.Add(record);
                Console.WriteLine(record.City);
            }

            return result;
        }
    }
}
