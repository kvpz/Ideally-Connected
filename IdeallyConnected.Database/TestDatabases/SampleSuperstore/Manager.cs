using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases.SampleSuperstore
{
    public class Manager : DbTable
    {
        public Manager()
        {

        }

        public Manager(string csvFilePath)
        {
            CsvFilePath = csvFilePath;
        }

        public string Person { get; set; }
        public string Region { get; set; }
    }
}
