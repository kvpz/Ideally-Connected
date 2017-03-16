namespace IdeallyConnected.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdeallyConnected.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdeallyConnected.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var users = new List<ApplicationUser>() {
                new ApplicationUser() {
                    UserName = "Bob1",
                    FirstName = "Bob",
                    LastName = "One"
                },
                new ApplicationUser() {
                    UserName = "Bob2",
                    FirstName = "Bob2",
                    LastName =  "Two"
                }, 
                new ApplicationUser() {
                    UserName = "Bob3",
                    FirstName = "Bob3",
                    LastName = "Three"
                }
            };

            var skills = new List<Skill>() {
                new Skill() {
                    SkillManager = users[0],
                    //UserId = users[0].Id,
                    //Description = "sdfasdf",
                    Type = 0
                },
                new Skill() {
                    SkillManager = users[1],
                    //UserId = users[1].Id,
                    //Description = "sdfas",
                    Type = 1
                },
                new Skill() {
                    SkillManager = users[2],
                    //UserId = users[2].Id, 
                    //Description = "asdf",
                    Type = 2
                }
            };
            /*
            context.Users.AddOrUpdate(
                u => u.UserName,
                users.ToArray()
            );
            */
            context.Skills.AddOrUpdate(
                //s => s.UserId,
                skills.ToArray()
            );
        }
    }
}
