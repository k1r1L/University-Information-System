namespace UniversityInformationSystem.App
{
    using System.Linq;
    using AutoMapper;
    using Models.EntityModels;
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
                action.CreateMap<Teacher, CourseTeacherViewModel>()
                    .ForMember(ct => ct.UserName,
                        configExpression => configExpression.MapFrom(e => e.IdentityUser.UserName));
                action.CreateMap<Course, CourseViewModel>()
                    .ForMember(c => c.StudentsCount,
                        configExpression => configExpression.MapFrom(e => e.EnrolledStudents.Count))
                    .ForMember(c => c.IsOpen,
                        configExpression => configExpression.MapFrom(e => e.IsOpen ? "Yes" : "No"));
                action.CreateMap<CourseViewModel, Course>()
                    .ForMember(c => c.Teacher, config => config.Ignore());
            });
        }
    }
}