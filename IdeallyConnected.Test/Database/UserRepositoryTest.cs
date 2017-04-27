using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MUT = Microsoft.VisualStudio.TestTools.UnitTesting;
namespace IdeallyConnected.Test.Database
{
    using Data.Models.Repositories;
    using IdeallyConnected.Data.Models;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    //[TestClass]
    public class UserRepositoryTest
    {
        private readonly string connectionString = "ICTestConnection";
        private UserRepository userRepo;
        private readonly List<User> testUsers = new List<User>()
        {
            new User() { Id = "123", UserName = "JSmith", FirstName = "John", LastName = "Smith", Created = DateTime.Now },
            new User() { UserName = "JSmith2", FirstName = "John", LastName = "Smith", Created = DateTime.Now },
            new User() { UserName = "JSmith3", FirstName = "NotJohn", LastName = "Smith", Created = DateTime.Now },
            new User() { UserName = "JSmith4", FirstName = "John", LastName = "NotSmith", Created = DateTime.Now },
            new User() { UserName = "BobbyJ", FirstName = "Bob", LastName = "Jones", Created = DateTime.Now }
        };

        [TestInitialize]
        public void TestInitialize()
        {
            ICDbContext context = new ICDbContext(connectionString);
            context.Set<User>().AddOrUpdate(testUsers.ToArray());
            context.SaveChanges();
            userRepo = new UserRepository(context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            userRepo.Dispose();
            Database.Delete(connectionString);
        }

        [TestMethod]
        public void Should_Add_New_User()
        {
            User newUser = new User() { UserName = "NewUser", FirstName = "NewUserFirstName", LastName = "NewUserLastName", Created = DateTime.Now };

            User actual = userRepo.Add(newUser);
            userRepo.SaveChanges();

            MUT.Assert.AreEqual(newUser, actual, "User was not added to context correctly.");

        }

        [Theory]
        [InlineData("John", "Smith")]
        public void Should_Return_Users_When_Searching_By_First_And_Last_Name(string firstName, string lastName)
        {
            ICDbContext context = new ICDbContext(connectionString);
            context.Set<User>().AddOrUpdate(testUsers.ToArray());
            context.SaveChanges();
            userRepo = new UserRepository(context);
            List<User> result = userRepo.GetByFirstAndLastName(firstName, lastName).ToList();
            foreach(User user in result)
            {
                Xunit.Assert.True(user.FirstName == firstName && user.LastName == lastName, "Did not find the correct users by first and last name.");               
            }
            userRepo.Dispose();
            Database.Delete(connectionString);
        }

        [TestMethod]
        public void Return_User_From_GetUserByUserName()
        {
            User expected = testUsers[0];
            var result = userRepo.GetByUserName(expected.UserName);

            MUT.Assert.AreEqual(expected, result);
        }

        [Theory]
        //[InlineData("CleanFirstName", "CleanLastName")]
        [InlineData("D1rt33F1rstName", "D1rt33La5tName")]
        public void Should_Only_Allow_Alpha_Characters_For_Name(string firstName, string lastName)
        {
            User testUser = new User() { UserName = "IrrelevantUserName", FirstName = firstName, LastName = lastName };
            Xunit.Assert.Matches(@"^[a-zA-Z]+$", firstName);//testUser.FirstName);
        }
    }
}
