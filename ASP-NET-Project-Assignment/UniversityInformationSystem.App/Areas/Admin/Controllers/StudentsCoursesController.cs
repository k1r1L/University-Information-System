namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
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
            AdminStudentCourseViewModel viewModel)
        {
            int? studentId = this.studentsService.GetStudentId(viewModel.StudentUsername);
            int? courseId = this.coursesService.GetCourseId(viewModel.CourseName);

            if (studentId == null)
            {
                this.ModelState.AddModelError("StudentUsername", "No such student!");
            }

            if (courseId == null)
            {
                this.ModelState.AddModelError("CourseName", "No such course!");
            }

            if (courseId != null && !this.coursesService.HasTeacher(courseId.Value))
            {
                this.ModelState.AddModelError("CourseName", "The given course has no trainer yet!");

            }

            if (this.ModelState.IsValid)
            {
                this.studentsCoursesService.Create(studentId.Value, courseId.Value);
            }

            return Json(new[] { viewModel }.ToDataSourceResult(request, this.ModelState));
        }

        [Route("StudentCourse_Destroy")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StudentCourse_Destroy([DataSourceRequest] DataSourceRequest request,
            AdminStudentCourseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                this.studentsCoursesService.Delete(viewModel.StudentId, viewModel.CourseId);
            }

            return Json(new[] {viewModel}.ToDataSourceResult(request, this.ModelState));
        }

    }
}