using Microsoft.EntityFrameworkCore;
using Shipfinity.DataAccess.Context;
using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.DataAccess.Repositories.Implementations
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context; 

        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }
 
        public async Task DeleteByIdAsync(int id)
        {
            Message message = await _context.Messages.FirstOrDefaultAsync(m=> m.Id == id);
            if (message == null)
            {
                throw new MessageNotFoundException(id);
            }
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>> GetAllAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Message>> GetRangeAsync(int start, int count)
        {
            return await _context.Messages
                .Skip(start)
                .Take(count)
                .ToListAsync();
        }

        public async Task InsertAsync(Message entity)
        {
            await _context.Messages.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Message entity)
        {
            _context.Messages.Update(entity);
            return _context.SaveChangesAsync();
        }
    }
}
