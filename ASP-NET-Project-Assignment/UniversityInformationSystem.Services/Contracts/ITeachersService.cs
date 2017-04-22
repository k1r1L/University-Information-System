namespace UniversityInformationSystem.Services.Contracts
{
    using System.Linq;
    using Models.EntityModels.Users;
    using Models.ViewModels.Admin;
    using Models.ViewModels.Teacher;

    public interface ITeachersService
    {
        Teacher GetTeacherByUsername(string username);

        bool TeacherExists(string teacherUsername);

        int? GetTeacherId(string teacherUsername);

        IQueryable<CourseTeacherViewModel> GetAllTeachersForCourses();

        CourseTeacherViewModel GetFirst();

        TeacherProfileViewModel GetTeacherProfileViewModel(string username);

    }
}
