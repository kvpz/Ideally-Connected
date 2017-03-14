using IdeallyConnected.Experiments.Models;
using IdeallyConnected.Experiments.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace IdeallyConnected.Experiments
{
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

        public static void printProgrammingObject(Programming obj)
        {
            foreach(var language in obj.ProgrammingLanguages)
            {
                Console.Write(language + " ");
            }
            Console.WriteLine($"{(ExpertiseEnum)obj.Expertise}   --   {obj.Expertise}");
        }

        public static void Main(string[] args)
        {
            var db = new AppICDbContext();
            if(db.Database.Exists())
            {
                Console.WriteLine("Database exists");
                //db.Database.Delete(); 
            }

            Random randomInteger = new Random();
            Array expertiseEnumValues = Enum.GetValues(typeof(ExpertiseEnum));
            var users = new List<User> {
                new User { Id = "johninit", locationsIP = 1111 },
                new User { Id = "johninit2", locationsIP = 1234 },
                new User { Id = "johninit3", locationsIP = 124235 },
                new User { Id = "johninit4", locationsIP = 213421 } 
            };

            foreach(User user in users)
            {
                string progLangs = Utility.Utility.GenerateProgrammingLanguages(randomInteger.Next(0,10));
                Programming skill = new Programming((ExpertiseEnum)expertiseEnumValues.GetValue(randomInteger.Next(expertiseEnumValues.Length)), 
                                "I love programming ", progLangs);
                skill.Description += progLangs; 
                
                Console.WriteLine("Intersecting");
                IEqualityComparer<ProgrammingLanguage> pcomparer = EqualityComparerFactory<ProgrammingLanguage>
                                                                    .Create((pa, pb) => pa.language == pb.language, (pa) => pa.GetHashCode());
                IEnumerable<ProgrammingLanguage> intersectedDbSkills = skill.ProgrammingLanguages.Intersect(db.ProgrammingLanguages.ToList(), pcomparer);
                Console.WriteLine($"Printing intersection of size: { db.ProgrammingLanguages.Count() }");
                Console.WriteLine($"plangs in skills before: {skill.ProgrammingLanguages.Count}");
                foreach(ProgrammingLanguage p in intersectedDbSkills)
                {
                    Console.WriteLine(p);
                    Console.WriteLine($"+1 for {p.language}");
                    skill.ProgrammingLanguages.Remove(p);
                }
                Console.WriteLine($"plangs in skills AFTER: {skill.ProgrammingLanguages.Count}");

                user.Skill = new List<Skill> { skill };

                Console.WriteLine("Local skill:");
                skill.printSkill();
                
                User dbUser = db.Users.Find(user.Id);
                if(dbUser == null)
                {
                    db.Users.Add(user); 
                }
                else
                {
                    dbUser.Skill = user.Skill;
                    //db.Users.Add(user);
                    //db.Skills.Add(skill);
                }
                //db.Users.Add(user);
                //db.Programmings.Add(skill);
            }
            
            Console.WriteLine("PRINTING SKILLS FROM DATABASE");
            foreach(User user in users)
            {
                //var dbSkill = db.Users.Find(user.Id);
                //dbSkill.printUser();
                //dbSkill.ToList().ForEach(s => s.print());
            }

            //db.Users.AddRange(users);
            try 
            {
                int savedChanges = db.SaveChanges();
                Console.WriteLine($"Saved changes: { savedChanges }");    
            }
            catch(Exception e)
            {
                Console.WriteLine("Caught savechanges() error: \n");
                Console.WriteLine(e);
            }


        }
    }
}

/*
    Notes
    Derived classes MUST override abstract methods.
    Abstract methods have no definition.
    Virtual methods have a definition.
    It is not mandatory to override virtual methods in the derived class.
*/