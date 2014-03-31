namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 修Ta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FullTimeJob", "UserId", "dbo.User");
            DropIndex("dbo.FullTimeJob", new[] { "UserId" });
            RenameColumn(table: "dbo.FullTimeJob", name: "UserId", newName: "Publisher_UserId");
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        FullTimeJob_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FullTimeJob", t => t.FullTimeJob_Id)
                .Index(t => t.FullTimeJob_Id);
            
            AlterColumn("dbo.FullTimeJob", "Publisher_UserId", c => c.Int());
            CreateIndex("dbo.FullTimeJob", "Publisher_UserId");
            AddForeignKey("dbo.FullTimeJob", "Publisher_UserId", "dbo.User", "UserId");
            DropColumn("dbo.FullTimeJob", "Tags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FullTimeJob", "Tags", c => c.String());
            DropForeignKey("dbo.FullTimeJob", "Publisher_UserId", "dbo.User");
            DropForeignKey("dbo.Tag", "FullTimeJob_Id", "dbo.FullTimeJob");
            DropIndex("dbo.FullTimeJob", new[] { "Publisher_UserId" });
            DropIndex("dbo.Tag", new[] { "FullTimeJob_Id" });
            AlterColumn("dbo.FullTimeJob", "Publisher_UserId", c => c.Int(nullable: false));
            DropTable("dbo.Tag");
            RenameColumn(table: "dbo.FullTimeJob", name: "Publisher_UserId", newName: "UserId");
            CreateIndex("dbo.FullTimeJob", "UserId");
            AddForeignKey("dbo.FullTimeJob", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
    }
}
