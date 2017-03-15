namespace IdeallyConnected.Experiments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WritingModelInit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "DesignSubSkill", c => c.String());
            AddColumn("dbo.Skills", "WritingSubSkill", c => c.String());
            DropColumn("dbo.Skills", "DesignPropOne");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "DesignPropOne", c => c.String());
            DropColumn("dbo.Skills", "WritingSubSkill");
            DropColumn("dbo.Skills", "DesignSubSkill");
        }
    }
}
