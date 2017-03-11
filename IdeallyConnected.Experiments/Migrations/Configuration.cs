namespace IdeallyConnected.Experiments.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
            //  This method will be called after migrating to the latest version.
            /*
                This method prevents errors that would happen if you try to insert
                a row that already exists, but it overrides any changes
                to data that you may have made while testing the application.
            */
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //      // An "upsert" operation.
            /*
            context.Skills.AddOrUpdate(
                s => s.ProgrammingLanguages,
                new Skill { 
                    Programming = true, 
                    ProgrammingLanguages = "Java, C, Objective-C", 
                    Software = "Visual Studio", 
                    Sports = "Baseball" 
                }
            );
            */

            context.Skills.SeedEnumValues<Skill, SkillEnum>(@enum => @enum);
            context.SaveChanges();
        }
    }
}
