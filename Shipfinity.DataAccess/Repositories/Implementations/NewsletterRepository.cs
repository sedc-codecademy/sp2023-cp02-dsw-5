using Microsoft.EntityFrameworkCore;
using Shipfinity.DataAccess.Context;
using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;


namespace Shipfinity.DataAccess.Repositories.Implementations
{
    public class NewsletterRepository : INewsletterRepository
    {
        private readonly AppDbContext _context;

        public NewsletterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NewsletterSubscriber>> GetAllAsync()
        {
            return await _context.NewsletterSubscribers.ToListAsync();
        }

        public async Task<NewsletterSubscriber> GetByIdAsync(int id)
        {
            return await _context.NewsletterSubscribers.FindAsync(id);
        }

        public async Task InsertAsync(NewsletterSubscriber entity)
        {
            await _context.NewsletterSubscribers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NewsletterSubscriber entity)
        {
            _context.NewsletterSubscribers.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var subscriber = await _context.NewsletterSubscribers.FindAsync(id);
            if (subscriber != null)
            {
                _context.NewsletterSubscribers.Remove(subscriber);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NewsletterSubscriber>> GetRangeAsync(int start, int count)
        {
            return await _context.NewsletterSubscribers.Skip(start).Take(count).ToListAsync();
        }
    }
}