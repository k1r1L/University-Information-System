namespace UniversityInformationSystem.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.EntityModels;
    using Models.ViewModels.Admin;

    public interface ICoursesService
    {
        IQueryable<AdminCourseViewModel> GetAll();

        int Create(AdminCourseViewModel courseViewModel);

        void Update(AdminCourseViewModel courseViewModel);

        void Delete(int courseId);

        void AddTeacher(int teacherId, int courseId);

        int? GetCourseId(string courseName);

        int? GetTeacherIdByCourseName(string courseName);

        bool HasTeacher(int courseId);

        IEnumerable<string> GetAllOpenCourses(string studentUsername);
    }
}
