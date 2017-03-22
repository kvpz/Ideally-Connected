namespace IdeallyConnected.Experiments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImprovedSkillDesign : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Type = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Expertise = c.Byte(),
                        DesignSubSkill = c.String(),
                        SpeakingSubSkill = c.String(),
                        WritingSubSkill = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        User_Username = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.Type)
                .ForeignKey("dbo.Users", t => t.User_Username, cascadeDelete: true)
                .Index(t => t.User_Username);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 36),
                        locationsIP = c.Int(),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.ProgrammingLanguages",
                c => new
                    {
                        language = c.String(nullable: false, maxLength: 12),
                        User_Username = c.String(maxLength: 36),
                        Programming_Type = c.Int(),
                    })
                .PrimaryKey(t => t.language)
                .PrimaryKey(t => t.User_Username)
                .ForeignKey("dbo.Users", t => t.User_Username, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Programming_Type)
                .Index(t => t.User_Username)
                .Index(t => t.Programming_Type);

            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgrammingLanguages", "Programming_Type", "dbo.Skills");
            DropForeignKey("dbo.ProgrammingLanguages", "User_Username", "dbo.Users");
            DropForeignKey("dbo.Skills", "User_Username", "dbo.Users");
            DropIndex("dbo.ProgrammingLanguages", new[] { "Programming_Type" });
            DropIndex("dbo.ProgrammingLanguages", new[] { "User_Username" });
            DropIndex("dbo.Skills", new[] { "User_Username" });
            DropTable("dbo.ProgrammingLanguages");
            DropTable("dbo.Users");
            DropTable("dbo.Skills");
        }
    }
}
