using Shipfinity.Domain.Models;

namespace Shipfinity.Services.Interfaces
{
    public interface INewsletterService
    {
        Task SubscribeToNewsletterAsync(string email);
        Task<List<NewsletterSubscriber>> GetAllSubscribersAsync();
    }
}
