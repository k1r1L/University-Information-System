namespace UniversityInformationSystem.Tests.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Mocks.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.ViewModels.Admin;
    using UniversityInformationSystem.Services;

    [TestClass]
    public class TestAdminCoursesService : BaseTest
    {
        private AdminCoursesService coursesService;

        [TestInitialize]
        public void Init()
        {
            this.coursesService = new AdminCoursesService(dbContext, 
                new MockedCourseRepository(dbContext), new MockedTeachersRepository(dbContext));
        }

        [TestMethod]
        public void Test_GetAll_Should_Return_All_CourseVms()
        {
            // Arrange
            IEnumerable<AdminCourseViewModel> vms = Mapper.Map<IEnumerable<AdminCourseViewModel>>(this.dbContext.Courses);

            // Act
            IEnumerable<AdminCourseViewModel> serviceGetAllResult = this.coursesService.GetAll();

            // Assert
            Assert.AreEqual(vms.Count(), serviceGetAllResult.Count());
        }

        [TestMethod]
        public void Test_Create_Should_Increase_Count()
        {
            // Arrange
            AdminCourseViewModel vm = new AdminCourseViewModel()
            {
                Id = 6,
                Credits = 12,
                Description = "Test Course",
                Name = "Course Title",
                IsOpen = "Yes"
            };
            
            // Act
            this.coursesService.Create(vm);

            //Assert
            Assert.AreEqual(6, this.coursesService.GetAll().Count());
        }

        [TestMethod]
        public void Test_Create_Should_Not_Be_Open_Course()
        {
            // Arange
            AdminCourseViewModel vm = new AdminCourseViewModel()
            {
                Id = 6,
                Credits = 12,
                Description = "Test Course",
                Name = "Course Title",
            };

            // Act
            this.coursesService.Create(vm);
            var all = this.coursesService.GetAll();

            // Assert
            Assert.AreEqual("No", all.Last().IsOpen);
        }

        [TestMethod]
        public void Test_Update_Should_Update_Course()
        {
            // Arange
            AdminCourseViewModel vm = new AdminCourseViewModel()
            {
                Id = 5,
                Credits = 12,
                Description = "Updated Course",
                Name = "Updated Title",
            };

            // Act
            this.coursesService.Update(vm);

            // Assert
            Assert.AreEqual(vm.Description, this.coursesService.GetAll().First(c => c.Id == 5).Description);
        }

        [TestMethod]
        public void Test_Delete_Should_Delete_Course()
        {
            // Arrange
            int courseId = 5;
            int coursesAfterDeletion = 4;

            // Act
            this.coursesService.Delete(courseId);

            // Assert
            Assert.AreEqual(coursesAfterDeletion, this.coursesService.GetAll().Count());
        }

        [TestMethod]
        public void Test_AddTeacher_TeacherId_Should_Be_Correct()
        {
            // Arrange
            int teacherId = 3;
            int courseId = 5;

            // Act
            this.coursesService.AddTeacher(teacherId, courseId);
            AdminCourseViewModel courseEntity = 
                this.coursesService.GetAll().FirstOrDefault(c => c.Id == courseId);

            // Assert
            Assert.AreEqual(teacherId, courseEntity.Teacher.Id);
        }

        [TestMethod]
        public void Test_GetCourseId_Should_Return_CourseId()
        {
            // Arrange
            const int courseId = 3;
            const string courseName = "Software Technologies";

            // Act
            int? actualId = this.coursesService.GetCourseId(courseName);

            // Assert
            Assert.AreEqual(courseId, actualId.Value);
        }

        [TestMethod]
        public void Test_GetCourseId_Should_Return_Null()
        {
            // Arrange
            const string courseName = "DIS";

            // Act
            int? courseId = this.coursesService.GetCourseId(courseName);

            // Assert
            Assert.IsNull(courseId);
        }

        [TestMethod]
        public void Test_GetTeacherIdByCourseName_Should_Return_TeacherId()
        {
            // Arrange
            const int teacherId = 3;
            const int courseId = 3;
            const string courseName = "Software Technologies";

            // Act
            this.coursesService.AddTeacher(teacherId, courseId);
            int? actualTeacherId = this.coursesService.GetTeacherIdByCourseName(courseName);

            // Assert
            Assert.AreEqual(teacherId, actualTeacherId.Value);
        }

        [TestMethod]
        public void Test_HasTeacher_Should_Return_True()
        {
            // Arrange
            const int teacherId = 3;
            const int courseId = 3;

            // Act
            this.coursesService.AddTeacher(teacherId, courseId);
            bool hasTeacher = this.coursesService.HasTeacher(courseId);

            // Assert
            Assert.IsTrue(hasTeacher);
        }

        [TestMethod]
        public void Test_HasTeacher_Should_Return_False()
        {
            // Arrange
            const int courseId = 3;

            // Act
            bool hasTeacher = this.coursesService.HasTeacher(courseId);

            // Assert
            Assert.IsFalse(hasTeacher);
        }

        [TestMethod]
        public void Test_GetAllOpenCourses()
        {
            // Arrange
            const int wantedCoursesCount = 2;
            const int teacherId = 2;
            const int firstCourseId = 2;
            const int secondCourseId = 5;
            const string studentUsername = "slav97";
            string[] courseNames = { "Programming Fundamentals", "Databases Basics SQL Server" };

            // Act
            this.coursesService.AddTeacher(teacherId, firstCourseId);
            this.coursesService.AddTeacher(teacherId, secondCourseId);
            string[] actualCourses = this.coursesService.GetAllOpenCourses(studentUsername).ToArray();

            // Assert
            Assert.AreEqual(wantedCoursesCount, actualCourses.Length);
            for (int i = 0; i < courseNames.Length; i++)
            {
                Assert.AreEqual(courseNames[i], actualCourses[i]);
            }
        }

        [TestMethod]
        public void Test_GetAllTeachers_Test_Ordering_And_Count()
        {
            // Arrange
            const int wantedTeachersCount = 3;
            string[] wantedUsernames =  { "bojkata", "georgiev", "kircata" };

            // Act
            CourseTeacherViewModel[] actualTeachers = this.coursesService.GetAllTeachersForCourses().ToArray();

            // Assert
            Assert.AreEqual(wantedTeachersCount, actualTeachers.Length);
            for (int i = 0; i < actualTeachers.Length; i++)
            {
               Assert.AreEqual(wantedUsernames[i], actualTeachers[i].UserName);
            }
        }

        [TestMethod]
        public void Test_GetFirstTeacher_Should_Return_Non_Null()
        {
            // Arrange
            const string username = "kircata";

            // Act
            CourseTeacherViewModel teacherVm = this.coursesService.GetFirstTeacher();

            // Assert
            Assert.IsNotNull(teacherVm);
            Assert.AreEqual(username, teacherVm.UserName);
        }

        [TestMethod]
        public void Test_TeacherExists_Should_Return_True()
        {
            // Arrange
            const string teacherUsername = "bojkata";

            // Act
            bool teacherExists = this.coursesService.TeacherExists(teacherUsername);

            // Assert
            Assert.IsTrue(teacherExists);
        }
    }
}
