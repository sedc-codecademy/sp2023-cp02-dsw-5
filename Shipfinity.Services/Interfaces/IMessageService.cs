using Shipfinity.Domain.Models;
using Shipfinity.DTOs.MessageDTOs;

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
