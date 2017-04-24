using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases.Configurations
{
    /// <summary>
    /// A configuration element used to represent a database.
    /// </summary>
    public class DbConfigElement : ConfigurationElement
    {
        public DbConfigElement() { }

        [StringValidator(InvalidCharacters = "()[]{}!@#$%&*;'\",<>?")]
        [ConfigurationProperty("databaseName")]
        public string DatabaseName
        {
            get
            {
                return (string)this["databaseName"];
            }
            set
            {
                ThrowIfReadOnly("databaseName");
                this["databaseName"] = value;
            }
        }

        [ConfigurationProperty("connectionString")]
        public string ConnectionString
        {
            get
            {
                return (string)this["connectionString"];
            }
            set
            {
                ThrowIfReadOnly("connectionString");
                this["connectionString"] = value;
            }
        }

        [StringValidator(InvalidCharacters = "()[]{}!@#$%&*;'\",<>?")]
        [ConfigurationProperty("csvFilePath")]
        public string CsvFilePath
        {
            get
            {
                return (string)this["csvFilePath"];
            }
            set
            {
                ThrowIfReadOnly("CsvFilePath");
                this["csvFilePath"] = value;
            }
        }

        [StringValidator(InvalidCharacters = "()[]{}!@#$%&*;'\",<>?")]
        [ConfigurationProperty("excelFilePath")]
        public string ExcelFilePath
        {
            get
            {
                return (string)this["excelFilePath"];
            }
            set
            {
                ThrowIfReadOnly("ExcelFilePath");
                this["excelFilePath"] = value;
            }
        }

        /*
        [ConfigurationProperty("tableName")]
        public string TableName
        {
            get
            {
                return (string)this["tableName"];
            }
            set
            {
                ThrowIfReadOnly("tableName");
                this["tableName"] = value;
            }
        }
        */

        public override bool IsReadOnly()
        {
            return base.IsReadOnly();
        }

        private void ThrowIfReadOnly(string property)
        {
            if (IsReadOnly())
            {
                throw new ConfigurationErrorsException("The property " + property + " is read-only.");
            }
        }
    }
}
