namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobHuntings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobHuntings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nation = c.String(),
                        Age = c.Int(nullable: false),
                        WorkYears = c.Int(nullable: false),
                        Education = c.String(),
                        WorkExperience = c.String(),
                        Job = c.String(),
                        Wage = c.String(),
                        Introduction = c.String(),
                        Title = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        CreatedDate = c.DateTime(),
                        Telephones = c.String(),
                        ContactPerson = c.String(),
                        Views = c.Int(nullable: false),
                        Publisher_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Publisher_Id)
                .Index(t => t.Publisher_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobHuntings", "Publisher_Id", "dbo.AspNetUsers");
            DropIndex("dbo.JobHuntings", new[] { "Publisher_Id" });
            DropTable("dbo.JobHuntings");
        }
    }
}
