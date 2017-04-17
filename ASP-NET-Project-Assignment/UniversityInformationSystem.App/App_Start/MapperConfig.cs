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
                action.CreateMap<Course, CourseViewModel>()
                    .ForMember(c => c.StudentsCount,
                        configExpression => configExpression.MapFrom(e => e.EnrolledStudents.Count))
                    .ForMember(c => c.IsOpen,
                        configExpression => configExpression.MapFrom(e => e.IsOpen ? "Yes" : "No"))
                    .ForMember(c => c.Teacher, 
                        configExpression => configExpression.MapFrom(e => e.Teacher == null ? "[No Teacher]" : e.Teacher.IdentityUser.UserName));
                action.CreateMap<CourseViewModel, Course>();
            });
        }
    }
}