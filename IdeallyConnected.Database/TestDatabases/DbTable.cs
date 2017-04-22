using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public abstract class DbTable : IDbTable
    {
        public int TotalRows { get; set; }
        public int TotalColumns { get; set; }
        public static IReadOnlyList<string> Procedures { get; set; }
        public static string CsvFilePath { get; set; }
    }
}
