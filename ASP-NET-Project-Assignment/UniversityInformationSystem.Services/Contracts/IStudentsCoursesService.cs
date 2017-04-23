namespace UniversityInformationSystem.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.EntityModels;
    using Models.ViewModels.Admin;
    using Models.ViewModels.Student;

    public interface IStudentsCoursesService
    {
        IQueryable<AdminStudentCourseViewModel> GetAll();

        IQueryable<MandatoryCourseViewModel> GetAllMandatoryCourses(string studentUsername);

        IQueryable<OpenCourseViewModel> GetAllOpenCourses(string studentUsername);

        void Create(int studentId, int courseId);

        void Delete(int studentId, int courseId);
    }
}
