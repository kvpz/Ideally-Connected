﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data; // DataSet, etc. Represents ADO.NET
using System;
using System.Collections.Generic;

namespace IdeallyConnected.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public partial class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;            
        }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<ApplicationUser> AppUser { get; set; }
        public DbSet<ProgrammingLanguages> ProgLanguages { get; set; }
        public DbSet<Software> Software { get; set; }

        public ApplicationDbContext()
            : base("DevelopmentConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            // Change name of the table (to avoid AspNetUsers)
            ///*
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users");
            
                
            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(t => t.UserProfile)
                .WithRequired(t => t.ApplicationUser);
                //.Map(p => p.MapKey("UserId"));
            base.OnModelCreating(modelBuilder);
        }

        internal object Entity<T>(T entity)
        {
            throw new NotImplementedException();
        }
    */
    }



}