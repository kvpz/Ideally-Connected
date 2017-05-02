using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdeallyConnected.Test.Database
{
    /*
        Test the UserRepository for accessing the database.
    */
    public class UserRepositoryDatabase : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture Db { get; set; }

        public UserRepositoryDatabase(DatabaseFixture Db)
        {
            this.Db = Db;
        }


    }
}
