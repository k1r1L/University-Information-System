namespace UniversityInformationSystem.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.EntityModels;
    using Models.ViewModels.Admin;

    public interface IAdminCoursesService
    {
        IQueryable<CourseViewModel> GetAll();

        void Create(CourseViewModel courseViewModel);

        void Update(CourseViewModel courseViewModel);

        void Delete(int courseId);

        void AddTeacher(int teacherId, int courseId);
    }
}
