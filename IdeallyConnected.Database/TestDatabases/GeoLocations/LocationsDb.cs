using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public class LocationsDb : DbManager
    {
        public Location _Location { get; set; }

        public LocationsDb()
            : base("Locations")
        {
            _Location = new Location();
        }
    }
}
