namespace TH.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobHunting : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobHuntings", "Age", c => c.Int());
            AlterColumn("dbo.JobHuntings", "WorkYears", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobHuntings", "WorkYears", c => c.Int(nullable: false));
            AlterColumn("dbo.JobHuntings", "Age", c => c.Int(nullable: false));
        }
    }
}
