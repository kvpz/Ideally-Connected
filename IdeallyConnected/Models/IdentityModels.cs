using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data; // DataSet, etc. Represents ADO.NET
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer; // SqlServerMigrationSqlGenerator

namespace IdeallyConnected.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            //Skills = new HashSet<Skill>();
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;            
        }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        
        public DbSet<Skill> Skills { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany<Skill>(s => s.Skills)
                .WithMany(s => s.ApplicationUsers)
                .Map(config => {
                    config.MapLeftKey("UserId");
                    config.MapRightKey("SkillId", "Type");
                    config.ToTable("SkillUserRelation"); 
                });
            
            base.OnModelCreating(modelBuilder);
        }
    }



}