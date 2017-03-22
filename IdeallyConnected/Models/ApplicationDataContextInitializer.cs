using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IdeallyConnected.Models
{
    public class ApplicationDataContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        public ApplicationDataContextInitializer()
        {
            
            System.Diagnostics.Debug.WriteLine("In AppDataContextInitializer constructor.",ConsoleColor.Red);
        }

        protected override void Seed(ApplicationDbContext context)
        {
            
        }
    }
}