using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace IdeallyConnectedWebApp.Models
{
    public class IdealContext : DbContext
    {
        public IdealContext (DbContextOptions<IdealContext> options) : base (options)
        { }
        /*
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            // this should be moved out of here
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ideallyconnecteddb;TrustedConnection=True;");
        }
        */
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users> (entity => {
                entity.Property(e => e.username).IsRequired();
            });   

            
        }

        public virtual DbSet<Users> Users { get; set; }
        
    }
}
