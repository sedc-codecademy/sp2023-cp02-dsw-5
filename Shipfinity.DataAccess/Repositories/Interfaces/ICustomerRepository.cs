using Shipfinity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DataAccess.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByUsernameAsync(string username);
        Task<Customer> GetByEmailAsync(string email);
    }
}
