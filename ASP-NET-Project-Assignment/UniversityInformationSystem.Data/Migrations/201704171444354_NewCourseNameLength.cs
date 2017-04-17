namespace UniversityInformationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewCourseNameLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
