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
                    LastName = "Three"
                }
            };
            var dbUsers = context.Users.ToList();
            if(dbUsers.Count < 3)
                dbUsers = users;
            var skills = new List<Skill>() {
                new Skill() {
                    SkillManager = dbUsers?[0],//users[0],
                    //UserId = dbUsers[0].Id,
                    //Description = "sdfasdf",
                    Type = 1
                },
                new Skill() {
                    SkillManager = dbUsers?[1],//users[1],
                    //UserId = users[1].Id,
                    //Description = "sdfas",
                    Type = 1
                },
                new Skill() {
                    SkillManager = dbUsers?[2],//users[2],
                    //UserId = users[2].Id, 
                    //Description = "asdf",
                    Type = 2
                }
            };


            context.Skills.AddOrUpdate(
                s => new { s.UserId, s.Type },
                skills.ToArray()
            );
        }
    }
}
