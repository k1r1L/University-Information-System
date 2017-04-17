namespace UniversityInformationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserModelAgain : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Students", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Teachers", new[] { "IdentityUser_Id" });
            DropColumn("dbo.Students", "IdenityUserId");
            DropColumn("dbo.Teachers", "IdenityUserId");
            RenameColumn(table: "dbo.Students", name: "IdentityUser_Id", newName: "IdenityUserId");
            RenameColumn(table: "dbo.Teachers", name: "IdentityUser_Id", newName: "IdenityUserId");
            AlterColumn("dbo.Students", "IdenityUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Teachers", "IdenityUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Students", "IdenityUserId");
            CreateIndex("dbo.Teachers", "IdenityUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Teachers", new[] { "IdenityUserId" });
            DropIndex("dbo.Students", new[] { "IdenityUserId" });
            AlterColumn("dbo.Teachers", "IdenityUserId", c => c.String());
            AlterColumn("dbo.Students", "IdenityUserId", c => c.String());
            RenameColumn(table: "dbo.Teachers", name: "IdenityUserId", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.Students", name: "IdenityUserId", newName: "IdentityUser_Id");
            AddColumn("dbo.Teachers", "IdenityUserId", c => c.String());
            AddColumn("dbo.Students", "IdenityUserId", c => c.String());
            CreateIndex("dbo.Teachers", "IdentityUser_Id");
            CreateIndex("dbo.Students", "IdentityUser_Id");
        }
    }
}
