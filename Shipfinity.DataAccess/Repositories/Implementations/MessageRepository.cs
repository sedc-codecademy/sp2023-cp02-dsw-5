using Shipfinity.DataAccess.Context;
using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DataAccess.Repositories.Implementations
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context; 

        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Message> CreateMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetRangeAsync(int start, int count)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Message entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
