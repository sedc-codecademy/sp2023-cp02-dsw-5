using Shipfinity.Domain.Models;

namespace Shipfinity.DataAccess.Repositories.Interfaces
{
    public interface INewsletterRepository 
    {
        Task AddSubscriberAsync(NewsletterSubscriber subscriber);
    }
}
