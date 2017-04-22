namespace UniversityInformationSystem.App.Areas.Student.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Models.ViewModels.Student;
    using Services.Contracts;

    [RoutePrefix("home")]
    public class HomeController : StudentController
    {
        private IStudentsService studentsService;

        public HomeController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        
        // GET: Student/Home
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [Route("profile")]
        public ActionResult Profile()
        {
            string username = HttpContext.User.Identity.Name;
            StudentProfileViewModel profileVm = this.studentsService.GetStudentProfileViewModel(username);

            return this.View(profileVm);
        }
    }
}