namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using UniversityInformationSystem.Models.ViewModels.Admin;
    using Services.Contracts;

    [RoutePrefix("courses")]
    public class CoursesController : AdminController
    {
        private ICoursesService coursesService;
        private ITeachersService teachersService;

        public CoursesController(ICoursesService coursesService, ITeachersService teachersService)
        {
            this.coursesService = coursesService;
            this.teachersService = teachersService;
        }

        [Route("all")]
        public ActionResult Index()
        {
            ViewData["teachers"] = this.teachersService.GetAllTeachersForCourses();
            ViewData["defaultTeacher"] = this.teachersService.GetFirst();

            return View();
        }

        [Route("CourseViewModels_Read")]
        public ActionResult CourseViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<AdminCourseViewModel> courseviewmodels = this.coursesService.GetAll();
           
            return Json(courseviewmodels.ToDataSourceResult(request));
        }

        [Route("CourseViewModels_Create")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourseViewModels_Create([DataSourceRequest]DataSourceRequest request, 
            [Bind(Prefix = "models")]IEnumerable<AdminCourseViewModel> courses)
        {
            List<AdminCourseViewModel> results = new List<AdminCourseViewModel>();
            if (courses != null && ModelState.IsValid)
            {
                foreach (AdminCourseViewModel course in courses)
                {
                    int teacherId = course.Teacher.Id;
                    int courseId = this.coursesService.Create(course);

                    if (this.teachersService.TeacherExists(course.Teacher.UserName))
                    {
                        this.coursesService.AddTeacher(teacherId, courseId);
                    }

                    results.Add(course);
                }

            }

            return Json(results.ToDataSourceResult(request, this.ModelState));
        }

        [Route("CourseViewModels_Update")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourseViewModels_Update([DataSourceRequest]DataSourceRequest request, 
            [Bind(Prefix = "models")]IEnumerable<AdminCourseViewModel> courses)
        {
            List<AdminCourseViewModel> results = new List<AdminCourseViewModel>();
            if (courses!= null && ModelState.IsValid)
            {
                foreach (AdminCourseViewModel course in courses)
                {
                    if (this.teachersService.TeacherExists(course.Teacher.UserName))
                    {
                        this.coursesService.AddTeacher(course.Teacher.Id, course.Id);
                    }

                    this.coursesService.Update(course);
                    results.Add(course);
                }

            }

            return Json(results.ToDataSourceResult(request, this.ModelState));
        }

        [Route("CourseViewModels_Destroy")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourseViewModels_Destroy([DataSourceRequest]DataSourceRequest request,
            [Bind(Prefix = "models")]IEnumerable<AdminCourseViewModel> courses)
        {
            if (courses.Any())
            {
                foreach (AdminCourseViewModel course in courses)
                {
                    this.coursesService.Delete(course.Id);
                }

            }

            return Json(courses.ToDataSourceResult(request, this.ModelState));
        }
    }
}
