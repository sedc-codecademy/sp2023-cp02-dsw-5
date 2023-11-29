using Shipfinity.Domain.Models;
using Shipfinity.DTOs.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Mappers
{
    public static class MessageMappers
    {
        public static MessageDto MapToMessageDto(Message message)
        {
            return new MessageDto
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                Email = message.Email,
                Subject = message.Subject,
                Content = message.Content
            };
        }

        public static Message MapToMessage(MessageDto messageDto)
        {
            return new Message
            {
                FirstName = messageDto.FirstName,
                LastName = messageDto.LastName,
                Email = messageDto.Email,
                Subject = messageDto.Subject,
                Content = messageDto.Content
            };
        }
    }
}
