using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Test.Database
{
    public class DatabaseFixture : IDisposable
    {
        public SqlConnection Db { get; private set; }

        // Initialize a perfect, complete database for testing.
        public DatabaseFixture()
        {
            string connectionString = "Data Source=(localdb)\\ProjectsV13; Database=IdeallyConnectedTestDb; Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Db = new SqlConnection(connectionString);
        }

        // Clean up database and delete
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
