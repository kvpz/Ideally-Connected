using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models.Repositories
{
    public class Repository<T>:IDisposable where T : class
    {
        private bool disposed = false;
        private AppDataContext context = null;

        public void Dispose()
        {
            
            //throw new NotImplementedException();
        }
    }
}