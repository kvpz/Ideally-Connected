namespace IdeallyConnected.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Biography = c.String(),
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
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SkillUserRelation",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        SkillId = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.SkillId, t.Type })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
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
                        DesignSoftware = c.String(),
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
                "dbo.ProblemSolvingSkills",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 128),
                        Tools = c.String(),
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
                        ProgrammingSoftware = c.String(),
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
            DropForeignKey("dbo.ProblemSolvingSkills", new[] { "ID", "Type" }, "dbo.Skills");
            DropForeignKey("dbo.MedicalSkills", new[] { "ID", "Type" }, "dbo.Skills");
            DropForeignKey("dbo.DesignSkills", new[] { "ID", "Type" }, "dbo.Skills");
            DropForeignKey("dbo.SkillUserRelation", new[] { "SkillId", "Type" }, "dbo.Skills");
            DropForeignKey("dbo.SkillUserRelation", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.SpeakingSkills", new[] { "ID", "Type" });
            DropIndex("dbo.ProgrammingSkills", new[] { "ID", "Type" });
            DropIndex("dbo.ProblemSolvingSkills", new[] { "ID", "Type" });
            DropIndex("dbo.MedicalSkills", new[] { "ID", "Type" });
            DropIndex("dbo.DesignSkills", new[] { "ID", "Type" });
            DropIndex("dbo.SkillUserRelation", new[] { "SkillId", "Type" });
            DropIndex("dbo.SkillUserRelation", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.SpeakingSkills");
            DropTable("dbo.ProgrammingSkills");
            DropTable("dbo.ProblemSolvingSkills");
            DropTable("dbo.MedicalSkills");
            DropTable("dbo.DesignSkills");
            DropTable("dbo.SkillUserRelation");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Skills");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
