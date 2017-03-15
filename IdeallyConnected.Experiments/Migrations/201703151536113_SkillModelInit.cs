namespace IdeallyConnected.Experiments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillModelInit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "DesignPropOne", c => c.String());
            AddColumn("dbo.Skills", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "Discriminator");
            DropColumn("dbo.Skills", "DesignPropOne");
        }
    }
}
