namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "CountryId", c => c.Int());
            AlterColumn("dbo.User", "ProvinceId", c => c.Int());
            AlterColumn("dbo.User", "CityId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "ProvinceId", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "CountryId", c => c.Int(nullable: false));
        }
    }
}
