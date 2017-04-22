namespace UniversityInformationSystem.App.Areas.Student.Controllers
{
    using System.Web.Mvc;

    [RouteArea("student")]
    [Authorize(Roles = "Student")]
    public abstract class StudentController : Controller
    {
    }
}