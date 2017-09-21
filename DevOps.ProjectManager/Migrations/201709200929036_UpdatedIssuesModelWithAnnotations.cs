namespace DevOps.ProjectManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedIssuesModelWithAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Issues", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Issues", "Name", c => c.String(nullable: false));
        }
    }
}
