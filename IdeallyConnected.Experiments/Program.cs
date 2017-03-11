using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments
{
    public class Program
    {
        private static List<User> GenerateUsers()
        {
            return new List<User> {
                new User()
                };
        }

        public static class EqualityComparerFactory<T>
        {
            private class SkillComparer : IEqualityComparer<T>
            {
                private readonly Func<T,T,bool>    _equals;
                private readonly Func<T,int>       _getHashCode;

                public SkillComparer(Func<T,T,bool> equalityFunc, Func<T,int> hashCodeFunc)
                {
                    _equals = equalityFunc;
                    _getHashCode = hashCodeFunc;
                }

                public bool Equals(T a, T b)
                {
                    return _equals(a, b);    
                }

                public int GetHashCode(T obj)
                {
                    return _getHashCode(obj);
                }
            }

            public static IEqualityComparer<T> Create(Func<T,T,bool> equalityFunc, Func<T,int> hashCodeFunc)
            {
                if (hashCodeFunc == null)
                    throw new ArgumentNullException("getHashCodeFunc");
                if (equalityFunc == null)
                    throw new ArgumentNullException("equalsFunc");
                return new SkillComparer(equalityFunc, hashCodeFunc);
            }
        }

        public static void PerformDatabaseOperations()
        {
            // This is unnecessary because Dispose is called automatically by DbContext.
            /*
            using(var db = new AppICDbContext())
            {
                var skill = new Skill {
                    Programming = true,
                    ProgrammingLanguages = "C++, C#, Javascript, C, Python",
                    Software = "Visual Studio, Emacs, GIMP",
                    Sports = "baseball, basketball"
                };
                var skillComparer = EqualityComparerFactory<Skill>.Create((a, b) => a.ProgrammingLanguages == b.ProgrammingLanguages, a => a.ID.GetHashCode());
                var result = db.Skills.ToList().Contains(skill, skillComparer);
                if(result == false)
                    db.Skills.Add(skill);
                db.SaveChanges(); 
            }
            */
        }

        public static void Main(string[] args)
        {
            /*
            //List<User> users = GenerateUsers();
            PerformDatabaseOperations();
            Console.WriteLine("Skill saved");
            Console.ReadLine();
            */
            
            var db = new AppICDbContext();
            Skill s = SkillEnum.Programming;
            // Implicitly gets the Id of s to determine the Enum value
            SkillEnum sDescription = s;
            s.Description = "C++ C C#";
            Console.WriteLine("Skill Description: {0} {1}    Getting Description: {2} {3}", s.Description, s.ID, sDescription, SkillEnum.Programming);
            User user = new User { 
                username = "johnsmith3",
                Skill = s
            };
            
            //Console.WriteLine("User Skill description #{0}", user.Skill.GetEnumDescription());
            //db.Users.Add(user);
           
            //db.Skills.Add(user.Skill.D
            //db.SaveChanges();
        }
    }
}
