namespace UniversityInformationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityInformationSystem.Data.UisDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "UniversityInformationSystem.Data.UisDataContext";
        }

        protected override void Seed(UisDataContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Administrator"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Administrator"));
            }

            if (!context.Roles.Any(role => role.Name == "Teacher"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Teacher"));
            }

            if (!context.Roles.Any(role => role.Name == "Student"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Student"));
            }

            if (!context.Users.Any())
            {
                var firstUser = new ApplicationUser()
                {
                    UserName = "kirilvk1",
                    Email = "kiril.98.kirilov@gmail.com",
                    PhoneNumber = "0895964686",
                    FirstName = "Kiril",
                    LastName = "Kirilov",
                    BirthDate = new DateTime(1996, 1, 6)
                };
                var userManager = new UserManager<ApplicationUser>
                    (new UserStore<ApplicationUser>(context));
                userManager.Create(firstUser, "");
                userManager.AddToRole(firstUser.Id, "Administrator");
            }
        }
    }
}
