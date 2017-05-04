using IdeallyConnected.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdeallyConnected.Test.Database
{
    public class CollaboratorsTest
    {
        private const string connectionString = 
            "Data Source = (localdb)\\ProjectsV13; Database = IdeallyConnectedTestDb; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        [Fact]
        public void Should_add_collaborators()
        {
            ICDbContext context = new ICDbContext(connectionString);
            context.Collaborators = context.Set<Collaborators>();
            
            context.Collaborators.Add(new Collaborators() { UserA = "1", UserB = "2", Initiated = true, Following = true, InitialCollaboration = DateTime.Now });
            context.SaveChanges();
            context.Collaborators.Find("1", "2");
        }
    }
}
