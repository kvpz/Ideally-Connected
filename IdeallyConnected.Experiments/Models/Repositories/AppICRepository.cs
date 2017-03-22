using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Models.Repositories
{
    public class AppICRepository<T> : IDisposable where T : class
    {
        private AppICDbContext dbcontext = null;
        protected DbSet<T> dbset { get; set; }

        // Implicit assignment operator for assigning a dbContext object to this class.
        public static implicit operator AppICRepository<T>(AppICDbContext dbContext) => new AppICRepository<T>(dbContext);

        public AppICRepository()
        {
            Console.WriteLine("In AppICRepository() constructor");
            dbcontext = new AppICDbContext(); 
            dbset = dbcontext.Set<T>(); 
        }

        public AppICRepository(AppICDbContext dbContext)
        {
            Console.WriteLine("In AppICRespotiroy(DSflknasd;klgknasewf) constructor");
            this.dbcontext = dbContext;
        }

        public List<T> GetAll()
        {
            return dbset.ToList();
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbcontext.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            dbset.Remove(dbset.Find(id));
        }

        public void SaveChanges()
        {
            try 
            {
                dbcontext.SaveChanges();
            }
            catch(Exception e) {
                Console.WriteLine("Caught error in savechanges() woop woop!:");
                Console.WriteLine(e);
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        private Boolean disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(Boolean disposing)
        {
            if(disposed) {
                return;
            }

            if(disposing) {
                //TODO: Managed cleanup code here, while managed refs still valid
            }
            //TODO: Unmanaged cleanup code here

            disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate 
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The destructor for the class.
        /// </summary>
        ~AppICRepository()
        {
            this.Dispose(false);
        }


        #endregion

    }

}
