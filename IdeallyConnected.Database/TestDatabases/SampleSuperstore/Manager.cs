using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public class Manager : Model<Manager>
    {
        public string Person { get; set; }
        public string Region { get; set; }

        public Manager()
        { }

        public Manager(params string[] attributes)
        {
            Person = attributes[0];
            Region = attributes[1];
        }
        
        public static implicit operator Manager(string[] attributes)
        {
            return new Manager(attributes);
        }
    }
}
