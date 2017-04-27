namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels;
    using Models.ViewModels.Teacher;

    public class TeacherStudentsService : Service, ITeacherStudentsService
    {
        public TeacherStudentsService(IUisDataContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<TeacherStudentCourseViewModel> GetAll(string teacherName)
        {
            IQueryable<StudentCourse> teacherStudents = this.StudentsCoursesRepository
                .All()
                .Where(sc => sc.Course.Teacher.IdentityUser.UserName == teacherName);

            var vms = Mapper.Map<IEnumerable<TeacherStudentCourseViewModel>>(teacherStudents);
            return vms.AsQueryable();
        }

        public void Update(TeacherStudentCourseViewModel vm)
        {
            StudentCourse studentCourseEntity = this.StudentsCoursesRepository
                .All()
                .Single(sc => sc.CourseId == vm.CourseId && sc.StudentId == vm.StudentId);
            studentCourseEntity.Grade = vm.Grade;
            this.SaveChanges();
        }
    }
}
