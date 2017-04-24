using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases.Location
{
    public class LocationDb : DbManager
    {
        public Location _Location { get; set; }

        public LocationDb()
            : base("Locations")
        {
            _Location = new Location();
        }
    }
}
