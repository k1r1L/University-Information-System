namespace UniversityInformationSystem.App.Areas.Student.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.ViewModels.Student;
    using Services.Contracts;

    [RoutePrefix("opencourses")]
    public class OpenCoursesController : StudentController
    {
        private IStudentsCoursesService studentsCoursesService;
        private ICoursesService coursesService;
        private IStudentsService studentsService;

        public OpenCoursesController(IStudentsCoursesService studentsCoursesService, ICoursesService coursesService, IStudentsService studentsService)
        {
            this.studentsCoursesService = studentsCoursesService;
            this.coursesService = coursesService;
            this.studentsService = studentsService;
        }

        
        // GET: Student/OpenCourses
        [Route("all")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Courses_Read")]
        public ActionResult Courses_Read([DataSourceRequest]DataSourceRequest request)
        {
            string username = HttpContext.User.Identity.Name;
            IQueryable<OpenCourseViewModel> courses = this.studentsCoursesService.GetAllOpenCourses(username);

            return this.Json(courses.ToDataSourceResult(request));
        }

        [Route("Courses_Add")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Courses_Add([DataSourceRequest]DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<OpenCourseViewModel> openCourseVms)
        {
            List<OpenCourseViewModel> results = new List<OpenCourseViewModel>();
            if (openCourseVms != null && ModelState.IsValid)
            {
                foreach (OpenCourseViewModel courseVm in openCourseVms)
                {
                    int? courseId = this.coursesService.GetCourseId(courseVm.CourseName);
                    int? studentId = this.studentsService.GetStudentId(HttpContext.User.Identity.Name);
                    if (courseId == null)
                    {
                        this.ModelState.AddModelError("CourseName", "Course does not exist!");
                    }

                    if (studentId == null)
                    {
                        this.ModelState.AddModelError("StudentId", "Student does not exist!");
                    }

                    this.studentsCoursesService.Create(studentId.Value, courseId.Value);
                }
            }

            return this.Json(results.ToDataSourceResult(request, this.ModelState));
        }

        [Route("Courses_Update")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Courses_Update([DataSourceRequest]DataSourceRequest request, 
            [Bind(Prefix = "models")] IEnumerable<OpenCourseViewModel> openCourseVms)
        {
            List<OpenCourseViewModel> results = new List<OpenCourseViewModel>();
            if (ModelState.IsValid)
            {
                // TODO: Add here
            }

            return this.Json(results.ToDataSourceResult(request, this.ModelState));
        }

        [Route("Courses_Destroy")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Courses_Destroy([DataSourceRequest]DataSourceRequest request, 
            [Bind(Prefix = "models")] IEnumerable<OpenCourseViewModel> openCourseVms)
        {
            if (openCourseVms.Any())
            {
                foreach (OpenCourseViewModel course in openCourseVms)
                {
                    this.studentsCoursesService.Delete(course.StudentId, course.CourseId);
                }

            }

            return Json(openCourseVms.ToDataSourceResult(request, this.ModelState));
        }

        [Route("AutocompleteCourses")]
        public ActionResult AutocompleteCourses(string courseName)
        {
            string username = HttpContext.User.Identity.Name;
            var courses =
                this.coursesService.GetAllOpenCourses(username)
                .Where(c => c.ToLower().Contains(courseName.ToLower()))
                .ToArray();

            return this.Json(courses, JsonRequestBehavior.AllowGet);
        }
    }
}