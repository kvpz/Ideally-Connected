using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdeallyConnected.Data;

namespace IdeallyConnected.Data.Models.Repositories
{
    public class UserRepository : Repository<User>
    {
        public List<User> GetByUserName(String name)
        {
            return DbSet.Where(n => n.UserName.Contains(name)).ToList();     
        }

        public override void Update(User entity)
        {
            base.Update(entity);
            SaveChanges();
        }

        public List<User> GetUserProfile()
        {
            return DbSet.OfType<User>().ToList();
        }
    }
}