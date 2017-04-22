namespace UniversityInformationSystem.Services.Contracts
{
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Models.EntityModels.Users;
    using Models.ViewModels.Admin;
    using Models.ViewModels.Teacher;

    public interface IUsersService
    {
        ApplicationUser GetUserByUsername(string username);

        AdminProfileViewModel GetAdminProfileViewModel(string username);

        IQueryable<UserViewModel> GetAll();

        void Update(string userId, string newPassword, UserManager<ApplicationUser> userManager);

        // TODO: Think about that
        //void Delete(string userId);
    }
}
