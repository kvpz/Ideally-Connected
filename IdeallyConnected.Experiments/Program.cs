using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments
{
    public class Utility
    {
        private static List<string> progLangs = new List<string> { "C","C++", "C#", "Objective-C", "Ruby", "Javascript", "Python", "Bash", "MIPS", "LISP", "R", "F#", "PHP" };
        delegate string randomString(int i);
        /// <summary>
        /// Generate a string with random, space-separated programming languages. 
        /// </summary>
        /// <param name="totalRequested"> The total amount of programming languages to be returned. </param>
        /// <param name="randomly"> If true, totalRequest is used as the seed value for System.Random </param>
        /// <returns></returns>
        public static string GenerateProgrammingLanguages(int totalRequested, bool randomly = false)
        {
            Random random;
            if(randomly)
                random = new Random();
            else
                random = new Random(totalRequested);
            // This may produce duplicate values, but it's okay for testing.
            var randomIndexes = Enumerable.Range(0, progLangs.Count - 1).OrderBy(x => random.Next()).Take(totalRequested - 1).ToList();
            randomString f = (index) => progLangs[index];
            var randEnum = randomIndexes.GetEnumerator();

            string testresult = randomIndexes.Aggregate<int, string>(f(randEnum.Current), (@string, element) => @string + ' ' + f(element));
            return testresult;
        }
    }

    public static class EqualityComparerFactory<T>
    {
        private class DerivedComparer:IEqualityComparer<T>
        {
            private readonly Func<T,T,bool> _equals;
            private readonly Func<T,int> _getHashCode;

            public DerivedComparer(Func<T,T,bool> equalityFunc,Func<T,int> hashCodeFunc)
            {
                _equals = equalityFunc;
                _getHashCode = hashCodeFunc;
            }

            public bool Equals(T a,T b)
            {
                return _equals(a,b);
            }

            public int GetHashCode(T obj)
            {
                return _getHashCode(obj);
            }
        }

        public static IEqualityComparer<T> Create(Func<T,T,bool> equalityFunc,Func<T,int> hashCodeFunc)
        {
            if(hashCodeFunc == null)
                throw new ArgumentNullException("getHashCodeFunc");
            if(equalityFunc == null)
                throw new ArgumentNullException("equalsFunc");
            return new DerivedComparer(equalityFunc,hashCodeFunc);
        }
    }

    public class Program
    {
        
        public static List<User> GenerateUsers()
        {
            return new List<User> {
                new User()
            };
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
            var db = new AppICDbContext();
            
        }
    }
}
