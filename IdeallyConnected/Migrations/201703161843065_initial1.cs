namespace IdeallyConnected.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Skills");
            AddPrimaryKey("dbo.Skills", new[] { "Type", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Skills");
            AddPrimaryKey("dbo.Skills", new[] { "UserId", "Type" });
        }
    }
}
