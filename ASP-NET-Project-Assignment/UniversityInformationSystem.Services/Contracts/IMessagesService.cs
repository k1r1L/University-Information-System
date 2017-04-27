namespace UniversityInformationSystem.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMessagesService
    {
        void Create(string senderUsername, string receiverUsername, string messageText);

        void Delete(int messageId);

        IEnumerable<string> GetAllUsernames(string current);
    }
}
