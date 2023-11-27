using Shipfinity.Domain.Models;

namespace Shipfinity.DataAccess.Repositories.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<Message> CreateMessage(Message message);
    }
}
