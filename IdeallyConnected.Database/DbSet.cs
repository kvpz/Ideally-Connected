using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{

    /// <summary>
    /// This class represents an instance of a table in the database, and it can be thought
    /// of as a generic Relation Database Object.
    /// Data associated from an instance of this class is not inserted into the database
    /// unless specified, nor does it necessarily contain data from the database. 
    /// </summary>
    /// <typeparam name="DbTableType">The class representing the entire database.</typeparam>
    public class DataSet<DbTableType> : Model<DbTableType>, IEnumerable<DbTableType> where DbTableType : class, new()
    {
        private List<DbTableType> _localData { get; set; }
        private bool _savedToDatabase = false;
        private bool _added = false;

        public DataSet()
        {
            _localData = new List<DbTableType>();
        }

        public void Add(DbTableType strArr)
        {
            _localData.Add(strArr);
            _added = false;
        }

        public void Clear()
        {
            _localData.Clear();
        }

        public IEnumerator<DbTableType> GetEnumerator()
        {
            return _localData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _localData.GetEnumerator();
        }

        public static implicit operator DataSet<DbTableType>(List<DbTableType> d)
        {
            DataSet<DbTableType> newDbSet = new DataSet<DbTableType>();
            newDbSet._localData = new List<DbTableType>(d);
            return newDbSet;
        }

        public static implicit operator List<DbTableType>(DataSet<DbTableType> d)
        {
            return d._localData;
        }
    }
}
