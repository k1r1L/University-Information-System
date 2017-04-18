using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityInformationSystem.Services.Contracts
{
    using Models.ViewModels.Admin;

    public interface ITeachersService
    {
        bool TeacherExists(string teacherUsername);

        int GetTeacherId(string teacherUsername);

        IQueryable<CourseTeacherViewModel> GetAllTeachersForCourses();

        CourseTeacherViewModel GetFirst();
    }
}
