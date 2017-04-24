using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public class Return : DbTable
    {
        public string OrderID { get; set; }
        public bool Returned { get; set; }
    }
}
