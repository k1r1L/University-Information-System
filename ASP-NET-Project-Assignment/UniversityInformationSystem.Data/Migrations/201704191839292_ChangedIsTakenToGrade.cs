namespace UniversityInformationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedIsTakenToGrade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentsCourses", "Grade", c => c.Int(nullable: false));
            DropColumn("dbo.StudentsCourses", "IsTaken");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentsCourses", "IsTaken", c => c.Boolean(nullable: false));
            DropColumn("dbo.StudentsCourses", "Grade");
        }
    }
}
