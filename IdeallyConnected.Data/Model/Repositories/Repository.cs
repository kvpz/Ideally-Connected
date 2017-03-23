using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IdeallyConnected.Core.Repository;
using System.Data.Entity;

namespace IdeallyConnected.Data.Models.Repositories
{
    public class Repository<T>
        : IDisposable, IRepository<T> where T : class, new()
    {                               
        private bool disposed = false;
        protected readonly ICDbContext dbContext;
        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
            dbContext = new ICDbContext();
            DbSet = dbContext.Set<T>();
        }

        public Repository(ICDbContext context)
        {
            this.dbContext = context;
        }

        public T Add(T entity)
        {
            return DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            return DbSet.Where(predicate);
        }

        public virtual void Update(T entity)
        {
            dbContext.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                dbContext.Dispose();
                disposed = true;
            }
            throw new NotImplementedException();
        }
    }
}
