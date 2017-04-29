using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        public virtual ICollection<UserLocations> UserLocations { get; set; }

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
        public ICDbContext() : this(ConfigurationManager.ConnectionStrings["IdeallyConnectedTestDb"].ConnectionString)
        {
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

            // Create User and Skill Relationship Schema
            modelBuilder.Entity<User>()
                .HasMany<Skill>(s => s.Skills)
                .WithMany(s => s.Users)
                .Map(config => 
                {
                    config.MapLeftKey("UserId");
                    config.MapRightKey("SkillId", "Type");
                    config.ToTable("SkillUserRelation");
                });

            // Create Collaborators Table with composite key of foreign keys.
            modelBuilder.Entity<Collaborators>()
                .HasKey(c => new { c.UserA, c.UserB });
            modelBuilder.Entity<Collaborators>()
                .HasRequired<User>(u => u.User1)
                .WithMany()
                .HasForeignKey<string>(c => c.UserA)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Collaborators>()
                .HasRequired<User>(u => u.User2)
                .WithMany()
                .HasForeignKey<string>(c => c.UserB)
                .WillCascadeOnDelete(true);

            // Configure Location table
            modelBuilder.Entity<Location>()
                .ToTable("Locations")
                .HasKey(location => location.ID);
            modelBuilder.Entity<Location>()
                .Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Location>()
                .Property(p => p.Address).IsRequired();
            modelBuilder.Entity<Location>()
                .Property(p => p.City).IsRequired();
            modelBuilder.Entity<Location>()
                .Property(p => p.State).IsRequired();

            // Relation table between users and the locations they visit with accompanying attributes. Users "leave a footprint"/ "drop an egg" at that location.            
            modelBuilder.Entity<UserLocations>()
                .ToTable("UserLocations")
                .HasKey(userlocation => new { userlocation.UserID, userlocation.LocationID });

            // Setup Businesses table with composite key. One business/ company name can have various locations.
            modelBuilder.Entity<Business>()
                .ToTable("Businesses");
            modelBuilder.Entity<Business>()
                .HasKey(business => new { business.Name, business.LocationID });
            modelBuilder.Entity<Business>()
                .HasRequired<Location>(business => business.Location)
                .WithMany()
                .HasForeignKey<int>(b => b.LocationID)
                .WillCascadeOnDelete(false);
        }
    }
}
