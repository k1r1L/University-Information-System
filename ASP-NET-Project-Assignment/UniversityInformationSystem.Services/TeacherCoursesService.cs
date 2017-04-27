namespace UniversityInformationSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels;
    using Models.ViewModels.Teacher;

    public class TeacherCoursesService : Service, ITeacherCoursesService
    {
        public TeacherCoursesService(IUisDataContext dbContext)
            : base(dbContext)
        {
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
