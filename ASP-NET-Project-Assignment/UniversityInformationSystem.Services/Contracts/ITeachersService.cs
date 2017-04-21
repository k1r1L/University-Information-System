namespace UniversityInformationSystem.Services.Contracts
{
    using System.Linq;
    using Models.ViewModels.Admin;

    public interface ITeachersService
    {
        bool TeacherExists(string teacherUsername);

        int? GetTeacherId(string teacherUsername);

        IQueryable<CourseTeacherViewModel> GetAllTeachersForCourses();

        CourseTeacherViewModel GetFirst();
    }
}
