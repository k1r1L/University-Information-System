namespace UniversityInformationSystem.Services.Contracts
{
    using System.Linq;
    using Models.ViewModels.Teacher;

    public interface ITeacherCoursesService
    {
        IQueryable<TeacherCourseViewModel> GetAll(string teacherUsername);

        void Update(TeacherCourseViewModel vm);
    }
}
