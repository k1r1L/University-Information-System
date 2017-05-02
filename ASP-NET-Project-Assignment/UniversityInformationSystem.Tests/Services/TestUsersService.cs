namespace UniversityInformationSystem.Tests.Services
{
    using System;
    using System.Linq;
    using Data.Mocks;
    using Data.Mocks.Repositories;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.EntityModels.Users;
    using Models.Enums;
    using Models.ViewModels.Admin;
    using UniversityInformationSystem.Services;

    [TestClass]
    public class TestUsersService : BaseTest
    {
        private UsersService usersService;

        [TestInitialize]
        public void Init()
        {
            this.usersService = new UsersService(this.dbContext
                , new MockedUsersRepository(this.dbContext));
        }

        [TestMethod]
        public void Test_Register_Should_Register_Student()
        {
            // Arrange
            const UserType userType = UserType.Student;
            const string appUserId = "asdajs32423j";

            // Act
            this.usersService.Register(userType, appUserId);
            Student lastRegistered = this.usersService
                .GetAllStudents().Last();

            // Assert
            Assert.IsNotNull(lastRegistered);
            Assert.AreEqual(appUserId, lastRegistered.IdenityUserId);
        }

        [TestMethod]
        public void Test_Register_Should_Register_Teacher()
        {
            // Arrange
            const UserType userType = UserType.Teacher;
            const string appUserId = "asdas3242344";

            // Act
            this.usersService.Register(userType, appUserId);
            Teacher lastRegistered = this.usersService
                .GetAllTeachers().Last();

            // Assert
            Assert.IsNotNull(lastRegistered);
            Assert.AreEqual(appUserId, lastRegistered.IdenityUserId);
        }

        [TestMethod]
        public void Test_GetAdminProfileVm_Shold_Return_Vm()
        {
            // Arrange
            const string username = "dutskinov";
            const string firstName = "Niki";
            const string lastName = "Dutskinov";
            DateTime birthDate = new DateTime(1995, 11, 06);

            // Act
            AdminProfileViewModel profileVm = this.usersService
                .GetAdminProfileViewModel(username);

            // Assert
            Assert.IsNotNull(profileVm);
            Assert.AreEqual(username, profileVm.UserName);
            Assert.AreEqual(firstName, profileVm.FirstName);
            Assert.AreEqual(lastName, profileVm.LastName);
            Assert.AreEqual(birthDate, profileVm.BirthDate);
        }

        [TestMethod]
        public void Test_GetAll_Should_Return_6_Users()
        {
            // Arrange
            const int expectedCount = 6;

            // Act
            int actualCount = this.usersService.GetAll().Count();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_UserExists_Should_Return_True()
        {
            // Arrange
            const string appUserId = "asdasds234234ad";

            // Act
            bool userExists = this.usersService.UserExists(appUserId);

            // Assert
            Assert.IsTrue(userExists);
        }

        [TestMethod]
        public void Test_Update_Should_Rehash_Password()
        {
            // Arrange
            const string passwordHash = "asdhasdgahsdghas";
            const string username = "kircata";
            UserViewModel userVm = new UserViewModel()
            {
                Id = "asdasds234234ad",
                FirstName = "Kiril",
                LastName = "Kirilov",
                Password = "1234",
            };
            UserManager<ApplicationUser> userManager = 
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MockedUisDbContext()));

            // Act
            this.usersService.Update(userVm, userManager);
            string actualPassHash = this.usersService.ReturnPasswordHash(username);

            // Assert
            Assert.AreNotEqual(passwordHash, actualPassHash);
        }

        [TestMethod]
        public void Test_Delete_Should_Remove_Teacher()
        {
            // Arrange
            const string teacherId = "asdasds234234ad";

            // Act
            this.usersService.Delete(teacherId);

            // Assert
            Assert.IsFalse(this.usersService.UserExists(teacherId));
        }

        [TestMethod]
        public void Test_Delete_Should_Remove_Student()
        {
            // Arrange
            const string studentId = "asgwe343fdfh5";

            // Act
            this.usersService.Delete(studentId);

            // Assert
            Assert.IsFalse(this.usersService.UserExists(studentId));
        }
    }
}
