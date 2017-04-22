namespace UniversityInformationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseCredits : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Credits", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Credits");
        }
    }
}
