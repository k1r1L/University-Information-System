using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityInformationSystem.Services
{
    using Contracts;
    using Data;
    using Data.Contracts;
    using Models.EntityModels;
    using Models.EntityModels.Users;
    using Models.ViewModels.Admin;

    public class TeachersService : ITeachersService
    {
        private IDbRepository<Teacher> teachers;

        public TeachersService(IDbRepository<Teacher> teachers)
        {
            this.teachers = teachers;
        }

        public bool TeacherExists(string teacherUsername)
        {
            return this.teachers.All().Any(t => t.IdentityUser.UserName == teacherUsername);
        }

        public int GetTeacherId(string teacherUsername)
        {
            return this.teachers
                .All()
                .Single(t => t.IdentityUser.UserName == teacherUsername)
                .Id;
        }

        public IQueryable<CourseTeacherViewModel> GetAllTeachersForCourses()
        {
            return this.teachers.All().Select(t => new CourseTeacherViewModel()
            {
                Id = t.Id,
                UserName = t.IdentityUser.UserName
            }).OrderBy(t => t.UserName);
        }

        public CourseTeacherViewModel GetFirst()
        {
            return this.teachers.All().Select(t => new CourseTeacherViewModel()
            {
                Id = t.Id,
                UserName = t.IdentityUser.UserName
            }).First();
        }
    }
}
