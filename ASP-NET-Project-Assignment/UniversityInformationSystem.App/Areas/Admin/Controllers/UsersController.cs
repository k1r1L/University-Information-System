namespace UniversityInformationSystem.App.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Models.EntityModels;
    using Models.EntityModels.Users;
    using Models.Enums;
    using Models.ViewModels.Account;
    using Models.ViewModels.Admin;
    using Services;
    using Services.Contracts;

    [RoutePrefix("users")]
    public class UsersController : AdminController
    {
        private ApplicationUserManager _userManager;
        private IRegisterService registerService;

        // TODO: Inject userManager
        public UsersController(IRegisterService registerService)
        {
            this.UserManager = new ApplicationUserManager(
                new UserStore<ApplicationUser>(new UisDataContext()));
            this.registerService = registerService;
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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}