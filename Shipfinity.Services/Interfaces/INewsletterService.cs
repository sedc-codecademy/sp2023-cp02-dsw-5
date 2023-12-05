namespace Shipfinity.Services.Interfaces
{
    public interface INewsletterService
    {
        Task SubscribeToNewsletter(string email);
    }
}
