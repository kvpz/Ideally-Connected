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
    /// <typeparam name="DbType"></typeparam>
    public class DataCollection<DbType> : IEnumerable<DbType> where DbType : class
    {
        private List<DbType> _localData { get; set; }

        public DataCollection()
        {
            _localData = new List<DbType>();
        }

        public void Add(DbType strArr)
        {
            _localData.Add(strArr);
        }

        public static implicit operator DataCollection<DbType>(List<DbType> d)
        {
            DataCollection<DbType> newDbSet = new DataCollection<DbType>();
            newDbSet._localData = d;
            return newDbSet;
        }

        public static implicit operator List<DbType>(DataCollection<DbType> d)
        {
            return d._localData;
        }

        public IEnumerator<DbType> GetEnumerator()
        {
            return _localData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _localData.GetEnumerator();
        }
    }
}
