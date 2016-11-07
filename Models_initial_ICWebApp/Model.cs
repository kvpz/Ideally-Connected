using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; // Microsoft.DataAnnotations in .Net 4.6 (aka vNext)

namespace IdeallyConnectedWebApp.Models
{
    /*
        DbContext is the primary class responsible for interacting with data as objects (aka entities; and part of CLR).
        The context manages the entity objects during run time (populating objects with data from a db, change tracking, and
        persisting data to the db).
        DbSet properties represent collections of the specified entities in the context.
    */
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options) : base (options)
        { }
        public DbSet<User> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        // Specify model configurations without modifying the entity classes. (a Fluent API configuration)
        // Fluent configurations can override data annotations.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(b => b.Url).IsRequired(); // i.e. cannot be null
            modelBuilder.Entity<User>().Property(b => b.ID).ValueGeneratedOnAdd();
        }
    }
    
    public class User
    {
        [Key]
        public uint ID { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        public string email { get; set; }
        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public User Blog { get; set; }
    }
}
