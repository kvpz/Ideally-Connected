using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases.Configurations
{
    public class TableElement : ConfigurationElement
    {
        public TableElement()
        {

        }

        [ConfigurationProperty("csvFile")]
        public string CsvFile
        {
            get
            {
                return (string)this["csvFile"];
            }
            set
            {
                this["csvFile"] = value;
            }
        }

        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
    }
}
