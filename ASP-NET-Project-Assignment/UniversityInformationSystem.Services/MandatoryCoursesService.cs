namespace UniversityInformationSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels;
    using Models.ViewModels.Student;

    public class MandatoryCoursesService : IMandatoryCoursesService
    {
        private IDbRepository<StudentCourse> studentsCourses;

        public MandatoryCoursesService(IDbRepository<StudentCourse> studentsCourses)
        {
            this.studentsCourses = studentsCourses;
        }

        public IQueryable<MandatoryCourseViewModel> GetAll(string studentUsername)
        {
            IQueryable<StudentCourse> entities = this.studentsCourses
                .All()
                .Where(sc => sc.Student.IdentityUser.UserName == studentUsername && !sc.Course.IsOpen);
            IEnumerable<MandatoryCourseViewModel> allVms = Mapper.Map<IEnumerable<MandatoryCourseViewModel>>(entities);

            return allVms.AsQueryable();
        }
    }
}
