namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 修改模型 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Company", "User_UserId", "dbo.User");
            DropForeignKey("dbo.Tag", "FullTimeJob_Id", "dbo.FullTimeJob");
            DropForeignKey("dbo.FullTimeJob", "Publisher_UserId", "dbo.User");
            DropIndex("dbo.Company", new[] { "User_UserId" });
            DropIndex("dbo.Tag", new[] { "FullTimeJob_Id" });
            DropIndex("dbo.FullTimeJob", new[] { "Publisher_UserId" });
            RenameColumn(table: "dbo.FullTimeJob", name: "Publisher_UserId", newName: "UserId");
            AddColumn("dbo.Company", "Manager_UserId", c => c.Int());
            AddColumn("dbo.FullTimeJob", "Tags", c => c.String());
            AlterColumn("dbo.Company", "SizeL", c => c.Int());
            AlterColumn("dbo.Company", "SizeT", c => c.Int());
            AlterColumn("dbo.FullTimeJob", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "Birthday", c => c.DateTime());
            AlterColumn("dbo.User", "CreateDate", c => c.DateTime());
            CreateIndex("dbo.Company", "Manager_UserId");
            CreateIndex("dbo.FullTimeJob", "UserId");
            AddForeignKey("dbo.Company", "Manager_UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.FullTimeJob", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            DropColumn("dbo.Company", "User_UserId");
            DropTable("dbo.Tag");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        FullTimeJob_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Company", "User_UserId", c => c.Int());
            DropForeignKey("dbo.FullTimeJob", "UserId", "dbo.User");
            DropForeignKey("dbo.Company", "Manager_UserId", "dbo.User");
            DropIndex("dbo.FullTimeJob", new[] { "UserId" });
            DropIndex("dbo.Company", new[] { "Manager_UserId" });
            AlterColumn("dbo.User", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.User", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FullTimeJob", "UserId", c => c.Int());
            AlterColumn("dbo.Company", "SizeT", c => c.Int(nullable: false));
            AlterColumn("dbo.Company", "SizeL", c => c.Int(nullable: false));
            DropColumn("dbo.FullTimeJob", "Tags");
            DropColumn("dbo.Company", "Manager_UserId");
            RenameColumn(table: "dbo.FullTimeJob", name: "UserId", newName: "Publisher_UserId");
            CreateIndex("dbo.FullTimeJob", "Publisher_UserId");
            CreateIndex("dbo.Tag", "FullTimeJob_Id");
            CreateIndex("dbo.Company", "User_UserId");
            AddForeignKey("dbo.FullTimeJob", "Publisher_UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Tag", "FullTimeJob_Id", "dbo.FullTimeJob", "Id");
            AddForeignKey("dbo.Company", "User_UserId", "dbo.User", "UserId");
        }
    }
}
