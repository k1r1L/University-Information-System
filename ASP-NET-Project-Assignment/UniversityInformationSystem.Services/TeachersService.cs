namespace UniversityInformationSystem.Services
{
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels.Users;
    using Models.ViewModels.Admin;
    using Models.ViewModels.Teacher;

    public class TeachersService : Service, ITeachersService
    {
        public TeachersService(IUisDataContext dbContext)
            : base(dbContext)
        {
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

        public IQueryable<CourseTeacherViewModel> GetAllTeachersForCourses()
        {
            return this.TeacherRepository.All().Select(t => new CourseTeacherViewModel()
            {
                Id = t.Id,
                UserName = t.IdentityUser.UserName
            }).OrderBy(t => t.UserName);
        }

        public CourseTeacherViewModel GetFirst()
        {
            return this.TeacherRepository
                .All()
                .Select(t => new CourseTeacherViewModel()
                {
                    Id = t.Id,
                    UserName = t.IdentityUser.UserName
                }).First();
        }

        public TeacherProfileViewModel GetTeacherProfileViewModel(string username)
        {
            Teacher teacherEntity = this.GetTeacherByUsername(username);

            return Mapper.Map<TeacherProfileViewModel>(teacherEntity);
        }

        public int? GetTeacherId(string teacherUsername)
        {
            Teacher teacherEntity = this.TeacherRepository
                .All()
                .SingleOrDefault(t => t.IdentityUser.UserName == teacherUsername);

            return teacherEntity?.Id;
        }
    }
}
