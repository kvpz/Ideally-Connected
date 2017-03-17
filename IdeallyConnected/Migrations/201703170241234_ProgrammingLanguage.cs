namespace IdeallyConnected.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgrammingLanguage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgrammingLanguages",
                c => new
                    {
                        language = c.String(nullable: false, maxLength: 12),
                        Programming_Type = c.Int(),
                        Programming_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.language)
                .ForeignKey("dbo.Skills", t => new { t.Programming_Type, t.Programming_UserId })
                .Index(t => new { t.Programming_Type, t.Programming_UserId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgrammingLanguages", new[] { "Programming_Type", "Programming_UserId" }, "dbo.Skills");
            DropIndex("dbo.ProgrammingLanguages", new[] { "Programming_Type", "Programming_UserId" });
            DropTable("dbo.ProgrammingLanguages");
        }
    }
}
