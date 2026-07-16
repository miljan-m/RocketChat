using Microsoft.EntityFrameworkCore;
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