using RocketChat.Domain.Models;

namespace RocketChat.Application.Interfaces
{
    public interface IMessageService
    {

        public Task<IEnumerable<Message>> GetAllMessages();
        public Task<bool> SaveMessage(Message message);

        public Task<bool> DeleteConversation(string receiverUsername, string senderUsername);
    }
}