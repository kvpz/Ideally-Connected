using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IdeallyConnected.Models
{
    public class ApplicationDataContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        
    }
}