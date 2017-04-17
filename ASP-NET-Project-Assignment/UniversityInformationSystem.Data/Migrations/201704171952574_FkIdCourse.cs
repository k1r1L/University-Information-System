namespace UniversityInformationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FkIdCourse : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Courses", name: "Teacher_Id", newName: "TeacherId");
            RenameIndex(table: "dbo.Courses", name: "IX_Teacher_Id", newName: "IX_TeacherId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Courses", name: "IX_TeacherId", newName: "IX_Teacher_Id");
            RenameColumn(table: "dbo.Courses", name: "TeacherId", newName: "Teacher_Id");
        }
    }
}
