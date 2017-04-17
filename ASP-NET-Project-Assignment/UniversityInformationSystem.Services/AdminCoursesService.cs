namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data;
    using Data.Contracts;
    using Models.EntityModels;
    using Models.EntityModels.Users;
    using Models.ViewModels.Admin;

    public class AdminCoursesService : IAdminCoursesService
    {
        private IDbRepository<Course> courses;
        private IDbRepository<Teacher> teachers;

        public AdminCoursesService(IDbRepository<Course> courses, IDbRepository<Teacher> teachers)
        {
            this.courses = courses;
            this.teachers = teachers;
        }

        public IQueryable<CourseViewModel> GetAll()
        {
            IQueryable<Course> courseEntities = this.courses.All();
            IEnumerable<CourseViewModel> courseVms = Mapper.Map<IEnumerable<CourseViewModel>>(courseEntities);

            return courseVms.AsQueryable();
        }

        public void Create(CourseViewModel courseViewModel)
        {
            Course courseEntity = Mapper.Map<Course>(courseViewModel);
            this.courses.Add(courseEntity);
            this.courses.SaveChanges();
        }

        public void Update(CourseViewModel courseViewModel)
        {
            Course entity = this.courses.GetById(courseViewModel.Id);
            entity.Name = courseViewModel.Name;
            entity.Description = courseViewModel.Description;
            entity.IsOpen = courseViewModel.IsOpen == "Yes";
            this.courses.Update(entity);
            this.courses.SaveChanges();
        }

        public void Delete(int courseId)
        {
            Course courseEntity = this.courses.GetById(courseId);
            this.courses.Delete(courseEntity);
            this.courses.SaveChanges();
        }

        public void AddTeacher(int teacherId, int courseId)
        {
            Course courseEntity = this.courses.GetById(courseId);
            courseEntity.TeacherId = teacherId;
            this.courses.SaveChanges();
        }
    }
}
