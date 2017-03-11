namespace IdeallyConnected.Experiments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillsEnum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128),
                        Skill_ID = c.Int(),
                    })
                .PrimaryKey(t => t.username)
                .ForeignKey("dbo.Skills", t => t.Skill_ID)
                .Index(t => t.Skill_ID);
            
            AddColumn("dbo.Skills", "Description", c => c.String());
            DropColumn("dbo.Skills", "Programming");
            DropColumn("dbo.Skills", "ProgrammingLanguages");
            DropColumn("dbo.Skills", "Software");
            DropColumn("dbo.Skills", "Sports");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Sports", c => c.String());
            AddColumn("dbo.Skills", "Software", c => c.String());
            AddColumn("dbo.Skills", "ProgrammingLanguages", c => c.String());
            AddColumn("dbo.Skills", "Programming", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Users", "Skill_ID", "dbo.Skills");
            DropIndex("dbo.Users", new[] { "Skill_ID" });
            DropColumn("dbo.Skills", "Description");
            DropTable("dbo.Users");
        }
    }
}
