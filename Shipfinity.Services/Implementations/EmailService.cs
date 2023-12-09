using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Shipfinity.DTOs.EmailDTOs;
using Shipfinity.Services.Interfaces;
using System.Threading.Tasks;

namespace Shipfinity.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(EmailDto request)
        {
            if (string.IsNullOrWhiteSpace(request.To) || string.IsNullOrWhiteSpace(request.Subject) || string.IsNullOrWhiteSpace(request.Body))
            {
                throw new ArgumentException("Email, subject, and body cannot be null or empty.");
            }

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["Email:Username"]));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            // Bypass SSL certificate validation (Only for testing purposes)
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await smtp.ConnectAsync(_config["Email:Host"], 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_config["Email:Username"], _config["Email:Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
