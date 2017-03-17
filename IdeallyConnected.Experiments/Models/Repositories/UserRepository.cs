using IdeallyConnected.Experiments.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Models.Repositories
{
    public class UserRepository : AppICRepository<User>
    {
        // Used for assigning dbContext object to and initial UserRepository object.
        //public static implicit operator UserRepository(AppICDbContext context) => new UserRepository();

        public UserRepository() : base()
        {
            
        }

        public User Get(string username)
        {
            return dbset.Find(username);
        }
        
        public User Get(User user)
        {
            return dbset.Find(user.Username);
        }
        
        public bool Exists(User user)
        {   
            //Get(user.Id);
            IEqualityComparer<User> userComparer = EqualityComparerFactory<User>.Create((user_a, user_b) => user_a.Username == user_b.Username, (_user) => _user.GetHashCode());
            return dbset.ToList().Contains(user, userComparer);
        }        
        
        
        public void AddOrUpdate(User entity)
        {
            //Expression<Func<User, ProgrammingLanguage>> exp = u => 
            
            dbset.AddOrUpdate(entity);
        }

        public override void Add(User entity)
        {
            //var skills = entity.Skill;
            //dbset.Add(entity);
        }
    }
}
