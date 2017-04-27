using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Core.Repository
{
    public interface IRepository<T>
    {
        T Get(int d);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false);
        T Add(T obj);
        void SaveChanges();
        void Delete(T obj);
    }
}
