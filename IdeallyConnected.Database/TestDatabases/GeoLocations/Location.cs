using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public class Location
    {
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int Population { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
