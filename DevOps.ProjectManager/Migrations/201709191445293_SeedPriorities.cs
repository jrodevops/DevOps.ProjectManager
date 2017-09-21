namespace DevOps.ProjectManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedPriorities : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Priorities VALUES ('Low')");
            Sql("INSERT INTO Priorities VALUES ('Medium')");
            Sql("INSERT INTO Priorities VALUES ('High')");
        }
        
        public override void Down()
        {
        }
    }
}
