namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels;
    using Models.ViewModels.Admin;

    public class AdminCoursesService : Service, IAdminCoursesService
    {
        public AdminCoursesService(IUisDataContext dbContext) 
            : base(dbContext)
        {
        }

        public IQueryable<AdminCourseViewModel> GetAll()
        {
            IQueryable<Course> courseEntities = this.CoursesRepository.All();
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
            this.CoursesRepository.Add(courseEntity);
            this.SaveChanges();

            return courseEntity.Id;
        }

        public void Update(AdminCourseViewModel courseViewModel)
        {
            Course entity = this.CoursesRepository.GetById(courseViewModel.Id);
            entity.Name = courseViewModel.Name;
            entity.Description = courseViewModel.Description;
            entity.IsOpen = courseViewModel.IsOpen == "Yes";
            this.SaveChanges();
        }

        public void Delete(int courseId)
        {
            Course courseEntity = this.CoursesRepository.GetById(courseId);
            this.CoursesRepository.Delete(courseEntity);
            this.SaveChanges();
        }

        public void AddTeacher(int teacherId, int courseId)
        {
            Course courseEntity = this.CoursesRepository.GetById(courseId);
            courseEntity.TeacherId = teacherId;
            this.SaveChanges();
        }

        public int? GetCourseId(string courseName)
        {
            Course courseEntity = this.CoursesRepository
                .All()
                .SingleOrDefault(c => c.Name == courseName);

            return courseEntity?.Id;
        }

        public int? GetTeacherIdByCourseName(string courseName)
        {
            return this.CoursesRepository
                .All()
                .SingleOrDefault(c => c.Name == courseName)
                ?.TeacherId;
        }

        public bool HasTeacher(int courseId)
        {
            Course courseEntity = this.CoursesRepository
                .GetById(courseId);

            return courseEntity.Teacher != null;
        }

        public IEnumerable<string> GetAllOpenCourses(string studentUsername)
        {
            var openCoursesNames = this.CoursesRepository
                .All()
                .Where(c => c.IsOpen && c.Teacher != null && c.EnrolledStudents.All(sc => sc.Student.IdentityUser.UserName != studentUsername))
                .Select(c => c.Name);

            return openCoursesNames;
        }

        public IEnumerable<string> GetAllCoursesForStudent(string studentUsername)
        {
            return this.CoursesRepository
                .All()
                .Where(c => c.EnrolledStudents.All(sc => sc.Student.IdentityUser.UserName != studentUsername))
                .Select(c => c.Name);
        }

        public IQueryable<CourseTeacherViewModel> GetAllTeachersForCourses()
        {
            return this.TeacherRepository.All().Select(t => new CourseTeacherViewModel()
            {
                Id = t.Id,
                UserName = t.IdentityUser.UserName
            }).OrderBy(t => t.UserName);
        }


        public CourseTeacherViewModel GetFirstTeacher()
        {
            return this.TeacherRepository.All().Select(t => new CourseTeacherViewModel()
            {
                Id = t.Id,
                UserName = t.IdentityUser.UserName
            }).First();
        }

        public bool TeacherExists(string teacherUsername)
        {
            return this.TeacherRepository
                .All()
                .Any(t => t.IdentityUser.UserName == teacherUsername);
        }
    }
}
