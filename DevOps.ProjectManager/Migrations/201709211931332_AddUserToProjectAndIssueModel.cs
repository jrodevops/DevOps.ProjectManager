namespace DevOps.ProjectManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToProjectAndIssueModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "CreatedById", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Issues", "UpdatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.Projects", "CreatedById", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Projects", "UpdatedById", c => c.String(maxLength: 128));
            CreateIndex("dbo.Issues", "CreatedById");
            CreateIndex("dbo.Issues", "UpdatedById");
            CreateIndex("dbo.Projects", "CreatedById");
            CreateIndex("dbo.Projects", "UpdatedById");
            AddForeignKey("dbo.Issues", "CreatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "CreatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "UpdatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Issues", "UpdatedById", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "UpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "UpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Issues", "CreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "UpdatedById" });
            DropIndex("dbo.Projects", new[] { "CreatedById" });
            DropIndex("dbo.Issues", new[] { "UpdatedById" });
            DropIndex("dbo.Issues", new[] { "CreatedById" });
            DropColumn("dbo.Projects", "UpdatedById");
            DropColumn("dbo.Projects", "CreatedById");
            DropColumn("dbo.Issues", "UpdatedById");
            DropColumn("dbo.Issues", "CreatedById");
        }
    }
}
