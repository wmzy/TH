namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobHuntingConfiguration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobHuntings", "Title", c => c.String(maxLength: 40, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobHuntings", "Title", c => c.String());
        }
    }
}
