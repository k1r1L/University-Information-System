namespace UniversityInformationSystem.Services
{
    using System.Data.Entity;
    using System.Linq;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels.Users;

    public class StudentsService : IStudentsService
    {
        private IDbRepository<Student> students;

        public StudentsService(IDbRepository<Student> students)
        {
            this.students = students;
        }

        public int? GetStudentId(string username)
        {
            Student studentEntity = this.students
                .All()
                .SingleOrDefault(s => s.IdentityUser.UserName == username);

            return studentEntity?.Id;
        }
    }
}
