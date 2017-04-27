using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases.Configurations
{
    /// <summary>
    /// The configuration element used to represent a table in a database.
    /// </summary>
    public class TableElement : ConfigurationElement
    {
        public TableElement()
        {

        }
        
        public TableElement(string name)
        {
            this.Name = name;
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

        [ConfigurationProperty("procedures")]
        public string Procedures
        {
            get
            {
                return (string)this["procedures"];
            }
            set
            {
                this["procedures"] = value;
            }
        }
    }
    
}
