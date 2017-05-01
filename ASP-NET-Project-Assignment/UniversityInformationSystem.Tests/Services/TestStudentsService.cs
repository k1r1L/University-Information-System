namespace UniversityInformationSystem.Tests.Services
{
    using System.Linq;
    using Data.Mocks.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.EntityModels.Users;
    using Models.ViewModels.Student;
    using UniversityInformationSystem.Services;

    [TestClass]
    public class TestStudentsService : BaseTest
    {
        private StudentsService studentsService;

        [TestInitialize]
        public void Init()
        {
            this.studentsService = new StudentsService(
                this.dbContext, new MockedStudentsRepository(this.dbContext));   
        }

        [TestMethod]
        public void Test_GetStudentByUsername_Should_Return_Student()
        {
            // Arrange
            const string username = "dutskinov";

            // Act
            Student entity = this.studentsService.GetStudentByUsername(username);

            // Assert
            Assert.IsNotNull(entity);
            Assert.AreEqual(username, entity.IdentityUser.UserName);
        }

        [TestMethod]
        public void Test_GetProfileVm_Should_Return_Vm()
        {
            // Arrange
            const string username = "slav97";

            // Act
            StudentProfileViewModel profileVm = this.studentsService.GetStudentProfileViewModel(username);

            // Assert
            Assert.IsNotNull(profileVm);
            Assert.AreEqual(username, profileVm.UserName);
        }

        [TestMethod]
        public void Test_GetStudentId_Should_Return_Id()
        {
            // Arrange
            const string studentUsername = "slav97";
            const int expectedId = 2;
            
            // Act
            int? studentId = this.studentsService.GetStudentId(studentUsername);

            // Assert
            Assert.IsNotNull(studentId);
            Assert.AreEqual(expectedId, studentId.Value);
        }

        [TestMethod]
        public void Test_GetStudentId_Should_Return_Null()
        {
            // Arrange
            const string studentUsername = "slav957";

            // Act
            int? studentId = this.studentsService.GetStudentId(studentUsername);

            // Assert
            Assert.IsNull(studentId);
        }

        [TestMethod]
        public void Test_GetAllStudentUsernames_Should_Return_All()
        {
            // Arrange
            int expectedCount = 3;

            // Act
            int actualCount = this.studentsService.GetAllStudentUsernames().Count();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
