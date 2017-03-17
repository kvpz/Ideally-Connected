using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Experiments.Models
{
    // EF automatically creates 'IdeallyCo...ted.Exp...ts.AppICDbContext' database if no ConnectionString is included.
    public class AppICDbContext : DbContext 
    {
        //public AppICDbContext() : base("AppICDbContext") {}
        public DbSet<User>                  Users   { get; set; }
        //public DbSet<Skill>                 Skills  { get; set; }    
        public DbSet<Programming>           Programmings  { get; set; }
        public DbSet<ProgrammingLanguage>   ProgrammingLanguages { get; set; }
        public DbSet<Design>                Designs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserMapper());
            //modelBuilder.Entity<User.UserMapper>().HasMany(u => u.
            //base.OnModelCreating(modelBuilder);
        }
    }
}
