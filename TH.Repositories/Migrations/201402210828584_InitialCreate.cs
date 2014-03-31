namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        RegistrationNumber = c.String(),
                        Name = c.String(),
                        NickName = c.String(),
                        LegalPerson = c.String(),
                        Trade = c.String(),
                        Type = c.String(),
                        SizeL = c.Int(nullable: false),
                        SizeT = c.Int(nullable: false),
                        Introduction = c.String(),
                        Address = c.String(),
                        Website = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.FullTimeJob",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WageL = c.Int(nullable: false),
                        WageT = c.Int(nullable: false),
                        JobDescription = c.String(),
                        SexRequire = c.Boolean(),
                        EducationRequire = c.String(),
                        WorkYearsL = c.Int(),
                        WorkYearsT = c.Int(),
                        RecruitCount = c.Int(nullable: false),
                        Tags = c.String(),
                        Title = c.String(),
                        CityId = c.Int(nullable: false),
                        RegionId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        Company_CompanyId = c.Int(),
                        Type_FullTimeJobTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_CompanyId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.FullTimeJobType", t => t.Type_FullTimeJobTypeId)
                .Index(t => t.Company_CompanyId)
                .Index(t => t.UserId)
                .Index(t => t.Type_FullTimeJobTypeId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        RealName = c.String(),
                        Nickname = c.String(),
                        QQ = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        MobilePhone = c.String(),
                        Address = c.String(),
                        PostCode = c.String(),
                        PhotoURL = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Sex = c.String(),
                        AboutMe = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        CountryId = c.Int(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.FullTimeJobType",
                c => new
                    {
                        FullTimeJobTypeId = c.Int(nullable: false, identity: true),
                        FullTimeJobTypeName = c.String(),
                    })
                .PrimaryKey(t => t.FullTimeJobTypeId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FullTimeJob", "Type_FullTimeJobTypeId", "dbo.FullTimeJobType");
            DropForeignKey("dbo.FullTimeJob", "UserId", "dbo.User");
            DropForeignKey("dbo.Company", "User_UserId", "dbo.User");
            DropForeignKey("dbo.FullTimeJob", "Company_CompanyId", "dbo.Company");
            DropIndex("dbo.FullTimeJob", new[] { "Type_FullTimeJobTypeId" });
            DropIndex("dbo.FullTimeJob", new[] { "UserId" });
            DropIndex("dbo.Company", new[] { "User_UserId" });
            DropIndex("dbo.FullTimeJob", new[] { "Company_CompanyId" });
            DropTable("dbo.Genre");
            DropTable("dbo.FullTimeJobType");
            DropTable("dbo.User");
            DropTable("dbo.FullTimeJob");
            DropTable("dbo.Company");
        }
    }
}
