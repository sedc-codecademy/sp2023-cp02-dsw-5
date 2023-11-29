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
    public class NewsletterRepository : INewsletterRepository
    {
        private readonly AppDbContext _context;

        public NewsletterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddSubscriberAsync(NewsletterSubscriber subscriber)
        {
            await _context.NewsletterSubscribers.AddAsync(subscriber);
            await _context.SaveChangesAsync();
        }
    }
}

