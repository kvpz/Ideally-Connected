namespace IdeallyConnected.Experiments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WritingModelInit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "SpeakingSubSkill", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "SpeakingSubSkill");
        }
    }
}
