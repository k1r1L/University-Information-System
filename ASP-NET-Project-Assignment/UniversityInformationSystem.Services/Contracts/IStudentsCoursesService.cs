namespace UniversityInformationSystem.Services.Contracts
{
    using System.Linq;
    using Models.EntityModels;
    using Models.ViewModels.Admin;

    public interface IStudentsCoursesService
    {
        IQueryable<AdminStudentCourseViewModel> GetAll();

        void Create(int studentId, int courseId);

        void Delete(int studentId, int courseId);
    }
}
