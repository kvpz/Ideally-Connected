using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeallyConnected.Data.Models;
using IdeallyConnected.Data.Models.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using MUT = Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

namespace IdeallyConnected.Test.Database
{
    using System.Data.Entity;
    using System.Data.Entity.Validation;

    [TestClass]
    public class RepositoryTest
    {
        private static readonly string connectionString = "ICTestConnection";
        private static Repository<User> repo;
        //private User user = new User() { UserName = "JSmith", FirstName = "John", LastName = "Smith", Biography = "John's bio is interesting", Created = DateTime.Now };
        private static readonly List<User> testUsers = new List<User>()
        {
            new User() { Id = "123", UserName = "JSmith", FirstName = "John", LastName = "Smith", Created = DateTime.Now },
            new User() { UserName = "JSmith2", FirstName = "John", LastName = "Smith", Created = DateTime.Now },
            new User() { UserName = "JSmith3", FirstName = "NotJohn", LastName = "Smith", Created = DateTime.Now },
            new User() { UserName = "JSmith4", FirstName = "John", LastName = "NotSmith", Created = DateTime.Now },
            new User() { UserName = "BobbyJ", FirstName = "Bob", LastName = "Jones", Created = DateTime.Now }
        };

        //[TestInitialize]
        [ClassInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            ICDbContext context = new ICDbContext(connectionString);
            context.Set<User>().AddOrUpdate(t => new { t.UserName }, testUsers.ToArray());
            context.SaveChanges();
            repo = new Repository<User>(context);
        }

        //[TestCleanup]
        [ClassCleanup]
        public static void TestCleanup()
        {
            repo.Dispose();
            //Database.Delete(connectionString);
        }

        [TestMethod]
        public void Should_Add_New_Entry()
        {
            User newUser = new User() { UserName = "NewUser", FirstName = "NewUserFirstName", LastName = "NewUserLastName", Biography = "NewUser's bio is interesting", Created = DateTime.Now };
            // Action: Add user to context, else return existing entry.

            var result = repo.Add(newUser);
            repo.SaveChanges();
            MUT.Assert.AreEqual(newUser, result);
            //MUT.Assert.AreEqual(contextUser.Id, user.Id, "ContextUser and User are not equal. Addition failed.");
        }

        [TestMethod]
        public void Should_Load_Existing_Data()
        {
            var existingData = repo.Where(d => d.UserName == testUsers[0].UserName).FirstOrDefault();
            MUT.Assert.AreEqual(testUsers[0].UserName, existingData.UserName, "Could not retrieve existing database entity.");
        }
        
        [TestMethod]
        public void Should_Update_Context()
        {
            var updatedEntry = new User() { UserName = "JSmith", FirstName = "John", LastName = "Smith", Biography = "John updated his bio.", Created = DateTime.Now };

            var existingEntry = repo.Where(u => u.UserName == updatedEntry.UserName).FirstOrDefault();

            // Action: Modifying the record.
            existingEntry.UserName = "JSmithNewUsername";
            existingEntry.Biography = updatedEntry.Biography;
            repo.SaveChanges();

            // Check: Retrieving to check if change was persisted.
            User persistedEntry = repo.Get(existingEntry.Id);
            MUT.Assert.AreEqual(existingEntry.Id, persistedEntry.Id, "Property change did not persist.");
        }

        [TestMethod]
        public void Should_Delete_Entry_From_Context()
        {
            var existingEntry = repo.Where(u => u.UserName == "JSmith4").FirstOrDefault();
            // Deleting the existing entry
            if (existingEntry != null)
                repo.Delete(existingEntry);
            repo.SaveChanges();

            var shouldBeNull = repo.Get(existingEntry.Id);
            Assert.AreEqual(null, shouldBeNull);
        }
        

        [TestMethod]
        //[ExpectedException(typeof(DbUpdateException),"Error because trying to persist existing data in a primary key column.")]
        [ExpectedException(typeof(DbEntityValidationException), "Prevented adding existing data in unique data attribute.")]
        public void Should_Prevent_Adding_Existing_UserName()
        {
            var newEntry = new User() { UserName = "JSmith", FirstName = "SomeFirstName", LastName = "IrrelevantLastName", Created = DateTime.Now };
            repo.Add(newEntry);

            repo.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Trying to add null values to non-nullable column(s)")]
        public void Should_Throw_Error_If_Inserting_Null_In_Nonnullable_Properties()
        {
            var newEntry = new User() { UserName = "NewInvalidUser", Created = DateTime.Now };
            repo.Add(newEntry);

            repo.SaveChanges();
        }

        
    }
}
