using Shipfinity.Domain.Models;

namespace Shipfinity.DataAccess.Repositories.Interfaces
{
    public interface ISellerRepository : IRepository<Seller>
    {
        Task<Seller> GetByUsernameAsync(string username);
        Task<Seller> GetByEmailAsync(string email);
    }
}
