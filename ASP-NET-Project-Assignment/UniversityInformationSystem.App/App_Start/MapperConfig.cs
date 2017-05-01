namespace UniversityInformationSystem.App
{
    using System.Linq;
    using AutoMapper;
    using Models.EntityModels;
    using Models.EntityModels.Users;
    using Models.Enums;
    using Models.ViewModels.Account;
    using Models.ViewModels.Admin;
    using Models.ViewModels.Messages;
    using Models.ViewModels.Student;
    using Models.ViewModels.Teacher;

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
                action.CreateMap<Course, AdminCourseViewModel>()
                    .ForMember(c => c.StudentsCount,
                        configExpression => configExpression.MapFrom(e => e.EnrolledStudents.Count))
                    .ForMember(c => c.IsOpen,
                        configExpression => configExpression.MapFrom(e => e.IsOpen ? "Yes" : "No"));
                action.CreateMap<AdminCourseViewModel, Course>()
                    .ForMember(c => c.Teacher, config => config.Ignore());
                action.CreateMap<StudentCourse, AdminStudentCourseViewModel>()
                    .ForMember(vm => vm.CourseName, configExpression => configExpression.MapFrom(e => e.Course.Name))
                    .ForMember(vm => vm.StudentUsername,
                        configExpression => configExpression.MapFrom(e => e.Student.IdentityUser.UserName))
                    .ForMember(vm => vm.StudentId, configExpression => configExpression.MapFrom(e => e.StudentId))
                    .ForMember(vm => vm.CourseId, configExpression => configExpression.MapFrom(e => e.CourseId));
                action.CreateMap<ApplicationUser, AdminProfileViewModel>();
                action.CreateMap<Course, TeacherCourseViewModel>()
                    .ForMember(c => c.StudentsCount,
                        configExpression => configExpression.MapFrom(e => e.EnrolledStudents.Count));
                action.CreateMap<StudentCourse, TeacherStudentCourseViewModel>()
                    .ForMember(vm => vm.CourseName, configExpression => configExpression.MapFrom(e => e.Course.Name))
                    .ForMember(vm => vm.StudentUsername,
                        configExpression => configExpression.MapFrom(e => e.Student.IdentityUser.UserName))
                    .ForMember(vm => vm.StudentId, configExpression => configExpression.MapFrom(e => e.StudentId))
                    .ForMember(vm => vm.CourseId, configExpression => configExpression.MapFrom(e => e.CourseId))
                    .ForMember(vm => vm.Grade, configExpression => configExpression.MapFrom(e => e.Grade));
                action.CreateMap<ApplicationUser, UserViewModel>()
                    .ForMember(vm => vm.Id, configExpression => configExpression.MapFrom(e => e.Id))
                    .ForMember(vm => vm.FirstName, configExpression => configExpression.MapFrom(e => e.FirstName))
                    .ForMember(vm => vm.LastName, configExpression => configExpression.MapFrom(e => e.LastName))
                    .ForMember(vm => vm.UserName, configExpression => configExpression.MapFrom(e => e.UserName))
                    .ForMember(vm => vm.Password, configExpression => configExpression.Ignore())
                    .ForMember(vm => vm.PasswordConfirmed, configExpression => configExpression.Ignore());
                action.CreateMap<Teacher, TeacherProfileViewModel>()
                    .ForMember(vm => vm.LeadingCoursesCount,
                        configExpression => configExpression.MapFrom(e => e.LeadingCourses.Count))
                    .ForMember(vm => vm.StudentsCount,
                        configExpression =>
                                configExpression.MapFrom(e => e.LeadingCourses.Sum(c => c.EnrolledStudents.Count)))
                    .ForMember(vm => vm.FirstName,
                        configExpression => configExpression.MapFrom(e => e.IdentityUser.FirstName))
                    .ForMember(vm => vm.LastName,
                        configExpression => configExpression.MapFrom(e => e.IdentityUser.LastName))
                    .ForMember(vm => vm.UserName,
                        configExpression => configExpression.MapFrom(e => e.IdentityUser.UserName))
                    .ForMember(vm => vm.BirthDate,
                        configExpression => configExpression.MapFrom(e => e.IdentityUser.BirthDate));
                action.CreateMap<Student, StudentProfileViewModel>()
                    .ForMember(vm => vm.FirstName,
                        configExpression => configExpression.MapFrom(e => e.IdentityUser.FirstName))
                    .ForMember(vm => vm.LastName,
                        configExpression => configExpression.MapFrom(e => e.IdentityUser.LastName))
                    .ForMember(vm => vm.UserName,
                        configExpression => configExpression.MapFrom(e => e.IdentityUser.UserName))
                    .ForMember(vm => vm.BirthDate,
                        configExpression => configExpression.MapFrom(e => e.IdentityUser.BirthDate))
                    .ForMember(vm => vm.MandatoryCoursesCount,
                        configExpression =>
                            configExpression.MapFrom(e => e.EnrolledCourses.Count(c => !c.Course.IsOpen)))
                    .ForMember(vm => vm.OpenCoursesCount,
                        configExpression => configExpression.MapFrom(e => e.EnrolledCourses.Count(c => c.Course.IsOpen)))
                    .ForMember(vm => vm.TakenCoursesCount,
                        configExpression =>
                            configExpression.MapFrom(e => e.EnrolledCourses.Count(c => c.Grade != Grade.F)))
                    .ForMember(vm => vm.UnTakenCoursesCount,
                        configExpression =>
                            configExpression.MapFrom(e => e.EnrolledCourses.Count(c => c.Grade == Grade.F)))
                    .ForMember(vm => vm.TotalCredits,
                        configExpression =>
                            configExpression.MapFrom(e => e.EnrolledCourses.Where(c => c.Grade != Grade.F)
                            .Sum(c => c.Course.Credits)));
                action.CreateMap<StudentCourse, MandatoryCourseViewModel>()
                    .ForMember(vm => vm.CourseName, configExpression => configExpression.MapFrom(e => e.Course.Name))
                    .ForMember(vm => vm.TeacherUsername,
                        configExpression => configExpression.MapFrom(e => e.Course.Teacher.IdentityUser.UserName));
                action.CreateMap<StudentCourse, OpenCourseViewModel>()
                 .ForMember(vm => vm.CourseName, configExpression => configExpression.MapFrom(e => e.Course.Name))
                 .ForMember(vm => vm.TeacherUsername,
                     configExpression => configExpression.MapFrom(e => e.Course.Teacher.IdentityUser.UserName));
                action.CreateMap<Message, InboxMessageViewModel>()
                    .ForMember(vm => vm.SenderUsername,
                        configExpression => configExpression.MapFrom(e => e.Sender.UserName));
            });
        }
    }
}