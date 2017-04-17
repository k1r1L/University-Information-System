namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    [RouteArea("admin")]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        
    }
}