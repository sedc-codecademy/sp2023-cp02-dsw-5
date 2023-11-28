using Shipfinity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DataAccess.Repositories.Interfaces
{
    public interface ISellerRepository : IRepository<Seller>
    {
        Task<Seller> GetByUsernameAsync(string username);
        Task<Seller> GetByEmailAsync(string email);
    }
}
