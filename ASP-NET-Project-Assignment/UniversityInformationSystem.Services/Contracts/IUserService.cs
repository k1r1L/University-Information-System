namespace UniversityInformationSystem.Services.Contracts
{
    using Models.EntityModels.Users;
    using Models.ViewModels.Admin;

    public interface IUserService
    {
        ApplicationUser GetUserByUsername(string username);
        AdminProfileViewModel GetAdminProfileViewModel(string username);
    }
}
