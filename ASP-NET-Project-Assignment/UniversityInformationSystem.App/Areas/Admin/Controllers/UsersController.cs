namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Models.EntityModels.Users;
    using Models.Enums;
    using Models.ViewModels.Account;
    using Models.ViewModels.Admin;
    using Services.Contracts;

    [RoutePrefix("users")]
    public class UsersController : AdminController
    {
        private ApplicationUserManager _userManager;
        private IRegisterService registerService;
        private IUsersService usersService;

        // TODO: Inject userManager
        public UsersController(IRegisterService registerService, IUsersService usersService ,UisDataContext dbContext)
        {
            this.UserManager = new ApplicationUserManager(
                new UserStore<ApplicationUser>(dbContext));
            this.registerService = registerService;
            this.usersService = usersService;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        [Route("register")]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [Route("register")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = Mapper.Map<ApplicationUser>(model);

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    switch (model.UserType)
                    {
                        case UserType.Administrator:
                            this.UserManager.AddToRole(user.Id, "Administrator");
                            break;
                        case UserType.Teacher:
                            this.UserManager.AddToRole(user.Id, "Teacher");
                            break;
                        case UserType.Student:
                            this.UserManager.AddToRole(user.Id, "Student");
                            break;
                        default:
                            throw new ArgumentException("Invalid Role!");
                    }

                    this.registerService.Register(model.UserType, user.Id);

                    var successfulRegisterVm = Mapper.Map<RegisterSuccessViewModel>(user);
                    successfulRegisterVm.UserType = model.UserType;
                    return View("SuccessfulRegister", successfulRegisterVm);
                }

                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [Route("all")]
        public ActionResult Index()
        {
            return this.View();
        }

        [Route("Users_Read")]
        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<UserViewModel> userVms = this.usersService.GetAll();

            return this.Json(userVms.ToDataSourceResult(request));
        }

        [Route("Users_Update")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, UserViewModel userVm)
        {
            if (userVm != null && this.ModelState.IsValid)
            {
                if (userVm.Password != userVm.PasswordConfirmed)
                {
                    this.usersService.Update(userVm.Id, userVm.Password, this.UserManager);
                }
                else
                {
                    this.ModelState.AddModelError("Password", "The passwords do not match!");
                    return this.Json(request);
                }
            }

            return this.Json(new [] { userVm }.ToDataSourceResult(request, this.ModelState));
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}