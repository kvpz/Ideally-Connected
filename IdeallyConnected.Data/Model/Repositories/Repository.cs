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
    /*
    Following Domain Driven Design, this 
    */
    public class Repository<T> : IDisposable, IRepository<T> where T : class, new()
    {                               
        private bool disposed = false;
        protected readonly ICDbContext dbContext;
        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
            this.dbContext = new ICDbContext();
            DbSet = dbContext.Set<T>();
        }

        public Repository(ICDbContext context)
        {
            this.dbContext = context;
            DbSet = dbContext.Set<T>();
        }
        
        public T Add(T entity)
        {
            return DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(string id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public T Get(string id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        /*
            Exceptions:
            - DbUpdateConcurrencyException is thrown when an optimistic concurrency is detected while attempting to 
            save an entity that uses foreign key associations.
        */
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
        }
    }
}
