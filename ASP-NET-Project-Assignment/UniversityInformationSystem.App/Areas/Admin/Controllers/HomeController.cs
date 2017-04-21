namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Models.ViewModels.Admin;
    using Services.Contracts;

    [RoutePrefix("home")]
    public class HomeController : AdminController
    {
        private IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        
        // GET: Admin/Home
        [Route("index")]
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