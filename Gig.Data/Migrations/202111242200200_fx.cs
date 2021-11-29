namespace Gig.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fx : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkHistory", "Profile_ProfileId", "dbo.Profile");
            DropIndex("dbo.WorkHistory", new[] { "Profile_ProfileId" });
            RenameColumn(table: "dbo.WorkHistory", name: "Profile_ProfileId", newName: "ProfileId");
            AlterColumn("dbo.WorkHistory", "ProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkHistory", "ProfileId");
            AddForeignKey("dbo.WorkHistory", "ProfileId", "dbo.Profile", "ProfileId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkHistory", "ProfileId", "dbo.Profile");
            DropIndex("dbo.WorkHistory", new[] { "ProfileId" });
            AlterColumn("dbo.WorkHistory", "ProfileId", c => c.Int());
            RenameColumn(table: "dbo.WorkHistory", name: "ProfileId", newName: "Profile_ProfileId");
            CreateIndex("dbo.WorkHistory", "Profile_ProfileId");
            AddForeignKey("dbo.WorkHistory", "Profile_ProfileId", "dbo.Profile", "ProfileId");
        }
    }
}
