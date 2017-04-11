namespace UniversityInformationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                        IsOpen = c.Boolean(nullable: false),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.StudentsCourses",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        IsTaken = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacultyNumber = c.String(maxLength: 10),
                        IdentityUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id, cascadeDelete: true)
                .Index(t => t.FacultyNumber, unique: true)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id, cascadeDelete: true)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentsCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentsCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.Teachers", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Students", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Students", new[] { "FacultyNumber" });
            DropIndex("dbo.StudentsCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentsCourses", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "Teacher_Id" });
            DropIndex("dbo.Courses", new[] { "Name" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.StudentsCourses");
            DropTable("dbo.Courses");
        }
    }
}
