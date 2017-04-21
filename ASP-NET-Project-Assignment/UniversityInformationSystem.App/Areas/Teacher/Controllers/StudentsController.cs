namespace UniversityInformationSystem.App.Areas.Teacher.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.ViewModels.Teacher;
    using Services.Contracts;
    
    [RoutePrefix("students")]
    public class StudentsController : TeacherController
    {
        private ITeacherStudentsService teacherStudentsService;

        public StudentsController(ITeacherStudentsService teacherStudentsService)
        {
            this.teacherStudentsService = teacherStudentsService;
        }

        [Route("all")]
        public ActionResult Index()
        {
            return this.View();
        }

        [Route("StudentCourse_Read")]
        public ActionResult StudentCourse_Read([DataSourceRequest] DataSourceRequest request)
        {
            string teacherName = HttpContext.User.Identity.Name;
            var vms = this.teacherStudentsService.GetAll(teacherName);

            return this.Json(vms.ToDataSourceResult(request));
        }

        [Route("StudentCourse_Update")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StudentCourse_Update([DataSourceRequest] DataSourceRequest request, 
            [Bind(Prefix = "models")]IEnumerable<TeacherStudentCourseViewModel> studentsCourses)
        {
            List<TeacherStudentCourseViewModel> results = new List<TeacherStudentCourseViewModel>();
            if (studentsCourses != null && ModelState.IsValid)
            {
                foreach (TeacherStudentCourseViewModel studentCourse in studentsCourses)
                {
                    this.teacherStudentsService.Update(studentCourse);
                    results.Add(studentCourse);
                }

            }

            return Json(results.ToDataSourceResult(request, this.ModelState));
        }
    }
}