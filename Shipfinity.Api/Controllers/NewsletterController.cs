using Microsoft.AspNetCore.Mvc;
using Shipfinity.DTOs.EmailDTOs;
using Shipfinity.Services.Interfaces;

namespace Shipfinity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsletterService _newsletterService;
        private readonly IEmailService _emailService;

        public NewsletterController(INewsletterService newsletterService, IEmailService emailService)
        {
            _newsletterService = newsletterService;
            _emailService = emailService;
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Email address is required.");
            }
            try
            {
                await _newsletterService.SubscribeToNewsletter(email);

                var emailDto = new EmailDto
                {
                    To = email,
                    Subject = "Newsletter Subscription Confirmation",
                    Body = "<h1>Thank You for Subscribing!</h1><p>You have successfully subscribed to our newsletter.</p>"
                };

                await _emailService.SendEmailAsync(emailDto);

                return Ok("Subscribed successfully to the newsletter and a confirmation email has been sent.");
            }
            catch (FormatException ex)
            {
                return BadRequest($"Invalid email format: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
