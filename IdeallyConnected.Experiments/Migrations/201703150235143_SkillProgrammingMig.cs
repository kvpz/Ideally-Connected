namespace IdeallyConnected.Experiments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillProgrammingMig : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProgrammingLanguages");
            AddColumn("dbo.ProgrammingLanguages", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ProgrammingLanguages", "language", c => c.String(maxLength: 12));
            AddPrimaryKey("dbo.ProgrammingLanguages", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProgrammingLanguages");
            AlterColumn("dbo.ProgrammingLanguages", "language", c => c.String(nullable: false, maxLength: 12));
            DropColumn("dbo.ProgrammingLanguages", "Id");
            AddPrimaryKey("dbo.ProgrammingLanguages", "language");
        }
    }
}
