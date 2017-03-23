using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IdeallyConnected.Data.Models
{
    public class ICDataContextInitializer : DropCreateDatabaseAlways<ICDbContext>
    {
        public ICDataContextInitializer()
        {
            
            System.Diagnostics.Debug.WriteLine("In AppDataContextInitializer constructor.", ConsoleColor.Red);
        }

        protected override void Seed(ICDbContext context)
        {
            
        }
    }
}