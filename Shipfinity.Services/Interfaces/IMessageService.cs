    using Shipfinity.Domain.Models;
using Shipfinity.DTOs.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<Message> SendMessageAsync(MessageDto messageDto, string role);
        Task<List<MessageDto>> GetAllMessagesAsync();
        Task<MessageDto> GetMessageByIdAsync(int id);
        Task DeleteMessageAsync(int id);
        Task UpdateMessageAsync(int id, MessageDto messageDto);
    }
}
