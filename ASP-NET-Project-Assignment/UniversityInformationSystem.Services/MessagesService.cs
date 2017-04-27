namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels;
    using Models.EntityModels.Users;

    public class MessagesService : Service, IMessagesService
    {
        public MessagesService(IUisDataContext dbContext) 
            : base(dbContext)
        {
        }

        public void Create(string senderUsername, string reveiverUsername, string messageText)
        {
            ApplicationUser senderAppUser = this.ApplicationUserRepository
                .All()
                .FirstOrDefault(appUser => appUser.UserName == senderUsername);
            ApplicationUser receiverAppUser = this.ApplicationUserRepository
               .All()
               .FirstOrDefault(appUser => appUser.UserName == reveiverUsername);
            if (senderAppUser != null && receiverAppUser != null)
            {
                Message newMessage = new Message()
                {
                    Receiver = receiverAppUser,
                    Sender = senderAppUser,
                    Text = messageText
                };

                this.MessagesRepository.Add(newMessage);
                this.SaveChanges();
            }
        }

        public void Delete(int messageId)
        {
            Message messageEntity = this.MessagesRepository.GetById(messageId);
            this.MessagesRepository.Delete(messageEntity);
            this.SaveChanges();
        }

        public IEnumerable<string> GetAllUsernames(string current)
        {
            return this.ApplicationUserRepository
                   .All()
                   .Where(u => u.UserName != current)
                   .Select(u => u.UserName);
        }
    }
}
