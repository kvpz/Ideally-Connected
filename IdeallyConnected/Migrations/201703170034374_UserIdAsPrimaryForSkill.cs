namespace IdeallyConnected.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdAsPrimaryForSkill : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Skills", name: "UserName", newName: "UserId");
            RenameIndex(table: "dbo.Skills", name: "IX_UserName", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Skills", name: "IX_UserId", newName: "IX_UserName");
            RenameColumn(table: "dbo.Skills", name: "UserId", newName: "UserName");
        }
    }
}
