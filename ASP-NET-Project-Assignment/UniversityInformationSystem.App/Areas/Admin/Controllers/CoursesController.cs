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
        private IAdminCoursesService coursesService;

        public CoursesController(IAdminCoursesService coursesService)
        {
            this.coursesService = coursesService;
        }

        [Route("all")]
        public ActionResult Index()
        {
            ViewData["teachers"] = this.coursesService.GetAllTeachersForCourses();
            ViewData["defaultTeacher"] = this.coursesService.GetFirstTeacher();

            return View();
        }

        [Route("read")]
        public ActionResult CourseViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<AdminCourseViewModel> courseviewmodels = this.coursesService.GetAll();
           
            return Json(courseviewmodels.ToDataSourceResult(request));
        }

        [Route("create")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourseViewModels_Create([DataSourceRequest]DataSourceRequest request, 
            [Bind(Prefix = "models")]IEnumerable<AdminCourseViewModel> courses)
        {
            List<AdminCourseViewModel> results = new List<AdminCourseViewModel>();
            if (courses != null)
            {
                foreach (AdminCourseViewModel course in courses)
                {
                    int courseId = this.coursesService.Create(course);

                    if (course.Teacher != null)
                    {
                        int teacherId = course.Teacher.Id;
                        if (this.coursesService.TeacherExists(course.Teacher.UserName))
                        {
                            this.coursesService.AddTeacher(teacherId, courseId);
                        }

                    }

                    results.Add(course);
                }

            }

            return Json(results.ToDataSourceResult(request, this.ModelState));
        }

        [Route("update")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourseViewModels_Update([DataSourceRequest]DataSourceRequest request, 
            [Bind(Prefix = "models")]IEnumerable<AdminCourseViewModel> courses)
        {
            List<AdminCourseViewModel> results = new List<AdminCourseViewModel>();
            if (courses!= null && ModelState.IsValid)
            {
                foreach (AdminCourseViewModel course in courses)
                {
                    if (this.coursesService.TeacherExists(course.Teacher.UserName))
                    {
                        this.coursesService.AddTeacher(course.Teacher.Id, course.Id);
                    }

                    this.coursesService.Update(course);
                    results.Add(course);
                }

            }

            return Json(results.ToDataSourceResult(request, this.ModelState));
        }

        [Route("destroy")]
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
