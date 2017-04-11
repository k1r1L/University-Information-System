namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    [RouteArea("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        
    }
}