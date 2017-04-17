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

    public class AdminTeachersService : IAdminTeachersService
    {
        private IDbRepository<Teacher> teachers;

        public AdminTeachersService(IDbRepository<Teacher> teachers)
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
    }
}
