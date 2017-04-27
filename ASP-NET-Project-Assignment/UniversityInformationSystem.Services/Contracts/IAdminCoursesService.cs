namespace UniversityInformationSystem.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.ViewModels.Admin;

    public interface IAdminCoursesService
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

        IEnumerable<string> GetAllCoursesForStudent(string studentUsername);

        IQueryable<CourseTeacherViewModel> GetAllTeachersForCourses();

        CourseTeacherViewModel GetFirstTeacher();

        bool TeacherExists(string teacherUsername);
    }
}
