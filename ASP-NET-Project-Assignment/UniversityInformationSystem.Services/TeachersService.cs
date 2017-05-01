namespace UniversityInformationSystem.Services
{
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Data.Mocks.Repositories;
    using Models.EntityModels.Users;
    using Models.ViewModels.Admin;
    using Models.ViewModels.Teacher;

    public class TeachersService : Service, ITeachersService
    {
        public TeachersService(IUisDataContext dbContext)
            : base(dbContext)
        {
        }

        public TeachersService(IUisDataContext dbContext, MockedTeachersRepository mockedTeachersRepository)
            : base(dbContext)
        {
            this.TeacherRepository = mockedTeachersRepository;
            this.SeedTeachers();
        }

        public Teacher GetTeacherByUsername(string username)
        {
            return this.TeacherRepository
                .All()
                .Single(t => t.IdentityUser.UserName == username);
        }

        public bool TeacherExists(string teacherUsername)
        {
            return this.TeacherRepository
                .All()
                .Any(t => t.IdentityUser.UserName == teacherUsername);
        }

        public TeacherProfileViewModel GetTeacherProfileViewModel(string username)
        {
            Teacher teacherEntity = this.GetTeacherByUsername(username);

            return Mapper.Map<TeacherProfileViewModel>(teacherEntity);
        }
    }
}
