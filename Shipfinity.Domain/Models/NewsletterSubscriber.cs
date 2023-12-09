using System.ComponentModel.DataAnnotations;

namespace Shipfinity.Domain.Models
{
    public class NewsletterSubscriber:BaseEntity
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public DateTime SubscriptionDate { get; set; } = DateTime.UtcNow;

        public DateTime? LastEmailSentDate { get; set; } = null;
    }
}
