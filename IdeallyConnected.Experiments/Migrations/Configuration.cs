namespace IdeallyConnected.Experiments.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdeallyConnected.Experiments.Models.AppICDbContext>
    {
        public Configuration()
        {
            Console.WriteLine("Hello from CONFIGURATION");
            AutomaticMigrationsEnabled = false;
            ImprovedSkillDesign sd = new ImprovedSkillDesign();
        }

        protected override void Seed(IdeallyConnected.Experiments.Models.AppICDbContext context)
        {   
            IList<ProgrammingLanguage> plangs = new List<ProgrammingLanguage>();
            for(int i = 0; i < 10; ++i)
            {
                plangs.Add(new ProgrammingLanguage() { language = "C++" });
            }

            IList<Skill> skills = new List<Skill>();
            fr

            IList<User> users = new List<User>();

            for(int i = 1; i < 10; ++i)
            {
                users.Add(new User { Username = "BobSeed" + i });
            }

            context.Users.AddRange(users);
            context.SaveChanges();
            
        }
    }
}
