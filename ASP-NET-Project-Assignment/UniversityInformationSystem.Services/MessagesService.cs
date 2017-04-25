namespace UniversityInformationSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels;

    public class MessagesService : IMessagesService
    {
        private IDbRepository<Message> messages;

        public MessagesService(IDbRepository<Message> messages)
        {
            this.messages = messages;
        }

        public void Create(string senderId, string reveiverId, string messageText)
        {
            Message newMessage = new Message()
            {
                ReceiverId = reveiverId,
                SenderId = senderId,
                Text = messageText
            };

            this.messages.Add(newMessage);
            this.messages.SaveChanges();
        }

        public void Delete(int messageId)
        {
            Message messageEntity = this.messages.GetById(messageId);
            this.messages.Delete(messageEntity);
            this.messages.SaveChanges();
        }
    }
}
