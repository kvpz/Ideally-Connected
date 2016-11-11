/*
    In EF terminology, an ENTITY SET typically corresponds to a database table, and an ENTITY to a row in a table.
    The DbSet for Skills and the other tables that are also referenced by User could be removed because EF
    would include them. 
    EF will create a database with tables that have the same name as the DbSet property names. A table name can be
    singular if you add the table names explicitly as such: modelBuilder.Entity<TClass>.ToTable("TableName");
    By default, EF creates plural table names.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeallyConnectedWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdeallyConnectedWebApp.Data
{
    public class IdealConnectDbContext : IdentityDbContext< ApplicationUser >
    {
        public IdealConnectDbContext (DbContextOptions<IdealConnectDbContext> options) : base (options)
        { 
            
        }
        
        //public virtual DbSet<User> User { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProgLanguage> ProgLanguages { get; set; }
        public DbSet<Software> Softwares { get; set; }

        
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            // this should be moved out of here
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ideallyconnecteddb;Trusted_Connection=True;MultipleActiveResultSets=true");
            
            // protected configuration
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ideallyconnecteddb"].ConnectionString);
        }
        
        
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ApplicationUser> (entity => {
                entity.Property(e => e.UserName).IsRequired();
            });   
            

            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<Software>().ToTable("Software");
            modelBuilder.Entity<ProgLanguage>().ToTable("ProgLanguage");
            base.OnModelCreating(modelBuilder);
        }

        

        
    }
}
