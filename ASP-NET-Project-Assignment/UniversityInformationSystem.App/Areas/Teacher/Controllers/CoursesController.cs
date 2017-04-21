namespace UniversityInformationSystem.App.Areas.Teacher.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.ViewModels.Teacher;
    using Services.Contracts;

    [RoutePrefix("courses")]
    public class CoursesController : TeacherController
    {
        private ITeacherCoursesService coursesService;

        public CoursesController(ITeacherCoursesService coursesService)
        {
            this.coursesService = coursesService;
        }

        
        [Route("all")]
        public ActionResult Index()
        {
            return this.View();
        }

        [Route("Courses_Read")]
        public ActionResult Courses_Read([DataSourceRequest] DataSourceRequest request)
        {
            string teacherUsername = HttpContext.User.Identity.Name;
            IQueryable<TeacherCourseViewModel> courses = this.coursesService.GetAll(teacherUsername);

            return this.Json(courses.ToDataSourceResult(request));
        }

        [Route("Courses_Update")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Courses_Update([DataSourceRequest] DataSourceRequest request
            , [Bind(Prefix = "models")]IEnumerable<TeacherCourseViewModel> courses)
        {
            List<TeacherCourseViewModel> results = new List<TeacherCourseViewModel>();
            if (courses != null && ModelState.IsValid)
            {
                foreach (TeacherCourseViewModel course in courses)
                {
                    this.coursesService.Update(course);
                    results.Add(course);
                }

            }

            return Json(results.ToDataSourceResult(request, this.ModelState));
        }
    }
}