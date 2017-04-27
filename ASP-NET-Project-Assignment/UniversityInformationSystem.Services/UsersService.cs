namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels.Users;
    using Models.Enums;
    using Models.ViewModels.Admin;

    public class UsersService : Service, IUsersService
    {
        public UsersService(IUisDataContext dbContext) 
            : base(dbContext)
        {
        }

        public void Register(UserType userType, string appUserId)
        {
            switch (userType)
            {
                case UserType.Student:
                    this.StudentRepository.Add(new Student()
                    {
                        IdenityUserId = appUserId
                    });
                    this.SaveChanges();
                    break;
                case UserType.Teacher:
                    this.TeacherRepository.Add(new Teacher()
                    {
                        IdenityUserId = appUserId
                    });
                    this.SaveChanges();
                    break;
                default:
                    break;
            }
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            return this.ApplicationUserRepository
                .All()
                .Single(u => u.UserName == username);;
        }

        public AdminProfileViewModel GetAdminProfileViewModel(string username)
        {
            ApplicationUser appUser = this.GetUserByUsername(username);

            return Mapper.Map<AdminProfileViewModel>(appUser);
        }

        public IQueryable<UserViewModel> GetAll()
        {
            IEnumerable<ApplicationUser> allUsersInDb = this.ApplicationUserRepository.All();
            IEnumerable<UserViewModel> allUserVms = Mapper.Map<IEnumerable<UserViewModel>>(allUsersInDb);

            return allUserVms.AsQueryable();
        }

        public void Update(UserViewModel userVm, UserManager<ApplicationUser> userManager)
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(this.Context.DbContext);
            ApplicationUser user = this.ApplicationUserRepository.GetById(userVm.Id);
            string newPasswordHashed = userManager.PasswordHasher.HashPassword(userVm.Password);
            userStore.SetPasswordHashAsync(user, newPasswordHashed);
            user.FirstName = userVm.FirstName;
            user.LastName = userVm.LastName;
            this.SaveChanges();
        }
    }
}
