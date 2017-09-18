namespace DevOps.ProjectManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProjectsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        StatusId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectStatus", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.ProjectStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);


            Sql("INSERT INTO ProjectStatus (NAME) VALUES ('Open');");
            Sql("INSERT INTO ProjectStatus (NAME) VALUES ('Closed');");
            Sql("INSERT INTO ProjectStatus (NAME) VALUES ('Current');");
            Sql("INSERT INTO ProjectStatus (NAME) VALUES ('On hold');");
            Sql("INSERT INTO ProjectStatus (NAME) VALUES ('Archived');");
            Sql("INSERT INTO ProjectStatus (NAME) VALUES ('Planning');");
            Sql("INSERT INTO ProjectStatus (NAME) VALUES ('Requested');");
            Sql("INSERT INTO ProjectStatus (NAME) VALUES ('Approved');");
            Sql("INSERT INTO ProjectStatus (NAME) VALUES ('Declined');");
            Sql("INSERT INTO ProjectStatus (NAME) VALUES ('Idea');");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "StatusId", "dbo.ProjectStatus");
            DropIndex("dbo.Projects", new[] { "StatusId" });
            DropTable("dbo.ProjectStatus");
            DropTable("dbo.Projects");
        }
    }
}
