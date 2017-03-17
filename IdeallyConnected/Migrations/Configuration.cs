namespace IdeallyConnected.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;

    public static class DbExtensions
    {
        public static T AddIfNoneExists<T>(this DbSet<T> dbset,T entity, Expression<Func<T,bool>> predicate = null) where T : class
        {
            bool exists = predicate != null ? dbset.Any(predicate) : dbset.Any();
            return !exists ? dbset.Add(entity) : null;
        }

        public static void AddOrUpdateIfNoneExists<T>(this DbSet<T> dbset, T[] entity, Expression<Func<T,object>> identifierExpression = null) where T : class
        {
            dbset.AddOrUpdate(identifierExpression, entity);
        }
    }

    internal sealed class Configuration : DbMigrationsConfiguration<IdeallyConnected.Models.ApplicationDbContext>
    {
        IEqualityComparer<Skill> programmingSkillComparer = EqualityComparerGeneric<Skill>.Create(
            (pskill_a, pskill_b) => pskill_a.Type == pskill_b.Type && pskill_a.UserId == pskill_b.UserId, 
            pskill               => pskill.GetHashCode());
        public static class EqualityComparerGeneric<T> 
        {
            private class Comparer : IEqualityComparer<T>
            {
                private readonly Func<T,T,bool> _equality;
                private readonly Func<T,int>   _hasher;

                public Comparer(Func<T,T,bool> equalityFunc, Func<T,int> hashCodeFunc)
                {
                    _equality = equalityFunc;
                    _hasher = hashCodeFunc;
                }

                public bool Equals(T x,T y)
                {
                    return _equality(x, y);
                }

                public int GetHashCode(T obj)
                {
                    return _hasher(obj);
                }
            }

            public static IEqualityComparer<T> Create(Func<T,T,bool> equalityFunc,Func<T,int> hashCodeFunc)
            {
                if(hashCodeFunc == null)
                    throw new ArgumentNullException("getHashCodeFunc");
                if(equalityFunc == null)
                    throw new ArgumentNullException("equalsFunc");
                return new Comparer(equalityFunc,hashCodeFunc);
            }
        }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdeallyConnected.Models.ApplicationDbContext context)
        {

            var users = new List<ApplicationUser>() {
                new ApplicationUser() {
                    UserName = "Bob11",
                    FirstName = "Bob",
                    LastName = "One"
                },
                new ApplicationUser() {
                    UserName = "Bob22",
                    FirstName = "Bob2",
                    LastName =  "Two"
                }, 
                new ApplicationUser() {
                    UserName = "Bob33",
                    FirstName = "Bob3",
                    LastName = "Three",
                }
            };
            
            var dbUsers = context.Users.ToList();
            if(dbUsers.Count() == 0)
                dbUsers = users;
            
            /*
                If the UserId is not defined like below, a duplicate key value error will occur.
            */
            var programmingSkills = new List<Programming>() {
                new Programming() {
                    SkillManager = dbUsers?[0],
                    UserId = dbUsers[0]?.Id,
                    Expertise = (byte)ExpertiseEnum.Expert
                },
                new Programming() {
                    SkillManager = dbUsers?[1],
                    UserId = dbUsers[1]?.Id,
                    Expertise = (byte)ExpertiseEnum.Intermediate
                },
                new Programming() {
                    SkillManager = dbUsers?[2],
                    UserId = dbUsers[2]?.Id, 
                    Expertise = (byte)ExpertiseEnum.None
                }
            };

            var designSkills = new List<Design>() {
                new Design() {
                    SkillManager = dbUsers?[0]
                },
                new Design() {
                    SkillManager = dbUsers?[1]
                },
                new Design() {
                    SkillManager = dbUsers?[2]
                }
            };
           
            context.Programmings.AddOrUpdateIfNoneExists(programmingSkills.ToArray(), s => new { s.Type, s.UserId });
            context.Designs.AddOrUpdateIfNoneExists(designSkills.ToArray(), s => new { s.Type, s.UserId });
        }
    }
}
