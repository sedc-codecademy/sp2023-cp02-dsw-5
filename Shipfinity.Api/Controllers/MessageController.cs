using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipfinity.DTOs.MessageDTOs;
using Shipfinity.Services.Interfaces;
using System.Security.Claims;

namespace Shipfinity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageDto messageDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var message = await _messageService.SendMessageAsync(messageDto, role);
            return Ok(message);
        }
    }
}
