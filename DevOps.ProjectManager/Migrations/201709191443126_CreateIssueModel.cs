namespace DevOps.ProjectManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateIssueModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        PriorityId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.PriorityId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Issues", "PriorityId", "dbo.Priorities");
            DropIndex("dbo.Issues", new[] { "ProjectId" });
            DropIndex("dbo.Issues", new[] { "PriorityId" });
            DropTable("dbo.Priorities");
            DropTable("dbo.Issues");
        }
    }
}
