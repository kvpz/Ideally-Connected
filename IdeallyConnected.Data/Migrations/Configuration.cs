namespace IdeallyConnected.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdeallyConnected.Data.Models.ICDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "IdeallyConnected.Data.Models.ICDbContext"; 
        }

        //  This method will be called after migrating to the latest version.
        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        protected override void Seed(IdeallyConnected.Data.Models.ICDbContext context)
        {
            
        }
    }
}
