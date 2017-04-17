namespace UniversityInformationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Teachers", "IdentityUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Teachers", new[] { "IdentityUser_Id" });
            AddColumn("dbo.Students", "IdenityUserId", c => c.String());
            AddColumn("dbo.Teachers", "IdenityUserId", c => c.String());
            AlterColumn("dbo.Students", "IdentityUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Teachers", "IdentityUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Students", "IdentityUser_Id");
            CreateIndex("dbo.Teachers", "IdentityUser_Id");
            AddForeignKey("dbo.Students", "IdentityUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Teachers", "IdentityUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "IdentityUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Teachers", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Students", new[] { "IdentityUser_Id" });
            AlterColumn("dbo.Teachers", "IdentityUser_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Students", "IdentityUser_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Teachers", "IdenityUserId");
            DropColumn("dbo.Students", "IdenityUserId");
            CreateIndex("dbo.Teachers", "IdentityUser_Id");
            CreateIndex("dbo.Students", "IdentityUser_Id");
            AddForeignKey("dbo.Teachers", "IdentityUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "IdentityUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
