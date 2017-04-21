namespace UniversityInformationSystem.Services.Contracts
{
    using System.Linq;
    using Models.ViewModels.Teacher;

    public interface ITeacherStudentsService
    {
        IQueryable<TeacherStudentCourseViewModel> GetAll(string teacherName);

        void Update(TeacherStudentCourseViewModel vm);
    }
}
