namespace IdeallyConnected.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fresh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Softwares", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Softwares", "Type");
        }
    }
}
