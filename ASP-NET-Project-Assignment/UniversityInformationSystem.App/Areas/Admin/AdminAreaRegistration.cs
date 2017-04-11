namespace UniversityInformationSystem.App.Areas.Admin
{
    using System.Web.Mvc;

    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //context.MapRoute(
            //    name: "Admin_default",
            //    url: "Home/{action}",
            //    defaults: new { controller = "Home", action = "Index" },
            //    namespaces: new string[] { "UniversityInformationSystem.App.Areas.Admin.Controllers" })
            //    .DataTokens.Add("Admin", "Admin");

            //context.MapRoute(
            //    name: "Admin Users",
            //    url: "Users/{action}/{id}",
            //    defaults: new { controller = "Users", action = "Register", id = UrlParameter.Optional },
            //    namespaces: new string[] { "UniversityInformationSystem.App.Areas.Admin.Controllers" })
            //    .DataTokens.Add("Admin", "Admin");
        }
    }
}