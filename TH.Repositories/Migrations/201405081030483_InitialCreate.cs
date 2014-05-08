namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        Content = c.String(),
                        Introduction = c.String(),
                        ConstructionExperience = c.Int(nullable: false),
                        Performance = c.String(),
                        Title = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        CreatedDate = c.DateTime(),
                        PublisherId = c.String(maxLength: 128),
                        ValidDate = c.DateTime(),
                        Telephones = c.String(),
                        ContactPerson = c.String(),
                        Views = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.PublisherId);
            
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
                        PhotoURL = c.String(maxLength: 256, fixedLength: true),
                        Birthday = c.DateTime(),
                        Sex = c.String(),
                        AboutMe = c.String(),
                        CreateDate = c.DateTime(),
                        City = c.String(maxLength: 80),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Claims",
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
                "dbo.Logins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobHuntings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nation = c.String(),
                        Age = c.Int(),
                        WorkYears = c.Int(),
                        Education = c.String(),
                        WorkExperience = c.String(),
                        Job = c.String(),
                        Wage = c.String(),
                        Introduction = c.String(),
                        Title = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        CreatedDate = c.DateTime(),
                        PublisherId = c.String(maxLength: 128),
                        ValidDate = c.DateTime(),
                        Telephones = c.String(),
                        ContactPerson = c.String(),
                        Views = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.PublisherId);
            
            CreateTable(
                "dbo.Jobs",
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
                        PublisherId = c.String(maxLength: 128),
                        ValidDate = c.DateTime(),
                        Telephones = c.String(),
                        ContactPerson = c.String(),
                        Views = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.PublisherId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        ProjectName = c.String(),
                        Content = c.String(),
                        StartTime = c.DateTime(),
                        TimeLimit = c.Int(nullable: false),
                        Require = c.String(),
                        Title = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        CreatedDate = c.DateTime(),
                        PublisherId = c.String(maxLength: 128),
                        ValidDate = c.DateTime(),
                        Telephones = c.String(),
                        ContactPerson = c.String(),
                        Views = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.PublisherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "PublisherId", "dbo.Users");
            DropForeignKey("dbo.Jobs", "PublisherId", "dbo.Users");
            DropForeignKey("dbo.JobHuntings", "PublisherId", "dbo.Users");
            DropForeignKey("dbo.ContractProjects", "PublisherId", "dbo.Users");
            DropForeignKey("dbo.Claims", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Logins", "UserId", "dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.Jobs");
            DropTable("dbo.JobHuntings");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Logins");
            DropTable("dbo.Claims");
            DropTable("dbo.Users");
            DropTable("dbo.ContractProjects");
        }
    }
}
