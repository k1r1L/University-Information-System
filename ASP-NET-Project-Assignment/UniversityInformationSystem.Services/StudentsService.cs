namespace UniversityInformationSystem.Services
{
    using System.Data.Entity;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels.Users;
    using Models.ViewModels.Student;

    public class StudentsService : IStudentsService
    {
        private IDbRepository<Student> students;

        public StudentsService(IDbRepository<Student> students)
        {
            this.students = students;
        }

        public Student GetStudentByUsername(string username)
        {
            return this.students
                .All()
                .Single(s => s.IdentityUser.UserName == username);
        }

        public StudentProfileViewModel GetStudentProfileViewModel(string username)
        {
            Student studentEntity = this.GetStudentByUsername(username);

            return Mapper.Map<StudentProfileViewModel>(studentEntity);
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
