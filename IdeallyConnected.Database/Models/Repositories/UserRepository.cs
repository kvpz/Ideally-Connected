using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models.Repositories
{
    public class UserRepository : Repository<ApplicationUser>
    {
        public List<ApplicationUser> GetByUserName(String name)
        {
            return DbSet.Where(n => n.UserName.Contains(name)).ToList();    
        }

        public override void Update(ApplicationUser entity)
        {
            base.Update(entity);
            SaveChanges();
        }

        public List<ApplicationUser> GetUserProfile()
        {
            return DbSet.OfType<ApplicationUser>().ToList();
        }
    }
}