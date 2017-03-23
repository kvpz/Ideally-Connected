using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Core.Service
{
    public interface ICRUDService<T> where T : new()
    {
        int Create(T item);
        void Save();
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> func, bool showDeleted = false);
        void Restore(int id);
        void BatchDelete(int[] ids);
        void BatchRestore(int[] ids);
    }
}
