namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Models.ViewModels.Admin;
    using Services.Contracts;

    [RoutePrefix("home")]
    public class HomeController : AdminController
    {
        private IUsersService userService;

        public HomeController(IUsersService userService)
        {
            this.userService = userService;
        }

        
        // GET: Admin/Home
        [Route]
        public ActionResult Index()
        {
            return this.View();
        }

        [Route("profile")]
        public ActionResult Profile()
        {
            string username = HttpContext.User.Identity.Name;
            AdminProfileViewModel profileVm = this.userService.GetAdminProfileViewModel(username);

            return this.View(profileVm);
        }
    }
}