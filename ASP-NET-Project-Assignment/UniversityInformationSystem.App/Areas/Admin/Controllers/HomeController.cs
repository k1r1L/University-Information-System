namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : AdminController
    {
        // GET: Admin/Home
        [Route("home/index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}