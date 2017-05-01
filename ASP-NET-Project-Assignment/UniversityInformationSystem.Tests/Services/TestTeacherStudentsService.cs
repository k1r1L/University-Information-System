namespace UniversityInformationSystem.Tests.Services
{
    using Data.Mocks.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Enums;
    using Models.ViewModels.Teacher;
    using UniversityInformationSystem.Services;
    using System.Linq;

    [TestClass]
    public class TestTeacherStudentsService : BaseTest
    {
        private TeacherStudentsService teacherStudentsService;

        [TestInitialize]
        public void Init()
        {
            this.teacherStudentsService = new TeacherStudentsService(
                this.dbContext, new MockedStudentsCoursesRepository(this.dbContext));
        }


        [TestMethod]
        public void Test_GetAll_Should_Return_3_Students()
        {
            // Arrange
            const string teacherUsername = "kircata";
            const int expectedCount = 3;

            // Act
            int actualCount = this.teacherStudentsService.GetAll(teacherUsername).Count();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_Update_Should_Change_Student_Grade()
        {
            // Arrange
            const string teacherUsername = "kircata";
            TeacherStudentCourseViewModel expectedVm = new TeacherStudentCourseViewModel()
            {
                CourseId = 1,
                StudentId = 3,
                Grade = Grade.D
            };

            // Act
            this.teacherStudentsService.Update(expectedVm);
            TeacherStudentCourseViewModel actualVm = this.teacherStudentsService
                .GetAll(teacherUsername).Last();

            // Assert
            Assert.IsNotNull(actualVm.Grade);
            Assert.AreEqual(expectedVm.Grade, actualVm.Grade);
        }
    }
}
