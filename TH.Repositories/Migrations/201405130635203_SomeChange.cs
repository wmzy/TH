namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CommentTime = c.DateTime(nullable: false),
                        Content = c.String(),
                        ReplyForId = c.Int(),
                        PostId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.ReplyForId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ReplyForId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreaterId = c.Int(nullable: false),
                        Content = c.String(),
                        Views = c.Int(nullable: false),
                        Creater_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Creater_Id)
                .Index(t => t.Creater_Id);
            
            AlterColumn("dbo.ContractProjects", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobHuntings", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Creater_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "ReplyForId", "dbo.Comments");
            DropIndex("dbo.Posts", new[] { "Creater_Id" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "ReplyForId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            AlterColumn("dbo.Projects", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Jobs", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.JobHuntings", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.ContractProjects", "CreatedDate", c => c.DateTime());
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
