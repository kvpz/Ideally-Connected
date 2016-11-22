namespace IdeallyConnectedWebApi_pureNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Biography = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUserRoles", "UserProfile_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "UserProfile_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "UserProfile_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "UserProfile_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUserRoles", "UserProfile_Id");
            CreateIndex("dbo.AspNetUserClaims", "UserProfile_Id");
            CreateIndex("dbo.AspNetUserLogins", "UserProfile_Id");
            CreateIndex("dbo.AspNetUsers", "UserProfile_Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserProfile_Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserProfile_Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserProfile_Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.AspNetUsers", "UserProfile_Id", "dbo.UserProfiles", "Id");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.AspNetUserRoles", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.AspNetUserLogins", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.AspNetUserClaims", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.AspNetUsers", new[] { "UserProfile_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserProfile_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserProfile_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserProfile_Id" });
            DropColumn("dbo.AspNetUserLogins", "UserProfile_Id");
            DropColumn("dbo.AspNetUserClaims", "UserProfile_Id");
            DropColumn("dbo.AspNetUsers", "UserProfile_Id");
            DropColumn("dbo.AspNetUserRoles", "UserProfile_Id");
            DropTable("dbo.UserProfiles");
        }
    }
}
