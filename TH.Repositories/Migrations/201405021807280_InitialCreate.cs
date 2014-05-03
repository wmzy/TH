namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                .ForeignKey("dbo.Users", t => t.Publisher_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        RealName = c.String(),
                        Nickname = c.String(),
                        QQ = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        MobilePhone = c.String(),
                        Address = c.String(),
                        PhotoURL = c.String(),
                        Birthday = c.DateTime(),
                        Sex = c.String(),
                        AboutMe = c.String(),
                        CreateDate = c.DateTime(),
                        City = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        Name = c.String(),
                        RecruitCount = c.Int(),
                        Location = c.String(),
                        EducationRequire = c.String(),
                        Wage = c.String(),
                        JobDescription = c.String(),
                        WorkYears = c.String(),
                        CompanyIntroduction = c.String(),
                        Requirements = c.String(),
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
                .ForeignKey("dbo.Users", t => t.Publisher_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Job", "Publisher_Id", "dbo.Users");
            DropForeignKey("dbo.JobHuntings", "Publisher_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropTable("dbo.Job");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.JobHuntings");
        }
    }
}
