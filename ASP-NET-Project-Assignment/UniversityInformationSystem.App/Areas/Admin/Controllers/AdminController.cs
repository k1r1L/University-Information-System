namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Models.EntityModels;
    using Models.ViewModels.Account;
    using Services;

    [RouteArea("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        
    }
}