namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels.Users;
    using Models.ViewModels.Admin;
    using Models.ViewModels.Teacher;

    public class UsersService : IUsersService
    {
        private IDbRepository<ApplicationUser> userRepository;

        public UsersService(IDbRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            return this.userRepository
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
            IEnumerable<ApplicationUser> allUsersInDb = this.userRepository.All();
            IEnumerable<UserViewModel> allUserVms = Mapper.Map<IEnumerable<UserViewModel>>(allUsersInDb);

            return allUserVms.AsQueryable();
        }

        public void Update(UserViewModel userVm, UserManager<ApplicationUser> userManager)
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(this.userRepository.Context);
            ApplicationUser user = this.userRepository.GetById(userVm.Id);
            string newPasswordHashed = userManager.PasswordHasher.HashPassword(userVm.Password);
            userStore.SetPasswordHashAsync(user, newPasswordHashed);
            user.FirstName = userVm.FirstName;
            user.LastName = userVm.LastName;
            this.userRepository.SaveChanges();
        }
    }
}
