using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IdeallyConnected.Data.Models
{
    /*
    public class ICDataContextInitializer : DropCreateDatabaseAlways<ICDbContext>
    {
        public ICDataContextInitializer()
        {
            
        }

        protected override void Seed(ICDbContext context)
        {
            List<User> users = new List<User>();
            users.Add(new User() { UserName = "BobOne", FirstName = "Bob", LastName = "One", Created = DateTime.Now });
            users.Add(new User() { UserName = "BobTwo", FirstName = "Bob", LastName = "Two", Created = DateTime.Now });
            users.Add(new User() { UserName = "BobThree", FirstName = "Bob", LastName = "Three", Created = DateTime.Now });
            users.Add(new User() { UserName = "BobFour", FirstName = "Bob", LastName = "Four", Created = DateTime.Now });
            users.Add(new User() { UserName = "BobFive", FirstName = "Bob", LastName = "Five", Created = DateTime.Now });
            users.Add(new User() { UserName = "JohnSmith", FirstName = "John", LastName = "Smith", Created = DateTime.Now });
            users.Add(new User() { UserName = "NewtFitzerz", FirstName = "Newton", LastName = "Fizgerald", Created = DateTime.Now });
            users.Add(new User() { UserName = "Billy1", FirstName = "Billy", LastName = "Bob", Created = DateTime.Now });
            users.Add(new User() { UserName = "Johnny32", FirstName = "Johnny", LastName = "von Neummann", Created = DateTime.Now });
            users.ForEach(u => context.Users.Add(u));
        }
    }
    */
}