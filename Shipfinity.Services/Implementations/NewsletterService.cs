using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using Shipfinity.Services.Interfaces;
using System.Net.Mail;

namespace Shipfinity.Services.Implementations
{
    public class NewsletterService: INewsletterService
    {
        private readonly INewsletterRepository _newsletterRepository;

        public NewsletterService(INewsletterRepository newsletterRepository)
        {
            _newsletterRepository = newsletterRepository;
        }

        public async Task<List<NewsletterSubscriber>> GetAllSubscribersAsync()
        {
            return await _newsletterRepository.GetAllAsync();
        }

        public async Task SubscribeToNewsletterAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty.");
            }

            if (!IsValidEmail(email))
            {
                throw new FormatException("Invalid email format.");
            }

            var subscriber = new NewsletterSubscriber
            {
                Email = email,
                SubscriptionDate = DateTime.UtcNow
            };

            await _newsletterRepository.InsertAsync(subscriber);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

