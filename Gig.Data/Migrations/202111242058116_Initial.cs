namespace Gig.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GigApply",
                c => new
                    {
                        GigApplyId = c.Int(nullable: false, identity: true),
                        GigPostId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.GigApplyId)
                .ForeignKey("dbo.GigPosting", t => t.GigPostId, cascadeDelete: true)
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.GigPostId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.GigPosting",
                c => new
                    {
                        GigPostId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        JobTitle = c.String(nullable: false),
                        DescriptionOfJob = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        PayPerHour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GigPostId);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.WorkHistory",
                c => new
                    {
                        WorkHistoryId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Company = c.String(nullable: false),
                        TimeWorked = c.String(nullable: false),
                        JobTitle = c.String(nullable: false),
                        JobDescription = c.String(nullable: false),
                        Profile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkHistoryId)
                .ForeignKey("dbo.Profile", t => t.Profile_ProfileId)
                .Index(t => t.Profile_ProfileId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.GigApply", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.WorkHistory", "Profile_ProfileId", "dbo.Profile");
            DropForeignKey("dbo.GigApply", "GigPostId", "dbo.GigPosting");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.WorkHistory", new[] { "Profile_ProfileId" });
            DropIndex("dbo.GigApply", new[] { "ProfileId" });
            DropIndex("dbo.GigApply", new[] { "GigPostId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.WorkHistory");
            DropTable("dbo.Profile");
            DropTable("dbo.GigPosting");
            DropTable("dbo.GigApply");
        }
    }
}
