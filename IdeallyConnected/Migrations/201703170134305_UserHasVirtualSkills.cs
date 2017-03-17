namespace IdeallyConnected.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserHasVirtualSkills : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skills", "DesignSubSkill");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "DesignSubSkill", c => c.String());
        }
    }
}
