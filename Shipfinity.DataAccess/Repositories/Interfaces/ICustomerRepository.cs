using Shipfinity.Domain.Models;

namespace Shipfinity.DataAccess.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByUsernameAsync(string username);
        Task<Customer> GetByEmailAsync(string email);
    }
}
