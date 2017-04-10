namespace UniversityInformationSystem.App.Areas.Admin
{
    using System.Web.Mvc;

    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Admin_default",
                url: "Admin/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional},
                namespaces: new string[] { "UniversityInformationSystem.App.Areas.Admin.Controllers" });
        }
    }
}