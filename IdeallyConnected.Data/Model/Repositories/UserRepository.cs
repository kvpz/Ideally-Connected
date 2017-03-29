using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdeallyConnected.Data;

namespace IdeallyConnected.Data.Models.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository() { }
        public UserRepository(ICDbContext context) : base(context)
        {
        }

        public User GetByUserName(string name)
        {
            //User result = DbSet.Where(n => n.UserName.Contains(name)).FirstOrDefault();
            //User result = DbSet.Where(u => u.UserName == name).FirstOrDefault();
            User result = DbSet.First(u => u.UserName == name);
            return result;
        }

        public IQueryable<User> GetByFirstAndLastName(string firstName, string lastName)
        {
            return DbSet.Where(u => u.FirstName == firstName && u.LastName == lastName);
        }

        public List<User> GetUserProfile()
        {
            return DbSet.OfType<User>().ToList();
            //return DbSet.ToList();
        }

        public override void Update(User entity)
        {
            base.Update(entity);
            SaveChanges();
        }
    }
}