namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels;
    using Models.ViewModels.Admin;

    public class CoursesService : ICoursesService
    {
        private IDbRepository<Course> courses;

        public CoursesService(IDbRepository<Course> courses)
        {
            this.courses = courses;
        }

        public IQueryable<AdminCourseViewModel> GetAll()
        {
            IQueryable<Course> courseEntities = this.courses.All();
            IEnumerable<AdminCourseViewModel> courseVms = Mapper.Map<IEnumerable<AdminCourseViewModel>>(courseEntities);

            return courseVms.AsQueryable();
        }

        public int Create(AdminCourseViewModel courseViewModel)
        {
            Course courseEntity = new Course()
            {
                Name = courseViewModel.Name,
                Description = courseViewModel.Description,
                Credits = courseViewModel.Credits,
                IsOpen = courseViewModel.IsOpen == "Yes"
            };
            this.courses.Add(courseEntity);
            this.courses.SaveChanges();
            return courseEntity.Id;
        }

        public void Update(AdminCourseViewModel courseViewModel)
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

        public int? GetCourseId(string courseName)
        {
            Course courseEntity = this.courses
                .All()
                .SingleOrDefault(c => c.Name == courseName);

            return courseEntity?.Id;
        }

        public int? GetTeacherIdByCourseName(string courseName)
        {
            return this.courses
                .All()
                .SingleOrDefault(c => c.Name == courseName)
                ?.TeacherId;
        }

        public bool HasTeacher(int courseId)
        {
            Course courseEntity = this.courses
                .GetById(courseId);

            return courseEntity.Teacher != null;
        }

        public IEnumerable<string> GetAllOpenCourses(string studentUsername)
        {
            var openCoursesNames = this.courses
                .All()
                .Where(c => c.IsOpen && c.EnrolledStudents.All(sc => sc.Student.IdentityUser.UserName != studentUsername))
                .Select(c => c.Name);

            return openCoursesNames;
        }
    }
}
