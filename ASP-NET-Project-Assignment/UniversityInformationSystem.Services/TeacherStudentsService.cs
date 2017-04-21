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

    public class TeacherStudentsService : ITeacherStudentsService
    {
        private IDbRepository<StudentCourse> studentsCourses;

        public TeacherStudentsService(IDbRepository<StudentCourse> studentsCourses)
        {
            this.studentsCourses = studentsCourses;
        }

        public IQueryable<TeacherStudentCourseViewModel> GetAll(string teacherName)
        {
            IQueryable<StudentCourse> teacherStudents = this.studentsCourses
                .All()
                .Where(sc => sc.Course.Teacher.IdentityUser.UserName == teacherName);

            var vms = Mapper.Map<IEnumerable<TeacherStudentCourseViewModel>>(teacherStudents);
            return vms.AsQueryable();
        }

        public void Update(TeacherStudentCourseViewModel vm)
        {
            StudentCourse studentCourseEntity = this.studentsCourses
                .All()
                .Single(sc => sc.CourseId == vm.CourseId && sc.StudentId == vm.StudentId);
            studentCourseEntity.Grade = vm.Grade;
            this.studentsCourses.Update(studentCourseEntity);
            this.studentsCourses.SaveChanges();
        }
    }
}
