namespace UniversityInformationSystem.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.ViewModels.Messages;

    public interface IMessagesService
    {
        void Create(string senderUsername, string receiverUsername, string messageText);

        void Delete(int messageId);

        IEnumerable<string> GetAllUsernames(string current);

        IEnumerable<InboxMessageViewModel> InboxMessages(string username);

        InboxMessageViewModel GetInboxMessageById(int id);

        bool MessageExists(int id);

        bool UnauthorizedDelete(int id, string receiver);

        bool ReceiverExists(string username);
    }
}
