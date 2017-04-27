namespace IdeallyConnected.Migrations
{
    using IdeallyConnected.Data.Models;
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

    internal sealed class Configuration : DbMigrationsConfiguration<IdeallyConnected.Data.Models.ICDbContext>
    {
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

        protected override void Seed(IdeallyConnected.Data.Models.ICDbContext context)
        {

            var users = new List<User>() {
                new User() {
                    UserName = "Bob11",
                    FirstName = "Bob",
                    LastName = "One"
                },
                new User() {
                    UserName = "Bob22",
                    FirstName = "Bob2",
                    LastName =  "Two"
                }, 
                new User() {
                    UserName = "Bob33",
                    FirstName = "Bob3",
                    LastName = "Three",
                }
            };

            var dbUsers = context.Users.ToList();

            var programmingSkills = new List<Programming>() {
                new Programming() { Type = "Programming", ProgrammingLanguages = "C, C++, C#", Software = "Emacs, VisualStudio"},
                new Programming() { Type = "Programming", ProgrammingLanguages = "C, Python, Javascript", Software = "VisualStudio, Jetbrains" },
                new Programming() { Type = "Programming", ProgrammingLanguages = "C#, Java, Go, Ruby", Software = "RubyMine, VisualStudio, Netbeans" }
            };
            
            // This shouldn't be allowed. Only add Skills through Users context.
            //context.Skills.AddOrUpdate(programmingSkills.ToArray());
            //context.SaveChanges();
            int i = 0;
            foreach(var u in users)
            {
                u.Skills.Add(programmingSkills[i]);
                ++i;
            }
            context.Users.AddOrUpdate(users.ToArray());
            context.SaveChanges();
            
        }
    }
}
