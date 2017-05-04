using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdeallyConnected.Test.Database
{
    using Data.Models.Repositories;
    using IdeallyConnected.Data.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;

    // Class containing hard-coded test data.
    public static class UsersTestData
    {
        public static readonly List<User> threeUsers = new List<User>()
        {
            new User()
            {
                Id = "1",
                UserName = "user1",
                FirstName = "UserOne",
                LastName = "UserOne",
                Created = DateTime.Now
            },
            new User()
            {
                Id = "2",
                UserName = "user2",
                FirstName = "UserTwo",
                LastName = "UserTwo",
                Created = DateTime.Now
            },
            new User()
            {
                Id = "3",
                UserName = "user3",
                FirstName = "UserThree",
                LastName = "UserThree",
                Created = DateTime.Now
            }
        };
    }

    /*
        Testing the UserRepository. 
    */
    public class UserRepositoryTest
    {
        private readonly string connectionString = "Data Source=(localdb)\\ProjectsV13; Database=IdeallyConnectedTestDb; Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private UserRepository userRepo;
        private ICDbContext _context;

        // Initializer for each and every test 
        public UserRepositoryTest()
        {
            _context = new ICDbContext(connectionString);
            userRepo = new UserRepository(_context);
        }

        // Destructor runs after each test
        public void Dispose()
        {
            _context.Dispose();
        }

        private readonly List<User> testUsers = new List<User>()
        {
            new User() { Id = "123", UserName = "JSmith", FirstName = "John", LastName = "Smith", Created = DateTime.Now },
            new User() { UserName = "JSmith2", FirstName = "John", LastName = "Smith", Created = DateTime.Now },
            new User() { UserName = "JSmith3", FirstName = "NotJohn", LastName = "Smith", Created = DateTime.Now },
            new User() { UserName = "JSmith4", FirstName = "John", LastName = "NotSmith", Created = DateTime.Now },
            new User() { UserName = "BobbyJ", FirstName = "Bob", LastName = "Jones", Created = DateTime.Now }
        };

        public void Should_Add_New_User()
        {
            User newUser = new User() { UserName = "NewUser", FirstName = "NewUserFirstName", LastName = "NewUserLastName", Created = DateTime.Now };

            User actual = userRepo.Add(newUser);
            userRepo.SaveChanges();

            Assert.Equal(newUser, actual); //, "User was not added to context correctly.");

        }

        public void InsertUserOnlyWithRepositorySuccessfully()
        {
            userRepo = new UserRepository(new ICDbContext(connectionString));
            userRepo.Add(new User()
            {
                UserName = "RepoTesterSuccess",
                FirstName = "RepoTesterSuccess",
                LastName = "RepoTesterSuccess",
                Email = "repotestersuccess@testingsuccess.com",
                Created = DateTime.Now
            });
            userRepo.SaveChanges();
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

        public void Return_User_From_GetUserByUserName()
        {
            User expected = testUsers[0];
            var result = userRepo.GetByUserName(expected.UserName);

            Assert.Equal(expected, result);
        }

        [Theory]
        //[InlineData("CleanFirstName", "CleanLastName")]
        [InlineData("D1rt33F1rstName", "D1rt33La5tName")]
        public void Should_Only_Allow_Alpha_Characters_For_Name(string firstName, string lastName)
        {
            User testUser = new User() { UserName = "IrrelevantUserName", FirstName = firstName, LastName = lastName };
            Xunit.Assert.Matches(@"^[a-zA-Z]+$", firstName);
        }
        
        [Fact]
        public void Should_Insert_With_UserRepository()
        {
            userRepo = new UserRepository(new ICDbContext(connectionString));
            userRepo.Add(new User()
            {
                UserName = "RepoTesterSuccess",
                FirstName = "RepoTesterSuccess",
                LastName = "RepoTesterSuccess",
                Email = "repotestersuccess@testingsuccess.com",
                Created = DateTime.Now
            });
            userRepo.SaveChanges();
        }

        [Fact] 
        public void Should_Delete_With_UserRepository()
        {
            // Initialize context
            userRepo = new UserRepository(new ICDbContext(connectionString));
            User user = new User()
            {
                UserName = "RepoTesterSuccess",
                FirstName = "RepoTesterSuccess",
                LastName = "RepoTesterSuccess",
                Email = "repotestersuccess@testingsuccess.com",
                Created = DateTime.Now
            };
            

            user = userRepo.GetByUserName(user.UserName);
            userRepo.Delete(user.Id);
            userRepo.SaveChanges();
        }
    }
}
