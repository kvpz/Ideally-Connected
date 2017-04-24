using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases.Configurations
{
    /// <summary>
    /// Represents a collection of tables such that a database can contain multiple tables.
    /// </summary>
    public class TablesCollection : ConfigurationElementCollection
    {
        public TablesCollection()
        {
            TableElement table = (TableElement)CreateNewElement();
            BaseAdd(table);
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

        public TableElement this[int index]
        {
            get
            {
                return (TableElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public TableElement this[string Name]
        {
            get
            {
                return (TableElement)BaseGet(Name);
            }
        }

        public int IndexOf(TableElement url)
        {
            return BaseIndexOf(url);
        }

        public void Add(TableElement url)
        {
            BaseAdd(url);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Clear()
        {
            BaseClear();
        }

        public void Remove(TableElement url)
        {
            if (BaseIndexOf(url) >= 0)
                BaseRemove(url.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
}
