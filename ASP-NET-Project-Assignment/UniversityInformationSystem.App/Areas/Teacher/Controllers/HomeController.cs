namespace UniversityInformationSystem.App.Areas.Teacher.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [RoutePrefix("home")]
    public class HomeController : TeacherController
    {
        // GET: Teacher/Home
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}