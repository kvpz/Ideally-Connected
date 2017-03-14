namespace IdeallyConnected.Experiments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgrammingLanguages",
                c => new
                    {
                        language = c.String(nullable: false, maxLength: 12),
                        Programming_ID = c.Int(),
                    })
                .PrimaryKey(t => t.language)
                .ForeignKey("dbo.Skills", t => t.Programming_ID)
                .Index(t => t.Programming_ID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        Expertise = c.Byte(),
                        User_Id = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        locationsIP = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ProgrammingLanguages", "Programming_ID", "dbo.Skills");
            DropIndex("dbo.Skills", new[] { "User_Id" });
            DropIndex("dbo.ProgrammingLanguages", new[] { "Programming_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Skills");
            DropTable("dbo.ProgrammingLanguages");
        }
    }
}
