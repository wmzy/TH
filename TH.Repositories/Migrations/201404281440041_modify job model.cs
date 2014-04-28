namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyjobmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Job", "Telephones", c => c.String());
            AddColumn("dbo.Job", "ContactPerson", c => c.String());
            AddColumn("dbo.Job", "Views", c => c.Int(nullable: false));
            DropColumn("dbo.Job", "Contact");
            DropColumn("dbo.Job", "Genre");
            DropColumn("dbo.Job", "Telephone");
            DropColumn("dbo.Job", "MobilePhone");
            DropColumn("dbo.Job", "QQ");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Job", "QQ", c => c.String());
            AddColumn("dbo.Job", "MobilePhone", c => c.String());
            AddColumn("dbo.Job", "Telephone", c => c.String());
            AddColumn("dbo.Job", "Genre", c => c.String());
            AddColumn("dbo.Job", "Contact", c => c.String());
            DropColumn("dbo.Job", "Views");
            DropColumn("dbo.Job", "ContactPerson");
            DropColumn("dbo.Job", "Telephones");
        }
    }
}
