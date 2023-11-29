using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using Shipfinity.DTOs.MessageDTOs;
using Shipfinity.Mappers;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;
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

        public async Task DeleteMessageAsync(int id)
        {
            await _messageRepository.DeleteByIdAsync(id);
        }

        public async Task<List<MessageDto>> GetAllMessagesAsync()
        {
            var messages = await _messageRepository.GetAllAsync();
            return messages.Select(MessageMappers.MapToMessageDto).ToList();
        }

        public async Task<MessageDto> GetMessageByIdAsync(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);
            return MessageMappers.MapToMessageDto(message);
        }

        public async Task<Message> SendMessageAsync(MessageDto messageDto, string role)
        {
            if (messageDto == null)
            {
                throw new ArgumentNullException(nameof(messageDto));
            }

            if (string.IsNullOrEmpty(role))
            {
                throw new ArgumentNullException(nameof(role));
            }

            var message = MessageMappers.MapToMessage(messageDto);
            message.Role = role;
            await _messageRepository.InsertAsync(message);
            return message;
        }

        public async Task UpdateMessageAsync(int id, MessageDto messageDto)
        {
            if (messageDto == null)
            {
                throw new ArgumentNullException(nameof(messageDto));
            }

            var existingMessage = await _messageRepository.GetByIdAsync(id);

            if (existingMessage == null)
            {
                throw new MessageNotFoundException(id);
            }

            var updatedMessage = MessageMappers.MapToMessage(messageDto);
            updatedMessage.Id = id;

            await _messageRepository.UpdateAsync(updatedMessage);
        }
    }
}
