namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Utillities;
    using Models.ViewModels.Admin;
    using Services.Contracts;

    [RoutePrefix("studentscourses")]
    public class StudentsCoursesController : AdminController
    {
        private IStudentsCoursesService studentsCoursesService;
        private IStudentsService studentsService;
        private ICoursesService coursesService;

        public StudentsCoursesController(IStudentsCoursesService studentsCoursesService, IStudentsService studentsService, ICoursesService coursesService)
        {
            this.studentsCoursesService = studentsCoursesService;
            this.studentsService = studentsService;
            this.coursesService = coursesService;
        }

        [Route("all")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("StudentCourse_Read")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StudentCourse_Read([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<AdminStudentCourseViewModel> allVms = this.studentsCoursesService.GetAll();

            return Json(allVms.ToDataSourceResult(request));
        }

        [Route("StudentCourse_Create")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StudentCourse_Create([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")]IEnumerable<AdminStudentCourseViewModel> viewModels)
        {
            List<AdminStudentCourseViewModel> results = new List<AdminStudentCourseViewModel>();
            if (viewModels != null && this.ModelState.IsValid)
            {
                foreach (AdminStudentCourseViewModel studentCourseViewModel in viewModels)
                {
                    int? studentId = this.studentsService.GetStudentId(studentCourseViewModel.StudentUsername);
                    int? courseId = this.coursesService.GetCourseId(studentCourseViewModel.CourseName);
                    if (!this.studentsCoursesService.AlreadyEnrolled(studentId, courseId))
                    {
                        this.studentsCoursesService.Create(studentId.Value, courseId.Value);
                    }

                    results.Add(studentCourseViewModel);
                }
            }

            return Json(results.ToDataSourceResult(request, this.ModelState));
        }

        [Route("StudentCourse_Update")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StudentCourse_Update([DataSourceRequest] DataSourceRequest request,
          [Bind(Prefix = "models")]IEnumerable<AdminStudentCourseViewModel> viewModels)
        {
            List<AdminStudentCourseViewModel> results = new List<AdminStudentCourseViewModel>();
            if (viewModels != null && this.ModelState.IsValid)
            {
                // TODO: Implement this
            }

            return Json(results.ToDataSourceResult(request, this.ModelState));
        }

        [Route("StudentCourse_Destroy")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StudentCourse_Destroy([DataSourceRequest] DataSourceRequest request,
           [Bind(Prefix = "models")]IEnumerable<AdminStudentCourseViewModel> viewModels)
        {
            List<AdminStudentCourseViewModel> results = new List<AdminStudentCourseViewModel>();
            if (viewModels != null && this.ModelState.IsValid)
            {
                foreach (AdminStudentCourseViewModel studentCourseViewModel in viewModels)
                {
                    this.studentsCoursesService.Delete(studentCourseViewModel.StudentId, studentCourseViewModel.CourseId);
                }
            }

            return Json(results.ToDataSourceResult(request, this.ModelState));
        }

        [Route("GetAllStudents")]
        public ActionResult GetAllStudents(string username)
        {
            if (username == null)
            {
                return this.RedirectToAction("Index");
            }

            string[] studentUsernames = this.studentsService
                .GetAllStudentUsernames()
                .Where(u => u.ToLower().Contains(username.ToLower()))
                .ToArray();

            return this.Json(studentUsernames, JsonRequestBehavior.AllowGet);
        }

        [Route("GetAllCoursesForStudent")]
        public ActionResult GetAllCoursesForStudent(string courseName, string username)
        {
            if (courseName == null)
            {
                return this.RedirectToAction("Index");
            }

            string[] allCoursesForStudents = this.coursesService
                .GetAllCoursesForStudent(username)
                .Where(c => c.ToLower().Contains(courseName.ToLower()))
                .ToArray();

            return this.Json(allCoursesForStudents, JsonRequestBehavior.AllowGet);
        }
    }
}