namespace UniversityInformationSystem.Tests.Services
{
    using Data.Mocks.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.EntityModels.Users;
    using Models.ViewModels.Teacher;
    using UniversityInformationSystem.Services;

    [TestClass]
    public class TestTeachersService : BaseTest
    {
        private TeachersService teachersService;

        [TestInitialize]
        public void Init()
        {
            this.teachersService = new TeachersService(
                this.dbContext, new MockedTeachersRepository(this.dbContext));
        }

        [TestMethod]
        public void Test_GetTeacherByUsername_Should_Return_Correct_Teacher()
        {
            // Arrange 
            const string teacherUsername = "bojkata";

            // Act
            Teacher entity = this.teachersService.GetTeacherByUsername(teacherUsername);

            // Assert
            Assert.IsNotNull(entity);
            Assert.AreEqual(teacherUsername, entity.IdentityUser.UserName);
        }

        [TestMethod]
        public void Test_TeacherExists_Should_Return_False()
        {
            // Arrange
            const string username = "someone";

            // Act
            bool teacherExists = this.teachersService.TeacherExists(username);

            // Assert
            Assert.IsFalse(teacherExists);
        }

        [TestMethod]
        public void Test_TeacherProfileVm_Should_Return_Vm()
        {
            // Arrange
            const string teacherUsername = "kircata";

            // Act
            TeacherProfileViewModel profileVm = this.teachersService.GetTeacherProfileViewModel(teacherUsername);

            // Assert
            Assert.IsNotNull(profileVm);
            Assert.AreEqual(teacherUsername, profileVm.UserName);
        }
    }
}
