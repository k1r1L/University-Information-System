namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels;
    using Models.EntityModels.Users;
    using Models.Enums;
    using Models.ViewModels.Admin;
    using Models.ViewModels.Student;

    public class StudentsCoursesService : Service, IStudentsCoursesService
    {
        public StudentsCoursesService(IUisDataContext dbContext) 
            : base(dbContext)
        {
        }

        public IQueryable<AdminStudentCourseViewModel> GetAll()
        {
            IEnumerable<StudentCourse> allEntities =  this.StudentsCoursesRepository.All();
            IEnumerable<AdminStudentCourseViewModel> allVms = Mapper.Map<IEnumerable<AdminStudentCourseViewModel>>(allEntities);

            return allVms.AsQueryable();
        }

        public IQueryable<MandatoryCourseViewModel> GetAllMandatoryCourses(string studentUsername)
        {
            IQueryable<StudentCourse> mandatoryCourses = this.StudentsCoursesRepository
                .All()
                .Where(sc => sc.Student.IdentityUser.UserName == studentUsername && !sc.Course.IsOpen);

            IEnumerable<MandatoryCourseViewModel> vms = Mapper.Map<IEnumerable<MandatoryCourseViewModel>>(mandatoryCourses);
            return vms.AsQueryable();
        }

        public IQueryable<OpenCourseViewModel> GetAllOpenCourses(string studentUsername)
        {
            IQueryable<StudentCourse> mandatoryCourses = this.StudentsCoursesRepository
                .All()
                .Where(sc => sc.Student.IdentityUser.UserName == studentUsername && sc.Course.IsOpen);

            IEnumerable<OpenCourseViewModel> vms = Mapper.Map<IEnumerable<OpenCourseViewModel>>(mandatoryCourses);
            return vms.AsQueryable();
        }

        public IEnumerable<string> GetAllStudentUsernames()
        {
            return this.StudentRepository
               .All()
               .Select(s => s.IdentityUser.UserName);
        }

        public IEnumerable<string> GetAllCoursesForStudent(string studentUsername)
        {
            return this.CoursesRepository
               .All()
               .Where(c => c.EnrolledStudents.All(sc => sc.Student.IdentityUser.UserName != studentUsername))
               .Select(c => c.Name);
        }

        public IEnumerable<string> GetAllOpenCoursesForStudent(string studentUsername)
        {
            IEnumerable<string> openCoursesNames = this.CoursesRepository
               .All()
               .Where(c => c.IsOpen && c.Teacher != null && c.EnrolledStudents.All(sc => sc.Student.IdentityUser.UserName != studentUsername))
               .Select(c => c.Name);

            return openCoursesNames;
        }

        public void Create(int studentId, int courseId)
        {
            // By default the student has an F grade (only teachers can change grades)
            StudentCourse studentCourse = new StudentCourse()
            {
                CourseId = courseId,
                StudentId = studentId,
                Grade = Grade.F
            };

            this.StudentsCoursesRepository.Add(studentCourse);
            this.SaveChanges();
        }

        public void Delete(int studentId, int courseId)
        {
            StudentCourse studentCourse = this.StudentsCoursesRepository
                .All()
                .Single(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            this.StudentsCoursesRepository.Delete(studentCourse);
            this.SaveChanges();
        }

        public bool AlreadyEnrolled(int? studentId, int? courseId)
        {
            return this.StudentsCoursesRepository
                .All()
                .Any(sc => sc.CourseId == courseId.Value && sc.StudentId == studentId.Value);
        }

        public int? GetStudentId(string username)
        {
            Student studentEntity = this.StudentRepository
               .All()
               .SingleOrDefault(s => s.IdentityUser.UserName == username);

            return studentEntity?.Id;
        }

        public int? GetCourseId(string courseName)
        {
            Course courseEntity = this.CoursesRepository
                .All()
                .SingleOrDefault(c => c.Name == courseName);

            return courseEntity?.Id;
        }
    }
}
