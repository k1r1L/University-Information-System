using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityInformationSystem.App.Areas.Teacher.Controllers
{
    [RouteArea("Teacher")]
    [Authorize(Roles = "Teacher")]
    public abstract class TeacherController : Controller
    {
        
    }
}