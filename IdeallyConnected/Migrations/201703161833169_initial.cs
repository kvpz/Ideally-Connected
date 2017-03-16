namespace IdeallyConnected.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "UserId", "dbo.AspNetUsers");
            DropPrimaryKey("dbo.Skills");
            AddPrimaryKey("dbo.Skills", new[] { "UserId", "Type" });
            AddForeignKey("dbo.Skills", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "UserId", "dbo.AspNetUsers");
            DropPrimaryKey("dbo.Skills");
            AddPrimaryKey("dbo.Skills", "UserId");
            AddForeignKey("dbo.Skills", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
