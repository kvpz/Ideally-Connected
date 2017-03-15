using IdeallyConnected.Experiments.Models;
using IdeallyConnected.Experiments.Utility;
using static IdeallyConnected.Experiments.Utility.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using IdeallyConnected.Experiments.Models.Repositories;
using System.Data.Entity.Migrations;

namespace IdeallyConnected.Experiments
{
    public class Program
    {
        public static IEqualityComparer<User> userIdComparer = EqualityComparerFactory<User>.Create((ua, ub) => ua.Id == ub.Id, u => u.GetHashCode());
        public static void createProgrammingLanguages(AppICDbContext db)
        {
            List<ProgrammingLanguage> plangs = new List<ProgrammingLanguage> { "C","C++", "C#", "Objective-C", "Ruby", "Javascript", "Python", "Bash", "MIPS", "LISP", "R", "F#", "PHP" };
            plangs.ForEach(plang => db.ProgrammingLanguages.Add(plang));
            db.SaveChanges();
        }

        public static ProgrammingLanguage GetProgrammingLanguage(string language, AppICDbContext db)
        {
            return db.ProgrammingLanguages.SingleOrDefault(plang => plang.language == language);
        }

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

        public static void printAllUsers(IEnumerable<User> users)
        {
            users.ToList().ForEach(u => u.printUser());
        }   

        public static void AddUser(User user, AppICDbContext db)
        {
            Console.WriteLine($"Adding new user: {user.Id}");
        }

        public static void AddUserSkillIfDoesNotExist(User dbUser, Skill userSkill)
        {
            // Update user if programming skill is missing
            IEqualityComparer<Skill> compareSkills = EqualityComparerFactory<Skill>.Create((s1, s2) => s1.Type == s2.Type, s => s.GetHashCode());
            if(!dbUser.Skill.ToList().Contains(userSkill, compareSkills))
            {
                Console.WriteLine($"dbUser does not contain skill: { userSkill }");
                dbUser.Skill.Add(userSkill);
            }
        }

        /*
            This modifies a user including tables referencing the user.
        */
        public static void ModifyExistingUser(User user, AppICDbContext db)
        { 
            var userSkills = user.Skill.ToList();
            var userProgSkill = userSkills.Find(s => s.Type == 0);
            var dbUser = db.Users.ToList().Find(u => u.Id == user.Id);
            // Update any changes made to User properties
            db.Users.AddOrUpdate(user);
            foreach(Skill skill in user.Skill)
            {
                AddUserSkillIfDoesNotExist(dbUser, skill);
            }
            db.SaveChanges();
        }

        // ProgrammingLanguages for Programming skill needs references deleted first
        public static void DeleteSkill()
        {
            
        }   

        public static void Main(string[] args)
        {
            var db = new AppICDbContext();
            //createProgrammingLanguages(db);

            if(db.Database.Exists())
            {
                Console.WriteLine("Database exists");
                //db.Database.Delete(); 
            }

            Random randomInteger = new Random();
            Array expertiseEnumValues = Enum.GetValues(typeof(ExpertiseEnum));
            IEnumerable<User> users = new List<User> {
                new User { Id = "johninit", locationsIP = 1111 },
                new User { Id = "johninit2", locationsIP = 12349},
                new User { Id = "johninit3", locationsIP = 124235 },
                new User { Id = "johninit4", locationsIP = 213421 } 
            };

            int userCounter = 0;
            foreach(User user in users)
            {
                string progLangs = GenerateProgrammingLanguages(randomInteger.Next(0,10));
                // Verify that the current input does not repeat languages
                ValidateProgLangUnique(ref progLangs);
                Programming programmingSkill = new Programming((ExpertiseEnum)expertiseEnumValues.GetValue(randomInteger.Next(expertiseEnumValues.Length)), 
                                                    "I love programming ", progLangs);
                programmingSkill.Description += progLangs; 
                Design designSkill = new Design { DesignSubSkill = "Subskill one", Description = "Design description for " + user.Id, Type = (int)SkillEnum.Design, Expertise = (byte)ExpertiseEnum.Novice };
                Writing writingSkill = new Writing { WritingSubSkill = "Subskill " + userCounter, Description = "Writing description for " + user.Id, Type = (int)SkillEnum.Writing, Expertise = (byte)ExpertiseEnum.Intermediate };
                user.Skill = new List<Skill> { programmingSkill, designSkill, writingSkill };
                if(db.Users.ToList().Contains(user, userIdComparer))
                {
                    user.Skill = new List<Skill> { programmingSkill, designSkill, writingSkill };
                    ModifyExistingUser(user, db);
                }
                else
                {   
                    AddUser(user, db);
                }
            }
            
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

            Console.WriteLine("Printing all local users");
            printAllUsers(users);
            Console.WriteLine("Users in dbset");
            printAllUsers(db.Users);

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