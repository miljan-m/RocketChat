using RocketChat.Application.Interfaces;
using RocketChat.Application.Repositories;
using RocketChat.Domain.Models;

namespace RocketChat.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<bool> DeleteConversation(string receiverUsername, string senderUsername)
        {
            return await _messageRepository.DeleteConversation(receiverUsername, senderUsername);
        }

        public async Task<IEnumerable<Message>> GetAllMessages()
        {
            var messages = await _messageRepository.GetAllMessages();
            return messages;
        }

        public async Task<bool> SaveMessage(Message message)
        {
            await _messageRepository.SaveMessage(message);
            return true;
        }
    }
}