namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Data.Mocks.Repositories;
    using Models.EntityModels;
    using Models.EntityModels.Users;
    using Models.ViewModels.Messages;

    public class MessagesService : Service, IMessagesService
    {
        public MessagesService(IUisDataContext dbContext)
            : base(dbContext)
        {
        }

        // Constructor for unit testing
        public MessagesService(IUisDataContext dbContext, MockedMessagesRepository mockedMessagesRepository)
             : base(dbContext)
        {
            this.MessagesRepository = mockedMessagesRepository;
            this.SeedStudents();
            this.SeedTeachers();
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

        public IEnumerable<InboxMessageViewModel> InboxMessages(string username)
        {
            IEnumerable<Message> allMessagesForUser = this.MessagesRepository
                .All()
                .Where(m => m.Receiver.UserName == username);
            IEnumerable<InboxMessageViewModel> vms = Mapper.Map<IEnumerable<InboxMessageViewModel>>(allMessagesForUser);

            return vms;
        }

        public InboxMessageViewModel GetInboxMessageById(int id)
        {
            Message messageEntity = this.MessagesRepository.GetById(id);

            return Mapper.Map<InboxMessageViewModel>(messageEntity);
        }

        public bool MessageExists(int id)
        {
            return this.MessagesRepository
                .All()
                .Any(m => m.Id == id);
        }

        public bool UnauthorizedDelete(int id, string receiver)
        {
            Message messageEntity = this.MessagesRepository.GetById(id);

            return messageEntity.Receiver.UserName != receiver;
        }
    }
}
