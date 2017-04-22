namespace UniversityInformationSystem.App.Areas.Teacher.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Models.ViewModels.Teacher;
    using Services.Contracts;

    [RoutePrefix("home")]
    public class HomeController : TeacherController
    {
        private ITeachersService teachersService;

        public HomeController(ITeachersService teachersService)
        {
            this.teachersService = teachersService;
        }

        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("profile")]
        public ActionResult Profile()
        {
            string username = HttpContext.User.Identity.Name;
            TeacherProfileViewModel profileVm = this.teachersService.GetTeacherProfileViewModel(username);

            return View(profileVm);
        }
    }
}