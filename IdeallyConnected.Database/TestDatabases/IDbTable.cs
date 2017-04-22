using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    interface IDbTable
    {
        int TotalRows { get; set; }
        int TotalColumns { get; set; }
    }
}
