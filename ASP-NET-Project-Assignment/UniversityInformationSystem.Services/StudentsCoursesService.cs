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
    using Models.EntityModels.Users;
    using Models.Enums;
    using Models.ViewModels.Admin;
    using Models.ViewModels.Student;

    public class StudentsCoursesService : IStudentsCoursesService
    {
        private IDbRepository<StudentCourse> studentsCourses;

        public StudentsCoursesService(IDbRepository<StudentCourse> studentsCourses)
        {
            this.studentsCourses = studentsCourses;
        }


        public IQueryable<AdminStudentCourseViewModel> GetAll()
        {
            IEnumerable<StudentCourse> allEntities =  this.studentsCourses.All();
            IEnumerable<AdminStudentCourseViewModel> allVms = Mapper.Map<IEnumerable<AdminStudentCourseViewModel>>(allEntities);

            return allVms.AsQueryable();
        }

        public IQueryable<MandatoryCourseViewModel> GetAllMandatoryCourses(string studentUsername)
        {
            IQueryable<StudentCourse> mandatoryCourses = this.studentsCourses
                .All()
                .Where(sc => sc.Student.IdentityUser.UserName == studentUsername && !sc.Course.IsOpen);

            IEnumerable<MandatoryCourseViewModel> vms = Mapper.Map<IEnumerable<MandatoryCourseViewModel>>(mandatoryCourses);
            return vms.AsQueryable();
        }

        public IQueryable<OpenCourseViewModel> GetAllOpenCourses(string studentUsername)
        {
            IQueryable<StudentCourse> mandatoryCourses = this.studentsCourses
                .All()
                .Where(sc => sc.Student.IdentityUser.UserName == studentUsername && sc.Course.IsOpen);

            IEnumerable<OpenCourseViewModel> vms = Mapper.Map<IEnumerable<OpenCourseViewModel>>(mandatoryCourses);
            return vms.AsQueryable();
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

            this.studentsCourses.Add(studentCourse);
            this.studentsCourses.SaveChanges();
        }

        public void Delete(int studentId, int courseId)
        {
            StudentCourse studentCourse = this.studentsCourses
                .All()
                .Single(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            this.studentsCourses.Delete(studentCourse);
            this.studentsCourses.SaveChanges();
        }
    }
}
