using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases.Configurations
{
    public sealed class DbConfigSection : ConfigurationSection
    {
        private DbConfigSection() { }

        private static bool _ReadOnly;

        #region properties
        [ConfigurationProperty("database")]
        public DbConfigElement DatabaseConfig
        {
            get
            {
                return (DbConfigElement)this["database"];
            }
        }
        
        [ConfigurationProperty("tables", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(TablesCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public TablesCollection Tables
        {
            get
            {
                TablesCollection t = (TablesCollection)this["tables"];
                return t;
            }
        }
        #endregion

        private void ThrowIfReadOnly(string propertyName)
        {
            if (IsReadOnly)
            {
                throw new ConfigurationErrorsException("The property " + propertyName + " is read only.");
            }
        }

        protected override object GetRuntimeObject()
        {
            _ReadOnly = true;
            return base.GetRuntimeObject();
        }

        private new bool IsReadOnly
        {
            get
            {
                return _ReadOnly;
            }
        }
    }
}
