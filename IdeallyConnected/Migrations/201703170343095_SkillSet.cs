namespace IdeallyConnected.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillSet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProgrammingLanguages", new[] { "Programming_Type", "Programming_UserId" }, "dbo.Skills");
            DropIndex("dbo.ProgrammingLanguages", new[] { "Programming_Type", "Programming_UserId" });
            DropColumn("dbo.ProgrammingLanguages", "Programming_UserId");
            RenameColumn(table: "dbo.ProgrammingLanguages", name: "Programming_Type", newName: "Programming_UserId");
            DropPrimaryKey("dbo.Skills");
            AlterColumn("dbo.ProgrammingLanguages", "Programming_UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Skills", "UserId");
            CreateIndex("dbo.ProgrammingLanguages", "Programming_UserId");
            AddForeignKey("dbo.Skills", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ProgrammingLanguages", "Programming_UserId", "dbo.Skills", "UserId");
            DropColumn("dbo.Skills", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Type", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProgrammingLanguages", "Programming_UserId", "dbo.Skills");
            DropForeignKey("dbo.Skills", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ProgrammingLanguages", new[] { "Programming_UserId" });
            DropPrimaryKey("dbo.Skills");
            AlterColumn("dbo.ProgrammingLanguages", "Programming_UserId", c => c.Int());
            AddPrimaryKey("dbo.Skills", new[] { "Type", "UserId" });
            RenameColumn(table: "dbo.ProgrammingLanguages", name: "Programming_UserId", newName: "Programming_Type");
            AddColumn("dbo.ProgrammingLanguages", "Programming_UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProgrammingLanguages", new[] { "Programming_Type", "Programming_UserId" });
            AddForeignKey("dbo.ProgrammingLanguages", new[] { "Programming_Type", "Programming_UserId" }, "dbo.Skills", new[] { "Type", "UserId" });
            AddForeignKey("dbo.Skills", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
