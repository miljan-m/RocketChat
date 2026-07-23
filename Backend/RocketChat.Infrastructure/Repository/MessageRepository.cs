using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RocketChat.Application.Repositories;
using RocketChat.Domain.Models;
using RocketChat.Infrastructure.Persistance;

namespace RocketChat.Infrastructure.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DBContext _dbContext;
        public MessageRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteConversation(string receiverUsername, string senderUsername)
        {
            var result = await _dbContext.Set<Message>().Where(message => (message.ReceiverUsername == receiverUsername && message.SenderUsername == senderUsername) || (message.ReceiverUsername == senderUsername && message.SenderUsername == receiverUsername)).ExecuteDeleteAsync();
            if (result > 0) return true;
            return false;
        }

        public async Task<IEnumerable<Message>> GetAllMessages()
        {
            var messages = await _dbContext.Set<Message>().ToListAsync();
            return messages;
        }

        public async Task<bool> SaveMessage(Message message)
        {
            await _dbContext.Set<Message>().AddAsync(message);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}