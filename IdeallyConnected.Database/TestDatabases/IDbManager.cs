using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.TestDatabases
{
    public interface IDbManager
    {
        /// <summary>
        /// Stores all the custom procedures for the current database.
        /// </summary>
        IReadOnlyCollection<string> FeaturedProcedures { get; set; }
        string ConnectionString { get; set; }
        string DataSource { get; set; }
        string DatabaseName { get; set; }
    }
}
