using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    /// <summary>
    /// This class represents an instance of a table in the database.
    /// Data associated from an instance of this class is not persisted or to the database
    /// unless specified, nor is it necessarily from the database.
    /// </summary>
    /// <typeparam name="DbType"></typeparam>
    public class DbSet<DbType> : IEnumerable<DbType> where DbType : class
    {
        private List<DbType> _localData { get; set; }

        public DbSet()
        {
            _localData = new List<DbType>();
        }

        public void Add(DbType strArr)
        {
            _localData.Add(strArr);
        }

        public static implicit operator DbSet<DbType>(List<DbType> d)
        {
            DbSet<DbType> newDbSet = new DbSet<DbType>();
            newDbSet._localData = d;
            return newDbSet;
        }

        public static implicit operator List<DbType>(DbSet<DbType> d)
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
