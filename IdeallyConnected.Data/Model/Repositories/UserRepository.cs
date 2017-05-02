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

        /// <summary>
        /// Get the users 'user' has collaborated with. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Collaborators> GetCollaborators(User user)
        {
            List<User> collabs = new List<User>();
            List<Collaborators> collabSet = dbContext.Set<Collaborators>()
                .Where(cf => cf.UserA == user.Id).ToList();

            return collabSet;
        }
    }
}