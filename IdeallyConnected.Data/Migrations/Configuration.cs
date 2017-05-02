namespace IdeallyConnected.Data.Migrations
{
    using IdeallyConnected.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    // This is processed after OnModelCreating
    internal sealed class Configuration : DbMigrationsConfiguration<IdeallyConnected.Data.Models.ICDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "IdeallyConnected.Data.Models.ICDbContext"; 
        }

        //  This method will be called after migrating to the latest version.
        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. Data must be valid!
        protected override void Seed(IdeallyConnected.Data.Models.ICDbContext context)
        {
            // Use DatabaseManagementForms to view and add data to the database.    
            
        }
    }
}
