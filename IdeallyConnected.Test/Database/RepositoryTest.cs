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

namespace IdeallyConnected.Test.Database
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void Should_AddToContextIfEntryDoesNotExist()
        {
            Repository<User> repo = new Repository<User>();
            User user = new User() { UserName = "JSmith", FirstName = "John", LastName = "Smith", Biography = "John's bio is interesting", Created = DateTime.Now };

            // Action: Add user to context, else return existing entry.
            User dbExistingUser = repo.GetAll().Where(u => u.UserName == user.UserName).FirstOrDefault();
            user = dbExistingUser ?? repo.Add(user);
            repo.SaveChanges();
            User contextUser = dbExistingUser ?? repo.Get(user.Id);

            MUT.Assert.AreEqual(contextUser.Id, user.Id, "ContextUser and User are not equal. Addition failed.");
        }

        [TestMethod]
        public void Should_LoadToContextExistingData()
        {
            // Assuming this user exists in the database
            Repository<User> repo = new Repository<User>();
            User user = new User() { UserName = "JSmith", FirstName = "John", LastName = "Smith", Biography = "John's bio is interesting", Created = DateTime.Now };

            // Action the entry from the database, or add if it does not exist.
            User dbExistingUser = repo.GetAll().Where(u => u.UserName == user.UserName).FirstOrDefault();
            if (dbExistingUser == null)
                dbExistingUser = repo.Add(user);

            MUT.Assert.AreEqual(dbExistingUser.UserName, user.UserName, "Could not retrieve existing database entity.");
        }

        [TestMethod]
        public void Should_UpdateContext()
        {
            Repository<User> repo = new Repository<User>();
            // If user exists load from context, else add to context.
            User user = new User() { UserName = "JSmith", FirstName = "John", LastName = "Smith", Biography = "John's bio is interesting", Created = DateTime.Now };
            User dbExistingUser = repo.GetAll().Where(u => u.UserName == user.UserName).ToList()?.First();
            if (dbExistingUser == null)
                repo.Add(user);
            else
                user = dbExistingUser;
            repo.SaveChanges();

            // Action: Changing an entry's property
            user.UserName = "JSmithNewUsername";
            repo.SaveChanges();

            // Check: Retrieving to check if change was persisted.
            User contextUser = repo.Get(dbExistingUser.Id);
            MUT.Assert.AreEqual(user.Id, contextUser.Id, "Property change did not persist.");
        }

        [TestMethod]
        public void Should_DeleteEntryFromContext()
        {
            // Given this user exists in the database
            Repository<User> repo = new Repository<User>();
            User user = new User() { UserName = "JSmith", FirstName = "John", LastName = "Smith", Biography = "John's bio is interesting", Created = DateTime.Now };
            user = repo.Where(u => u.UserName == user.UserName).FirstOrDefault();
            // Deleting the existing entry
            if(user != null)
                repo.Delete(user);
            repo.SaveChanges();

            Assert.Equals(user, null);
        }
    }
}
