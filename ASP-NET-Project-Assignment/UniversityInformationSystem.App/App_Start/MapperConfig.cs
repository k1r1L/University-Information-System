namespace UniversityInformationSystem.App
{
    using System.Linq;
    using AutoMapper;
    using Models.EntityModels.Users;
    using Models.ViewModels.Account;
    using Models.ViewModels.Admin;

    public class MapperConfig
    {
        public static void ConfigureAutomapper()
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<RegisterViewModel, ApplicationUser>();
                action.CreateMap<ApplicationUser, RegisterSuccessViewModel>();
            });
        }
    }
}