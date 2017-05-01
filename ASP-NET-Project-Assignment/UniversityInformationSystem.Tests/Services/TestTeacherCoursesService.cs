namespace UniversityInformationSystem.Tests.Services
{
    using System.Linq;
    using Data.Mocks.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.EntityModels.Users;
    using Models.ViewModels.Teacher;
    using UniversityInformationSystem.Services;

    [TestClass]
    public class TestTeacherCoursesService : BaseTest
    {
        private TeacherCoursesService teacherCoursesService;

        [TestInitialize]
        public void Init()
        {
            this.teacherCoursesService = new TeacherCoursesService(
                this.dbContext, new MockedCourseRepository(this.dbContext));
        }

        [TestMethod]
        public void Test_GetAllCourses_Should_Return_Those_For_Teacher()
        {
            // Arrange
            const string teacherUsername = "kircata";
            const int expectedCount = 2;
            string[] courseNames = { "Programming Basics", "JS Fundamentals" };

            // Act
            TeacherCourseViewModel[] vms = this.teacherCoursesService
                .GetAll(teacherUsername).ToArray();

            // Assert
            Assert.AreEqual(expectedCount, vms.Length);
            for (int i = 0; i < courseNames.Length; i++)
            {
                Assert.AreEqual(courseNames[i], vms[i].Name);
            }
        }

        [TestMethod]
        public void Test_Update_Should_Update_Course()
        {
            // Arrange
            TeacherCourseViewModel expectedVm = new TeacherCourseViewModel()
            {
                Id = 1,
                Name = "PB",
                Description = "Basics"
            };
            const string username = "kircata";

            // Act
            this.teacherCoursesService.Update(expectedVm);
            TeacherCourseViewModel actualVm = this.teacherCoursesService.GetAll(username).First();

            // Assert
            Assert.AreEqual(expectedVm.Name, actualVm.Name);
            Assert.AreEqual(expectedVm.Description, actualVm.Description);
        }
    }
}
