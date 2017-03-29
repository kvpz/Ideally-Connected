using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdeallyConnected.Data.Models
{
    public partial class User : IdentityUser
    {
        public User() 
        {
            Skills = new HashSet<Skill>();
        }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$")]
        public string LastName { get; set; }

        public string Biography { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ICDbContext : IdentityDbContext<User>
    {
        public ICDbContext() : base("DevelopmentConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public ICDbContext(string connectionString) : base(connectionString, throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ICDbContext Create()
        {
            return new ICDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");

            // Create ApplicationUser and Skill Relationship Schema
            modelBuilder.Entity<User>()
                .HasMany<Skill>(s => s.Skills)
                .WithMany(s => s.Users)
                .Map(config => {
                    config.MapLeftKey("UserId");
                    config.MapRightKey("SkillId", "Type");
                    config.ToTable("SkillUserRelation");
                });

            // Create Collaborators Table 
            modelBuilder.Entity<Collaborators>()
                .HasKey(c => new { c.UserA, c.UserB });
            modelBuilder.Entity<Collaborators>()
                .HasRequired(u => u.User1)
                .WithMany()
                .HasForeignKey(c => c.UserA);
            modelBuilder.Entity<Collaborators>()
                .HasRequired(u => u.User2)
                .WithMany()
                .HasForeignKey(c => c.UserB)
                .WillCascadeOnDelete(false);
        }
    }
}
