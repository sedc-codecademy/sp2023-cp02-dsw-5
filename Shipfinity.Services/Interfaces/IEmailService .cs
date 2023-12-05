using Shipfinity.DTOs.EmailDTOs;

namespace Shipfinity.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailDto request);
    }
}
