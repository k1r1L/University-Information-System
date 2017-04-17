namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
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
        private IAdminTeachersService teachersService;

        public CoursesController(IAdminCoursesService coursesService, IAdminTeachersService teachersService)
        {
            this.coursesService = coursesService;
            this.teachersService = teachersService;
        }

        [Route("all")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("CourseViewModels_Read")]
        public ActionResult CourseViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<CourseViewModel> courseviewmodels = this.coursesService.GetAll();
           
            return Json(courseviewmodels.ToDataSourceResult(request));
        }

        [Route("CourseViewModels_Create")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourseViewModels_Create([DataSourceRequest]DataSourceRequest request, CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                this.coursesService.Create(courseViewModel);
            }

            return Json(new[] { courseViewModel }.ToDataSourceResult(request, ModelState));
        }

        [Route("CourseViewModels_Update")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourseViewModels_Update([DataSourceRequest]DataSourceRequest request, CourseViewModel courseViewModel, string teacher)
        {
            if (this.teachersService.TeacherExists(teacher))
            {
                this.coursesService.AddTeacher(this.teachersService.GetTeacherId(teacher), courseViewModel.Id);
            }
            else
            {
                this.ModelState.AddModelError("Teacher", "The teacher does not exist!");
            }

            if (ModelState.IsValid)
            {
                this.coursesService.Update(courseViewModel);
            }

            return Json(new[] { courseViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        [Route("CourseViewModels_Destroy")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourseViewModels_Destroy([DataSourceRequest]DataSourceRequest request, CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                this.coursesService.Delete(courseViewModel.Id);
            }

            return Json(new[] { courseViewModel }.ToDataSourceResult(request, ModelState));
        }
    }
}
