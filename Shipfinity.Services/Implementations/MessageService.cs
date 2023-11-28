using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using Shipfinity.DTOs.MessageDTOs;
using Shipfinity.Mappers;
using Shipfinity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message> SendMessageAsync(MessageDto messageDto, string role)
        {
            if(messageDto == null)
            {
                throw new ArgumentNullException(nameof(messageDto));
            }

            if(string.IsNullOrEmpty(role))
            {
                throw new ArgumentNullException(nameof(role));
            }

            var message = MessageMappers.MapToMessage(messageDto);
            message.Role = role;
            return await _messageRepository.CreateMessageAsync(message);
        }
    }
}
