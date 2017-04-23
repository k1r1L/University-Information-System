namespace UniversityInformationSystem.App.Areas.Student.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Models.ViewModels.Student;
    using Services.Contracts;

    [RoutePrefix("mandatorycourses")]
    public class MandatoryCoursesController : StudentController
    {
        private IStudentsCoursesService coursesService;

        public MandatoryCoursesController(IStudentsCoursesService coursesService)
        {
            this.coursesService = coursesService;
        }

        
        // GET: Student/MandatoryCourses
        [Route("all")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Courses_Read")]
        public ActionResult Courses_Read([DataSourceRequest] DataSourceRequest request)
        {
            string username = HttpContext.User.Identity.Name;
            IQueryable<MandatoryCourseViewModel> courseVms = this.coursesService.GetAllMandatoryCourses(username);

            return this.Json(courseVms.ToDataSourceResult(request));
        }
    }
}