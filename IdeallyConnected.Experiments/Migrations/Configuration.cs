namespace IdeallyConnected.Experiments.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using IdeallyConnected.Experiments;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<IdeallyConnected.Experiments.AppICDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "IdeallyConnected.Experiments.AppICDbContext";
        }

        // Updates rows that have already been inserted or inserts rows if they don't exist.
        protected override void Seed(IdeallyConnected.Experiments.AppICDbContext context)
        {
            Random randomInteger = new Random();
            
            var users = new List<User> {
                new User { username = "johninit", locationsIP = 1111 },
                new User { username = "johninit2", locationsIP = 1234 },
                new User { username = "johninit3", locationsIP = 124235 },
                new User { username = "johninit4", locationsIP = 213421 }
            };

            foreach(User user in users)
            {
                user.Skill = (SkillEnum)randomInteger.Next(0,5);
                user.Skill.Description = Utility.GenerateProgrammingLanguages(randomInteger.Next(0, 10));
            }
            
            foreach(User user in users)
            {
                var dbUser = context.Users.Find(user.username);
                dbUser.Skill.Description = user.Skill.Description;
            }

            // Select all rows from dbo.Skills whose ID is not referenced in dbo.Users.
            var skillsWithoutUser = context.Skills.SqlQuery("SELECT * FROM Skills WHERE Skills.ID NOT IN (SELECT Skills.ID FROM dbo.Users, dbo.Skills WHERE Skills.ID = dbo.Users.Skill_ID)").ToList();

            foreach(var dbskill in skillsWithoutUser)
            {
                context.Skills.Remove(dbskill);
            }

            //context.Skills.SeedEnumValues<Skill, SkillEnum>(@enum => @enum);
            context.SaveChanges();
        }
    }
}
