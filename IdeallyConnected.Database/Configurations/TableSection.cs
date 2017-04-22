using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases.Configurations
{
    public sealed class TablesCollection : ConfigurationElementCollection
    {
        public TablesCollection()
        {
            TableElement table = (TableElement)CreateNewElement();
        }

        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.AddRemoveClearMap;

        protected override ConfigurationElement CreateNewElement()
        {
            return new TableElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TableElement)element).Name;
        }
    }
}
