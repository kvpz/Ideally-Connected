namespace IdeallyConnected.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Biography = c.String(),
                        Created = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 128),
                        Expertise = c.Byte(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Type });
            
            CreateTable(
                "dbo.UserLocations",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        LocationID = c.Int(nullable: false),
                        TotalVisitations = c.Int(nullable: false),
                        FirstVisited = c.DateTime(nullable: false),
                        LastVisited = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.LocationID })
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        ZipCode = c.String(),
                        State = c.String(nullable: false),
                        StateAbbreviation = c.String(),
                        City = c.String(nullable: false),
                        County = c.String(),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Business_Name = c.String(maxLength: 128),
                        Business_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Businesses", t => new { t.Business_Name, t.Business_LocationID })
                .Index(t => new { t.Business_Name, t.Business_LocationID });
            
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        LocationID = c.Int(nullable: false),
                        ChatService = c.Boolean(nullable: false),
                        P2PService = c.Boolean(nullable: false),
                        IdentificationService = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Name, t.LocationID })
                .ForeignKey("dbo.Locations", t => t.LocationID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Collaborators",
                c => new
                    {
                        UserA = c.String(nullable: false, maxLength: 128),
                        UserB = c.String(nullable: false, maxLength: 128),
                        Following = c.Boolean(nullable: false),
                        Initiated = c.Boolean(nullable: false),
                        InitialCollaboration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserA, t.UserB })
                .ForeignKey("dbo.Users", t => t.UserA, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserB, cascadeDelete: true)
                .Index(t => t.UserA)
                .Index(t => t.UserB);
            
            CreateTable(
                "dbo.SkillUserRelation",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        SkillId = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.SkillId, t.Type })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => new { t.SkillId, t.Type }, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => new { t.SkillId, t.Type });
            
            CreateTable(
                "dbo.DesignSkills",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 128),
                        TypeOfDesign = c.String(),
                        Software = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Type })
                .ForeignKey("dbo.Skills", t => new { t.ID, t.Type })
                .Index(t => new { t.ID, t.Type });
            
            CreateTable(
                "dbo.MedicalSkills",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 128),
                        CPR = c.Boolean(nullable: false),
                        EKG = c.Boolean(nullable: false),
                        Transfussions = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.Type })
                .ForeignKey("dbo.Skills", t => new { t.ID, t.Type })
                .Index(t => new { t.ID, t.Type });
            
            CreateTable(
                "dbo.ProgrammingSkills",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 128),
                        ProgrammingLanguages = c.String(),
                        Software = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Type })
                .ForeignKey("dbo.Skills", t => new { t.ID, t.Type })
                .Index(t => new { t.ID, t.Type });
            
            CreateTable(
                "dbo.SpeakingSkills",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 128),
                        Languages = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Type })
                .ForeignKey("dbo.Skills", t => new { t.ID, t.Type })
                .Index(t => new { t.ID, t.Type });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpeakingSkills", new[] { "ID", "Type" }, "dbo.Skills");
            DropForeignKey("dbo.ProgrammingSkills", new[] { "ID", "Type" }, "dbo.Skills");
            DropForeignKey("dbo.MedicalSkills", new[] { "ID", "Type" }, "dbo.Skills");
            DropForeignKey("dbo.DesignSkills", new[] { "ID", "Type" }, "dbo.Skills");
            DropForeignKey("dbo.Collaborators", "UserB", "dbo.Users");
            DropForeignKey("dbo.Collaborators", "UserA", "dbo.Users");
            DropForeignKey("dbo.UserLocations", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserLocations", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Locations", new[] { "Business_Name", "Business_LocationID" }, "dbo.Businesses");
            DropForeignKey("dbo.Businesses", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.SkillUserRelation", new[] { "SkillId", "Type" }, "dbo.Skills");
            DropForeignKey("dbo.SkillUserRelation", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.SpeakingSkills", new[] { "ID", "Type" });
            DropIndex("dbo.ProgrammingSkills", new[] { "ID", "Type" });
            DropIndex("dbo.MedicalSkills", new[] { "ID", "Type" });
            DropIndex("dbo.DesignSkills", new[] { "ID", "Type" });
            DropIndex("dbo.SkillUserRelation", new[] { "SkillId", "Type" });
            DropIndex("dbo.SkillUserRelation", new[] { "UserId" });
            DropIndex("dbo.Collaborators", new[] { "UserB" });
            DropIndex("dbo.Collaborators", new[] { "UserA" });
            DropIndex("dbo.Businesses", new[] { "LocationID" });
            DropIndex("dbo.Locations", new[] { "Business_Name", "Business_LocationID" });
            DropIndex("dbo.UserLocations", new[] { "LocationID" });
            DropIndex("dbo.UserLocations", new[] { "UserID" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropTable("dbo.SpeakingSkills");
            DropTable("dbo.ProgrammingSkills");
            DropTable("dbo.MedicalSkills");
            DropTable("dbo.DesignSkills");
            DropTable("dbo.SkillUserRelation");
            DropTable("dbo.Collaborators");
            DropTable("dbo.Businesses");
            DropTable("dbo.Locations");
            DropTable("dbo.UserLocations");
            DropTable("dbo.Skills");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
