namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Data.Mocks.Repositories;
    using Models.EntityModels;
    using Models.ViewModels.Teacher;

    public class TeacherCoursesService : Service, ITeacherCoursesService
    {
        public TeacherCoursesService(IUisDataContext dbContext)
            : base(dbContext)
        {
        }

        // Constructor for unit testing
        public TeacherCoursesService(IUisDataContext dbContext, MockedCourseRepository mockedCourseRepository)
            : base(dbContext)
        {
            this.CoursesRepository = mockedCourseRepository;
            this.SeedCourses();
            this.SeedTeachers();
        }

        public IQueryable<TeacherCourseViewModel> GetAll(string teacherUsername)
        {
            IQueryable<Course> coursesByTeacher = this.CoursesRepository
                .All()
                .Where(c => c.Teacher.IdentityUser.UserName == teacherUsername);

            IEnumerable<TeacherCourseViewModel> vms = Mapper.Map<IEnumerable<TeacherCourseViewModel>>(coursesByTeacher);

            return vms.AsQueryable();
        }

        public void Update(TeacherCourseViewModel vm)
        {
            Course courseEntity = this.CoursesRepository.GetById(vm.Id);
            courseEntity.Name = vm.Name;
            courseEntity.Description = vm.Description;
            this.SaveChanges();
        }
    }
}
