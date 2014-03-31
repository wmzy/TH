namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mapuserandcompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User_Company",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CompanyId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Company", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.User_Company", "UserId", "dbo.User");
            DropIndex("dbo.User_Company", new[] { "CompanyId" });
            DropIndex("dbo.User_Company", new[] { "UserId" });
            DropTable("dbo.User_Company");
        }
    }
}
