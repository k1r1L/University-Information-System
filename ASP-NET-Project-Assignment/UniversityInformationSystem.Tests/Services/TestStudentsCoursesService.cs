namespace UniversityInformationSystem.Tests.Services
{
    using System.Linq;
    using Data.Mocks.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.EntityModels;
    using Models.Enums;
    using Models.ViewModels.Student;
    using UniversityInformationSystem.Services;

    [TestClass]
    public class TestStudentsCoursesService : BaseTest
    {
        private StudentsCoursesService studentsCoursesService;

        [TestInitialize]
        public void Init()
        {
            this.studentsCoursesService = new StudentsCoursesService(this.dbContext, 
                new MockedStudentsCoursesRepository(this.dbContext),
                new MockedCourseRepository(this.dbContext),
                new MockedStudentsRepository(this.dbContext));
        }

        [TestMethod]
        public void Test_GetAll_Should_Return_StudentCourseVms()
        {
            // Arrange
            const int count = 0;

            // Act
            var vms = this.studentsCoursesService.GetAll();

            // Assert
            Assert.AreEqual(count, vms.Count());
        }

        [TestMethod]
        public void Test_Create_Should_Increase_Count()
        {
            // Arrange
            const int count = 1;
            const int studentId = 1;
            const int courseId = 1;

            // Act
            this.studentsCoursesService.Create(studentId, courseId);

            // Assert
            Assert.AreEqual(count, this.studentsCoursesService.GetAll().Count());
        }

        [TestMethod]
        public void Test_Create_Sould_Return_GradeF()
        {
            // Arrange
            const int studentId = 1;
            const int courseId = 1;
            const string studentUsername = "jicata";

            // Act
            this.studentsCoursesService.Create(studentId, courseId);
            var vm = this.studentsCoursesService.GetAllMandatoryCourses(studentUsername).Last();

            // Assert
            Assert.AreEqual(Grade.F, vm.Grade);
        }

        [TestMethod]
        public void Test_Delete_Should_Decrease_Count()
        {
            // Arrange
            const int studentId = 1;
            const int courseId = 1;
            const int count = 0;
            const string studentUsername = "jicata";

            // Act
            this.studentsCoursesService.Create(studentId, courseId);
            this.studentsCoursesService.Delete(studentId, courseId);

            // Assert
            Assert.AreEqual(count, this.studentsCoursesService.GetAllMandatoryCourses(studentUsername).Count());
        }

        [TestMethod]
        public void Test_GetAllMandatoryCourses_Should_Return_3()
        {
            // Arrange
            const string studentUsername = "dutskinov";
            const int studentId = 3;
            const int coursesCount = 3;

            // Act
            for (int i = 1; i <= this.dbContext.Courses.Count(); i++)
            {
                this.studentsCoursesService.Create(studentId, i);
            }
            var vms = this.studentsCoursesService.GetAllMandatoryCourses(studentUsername);

            // Assert
            Assert.AreEqual(coursesCount, vms.Count());
        }

        [TestMethod]
        public void Test_GetAllMandatoryCourses_All_Should_Be_Mandatory()
        {
            // Arrange
            const string studentUsername = "dutskinov";
            const int studentId = 3;

            // Act
            for (int i = 1; i <= this.dbContext.Courses.Count(); i++)
            {
                this.studentsCoursesService.Create(studentId, i);
            }
            var vms = this.studentsCoursesService.GetAllMandatoryCourses(studentUsername);

            // Assert
            foreach (MandatoryCourseViewModel model in vms)
            {
                Course courseEntity = this.dbContext.Courses.Find(model.CourseId);
                Assert.IsFalse(courseEntity.IsOpen);
            }
        }

        [TestMethod]
        public void Test_GetAllOpenCourses_Should_Return_2()
        {
            // Arrange
            const string studentUsername = "dutskinov";
            const int studentId = 3;
            const int coursesCount = 2;

            // Act
            for (int i = 1; i <= this.dbContext.Courses.Count(); i++)
            {
                this.studentsCoursesService.Create(studentId, i);
            }
            var vms = this.studentsCoursesService.GetAllOpenCourses(studentUsername);

            // Assert
            Assert.AreEqual(coursesCount, vms.Count());
        }

        [TestMethod]
        public void Test_GetAllOpenCourses_All_Should_Be_Open()
        {
            // Arrange
            const string studentUsername = "dutskinov";
            const int studentId = 3;

            // Act
            for (int i = 1; i <= this.dbContext.Courses.Count(); i++)
            {
                this.studentsCoursesService.Create(studentId, i);
            }
            var vms = this.studentsCoursesService.GetAllOpenCourses(studentUsername);

            // Assert
            foreach (OpenCourseViewModel model in vms)
            {
                Course courseEntity = this.dbContext.Courses.Find(model.CourseId);
                Assert.IsTrue(courseEntity.IsOpen);
            }
        }

        [TestMethod]
        public void Test_GetAllStudentUsernames()
        {
            // Arrange
            const int studentsCount = 3;
            string[] expectedUsernames = { "jicata", "slav97", "dutskinov" };

            // Act
            string[] actualUsernames = this.studentsCoursesService.GetAllStudentUsernames().ToArray();

            // Assert
            Assert.AreEqual(studentsCount, actualUsernames.Length);
            for (int i = 0; i < expectedUsernames.Length; i++)
            {
               Assert.AreEqual(expectedUsernames[i], actualUsernames[i]);
            }
        }

        [TestMethod]
        public void Test_GetAllOpenCoursesForStudent_Should_Return_2()
        {
            // Arrange
            const int openCoursesCount = 2;
            const string studentUsername = "jicata";

            // Act
            string[] openCourses = this.studentsCoursesService
                .GetAllOpenCoursesForStudent(studentUsername).ToArray();

            // Assert
            Assert.AreEqual(openCoursesCount, openCourses.Length);
        }

        [TestMethod]
        public void Test_AlreadyEnrolled_Should_Return_True()
        {
            // Arrange
             int? studentId = 1;
             int? courseId = 1;

            // Act
            this.studentsCoursesService.Create(studentId.Value, courseId.Value);
            bool alreadyEnrolled = this.studentsCoursesService.AlreadyEnrolled(studentId, courseId);

            // Assert
            Assert.IsTrue(alreadyEnrolled);
        }

        [TestMethod]
        public void Test_GetStudentId_Should_Return_Id()
        {
            // Arrange
            const string studentUsername = "slav97";
            const int expectedId = 2;

            // Act
            int? studentId = this.studentsCoursesService.GetStudentId(studentUsername);

            // Assert
            Assert.AreEqual(expectedId, studentId.Value);
        }

        [TestMethod]
        public void Test_GetStudentId_Should_Return_Null()
        {
            // Arrange
            const string studentUsername = "slav96";

            // Act
            int? studentId = this.studentsCoursesService.GetStudentId(studentUsername);

            // Assert
            Assert.IsNull(studentId);
        }

        [TestMethod]
        public void Test_GetCourseId_Should_Return_Id()
        {
            // Arrange
            const string courseName = "JS Fundamentals";
            const int expectedId = 4;

            // Act
            int? courseId = this.studentsCoursesService.GetCourseId(courseName);

            // Assert
            Assert.AreEqual(expectedId, courseId);
        }

        [TestMethod]
        public void Test_GetCourseId_Should_Return_Null()
        {
            // Arrange
            const string courseName = "JS Advanced";

            // Act
            int? courseId = this.studentsCoursesService.GetCourseId(courseName);

            // Assert
            Assert.IsNull(courseId);
        }
    }
}
