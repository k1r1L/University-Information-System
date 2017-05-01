namespace UniversityInformationSystem.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Models.EntityModels.Users;
    using Models.Enums;
    using Models.ViewModels.Admin;
    using Models.ViewModels.Teacher;

    public interface IUsersService
    {
        void Register(UserType userType, string appUserId);

        ApplicationUser GetUserByUsername(string username);

        AdminProfileViewModel GetAdminProfileViewModel(string username);

        IQueryable<UserViewModel> GetAll();

        bool UserExists(string userId);

        void Update(UserViewModel userVm, UserManager<ApplicationUser> userManager);

        // TODO: Think about that
        void Delete(string userId);

    }
}
