namespace UniversityInformationSystem.Tests.Services
{
    using System.Linq;
    using Data.Mocks.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UniversityInformationSystem.Services;

    [TestClass]
    public class TestMessagesService : BaseTest
    {
        private MessagesService messagesService;

        [TestInitialize]
        public void Init()
        {
            this.messagesService = new MessagesService(
                this.dbContext, new MockedMessagesRepository(this.dbContext));
        }

        [TestMethod]
        public void Test_Create_Should_Increase_Count()
        {
            // Arrange
            const string senderUsername = "kircata";
            const string receiverUsername = "bojkata";
            const string messageText = "zdr";
            const int expectedCount = 1;

            // Act
            this.messagesService.Create(senderUsername, receiverUsername, messageText);

            // Assert
            Assert.AreEqual(expectedCount, this.messagesService.InboxMessages(receiverUsername).Count());
        }

        [TestMethod]
        public void Test_Create_Should_Not_Increase_Count()
        {
            // Arrange
            const string messageText = "zdr";
            const int expectedCount = 0;

            // Act
            this.messagesService.Create(null, null, messageText);

            // Assert
            Assert.AreEqual(expectedCount, this.messagesService.InboxMessages("kircata").Count());
        }

        [TestMethod]
        public void Test_GetAllUsernames_Should_Return_All_Except_Current()
        {
            // Arrange
            const string current = "kircata";
            const int expectedCount = 5;
            string[] expectedUsernames = { "jicata", "slav97", "dutskinov", "bojkata", "georgiev" };

            // Act
            string[] allUsernames = this.messagesService.GetAllUsernames(current).ToArray();

            // Assert
            Assert.AreEqual(expectedCount, allUsernames.Length);
            for (int i = 0; i < expectedUsernames.Length; i++)
            {
                Assert.AreEqual(expectedUsernames[i], allUsernames[i]);
            }
        }

        [TestMethod]
        public void Test_GetInboxMessages_Should_Return_2()
        {
            // Arrange
            const int expectedCount = 2;
            const string senderUsername = "kircata";
            const string receiverUsername = "jicata";
            const string firstText = "cs";
            const string secondText = "go";

            // Act
            this.messagesService.Create(senderUsername, receiverUsername, firstText);
            this.messagesService.Create(senderUsername, receiverUsername, secondText);
            int vmsCount = this.messagesService.InboxMessages(receiverUsername).Count();

            // Assert
            Assert.AreEqual(expectedCount, vmsCount);
        }


    }
}
