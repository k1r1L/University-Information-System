namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Data.Mocks.Repositories;
    using Models.EntityModels.Users;
    using Models.ViewModels.Student;

    public class StudentsService : Service, IStudentsService
    {

        public StudentsService(IUisDataContext dbContext)
            : base(dbContext)
        {
        }

        // Constructor for unit testing
        public StudentsService(IUisDataContext dbContext, MockedStudentsRepository mockedStudentsRepository)
            : base(dbContext)
        {
            this.StudentRepository = mockedStudentsRepository;
            this.SeedStudents();
        }

        public Student GetStudentByUsername(string username)
        {
            return this.StudentRepository
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
            Student studentEntity = this.StudentRepository
                .All()
                .SingleOrDefault(s => s.IdentityUser.UserName == username);

            return studentEntity?.Id;
        }

        public IEnumerable<string> GetAllStudentUsernames()
        {
            return this.StudentRepository
                .All()
                .Select(s => s.IdentityUser.UserName);
        }
    }
}
