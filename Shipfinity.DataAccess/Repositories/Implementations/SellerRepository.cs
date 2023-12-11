using Microsoft.EntityFrameworkCore;
using Shipfinity.DataAccess.Context;
using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Enums;
using Shipfinity.Domain.Models;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.DataAccess.Repositories.Implementations
{
    public class SellerRepository : ISellerRepository
    {
        private readonly AppDbContext _context;
        public SellerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAdminsAsync()
        {
            return  await _context.Sellers.CountAsync(x => x.Role == Roles.Admin);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Seller seller = await _context.Sellers.FirstOrDefaultAsync(s => s.Id == id);
            if(seller == null)
            {
                throw new SellerNotFoundException(id);
            }
            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Seller>> GetAllAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task<Seller> GetByEmailAsync(string email)
        {
            return await _context.Sellers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Seller> GetByIdAsync(int id)
        {
            return await _context.Sellers.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Seller> GetByUsernameAsync(string username)
        {
            return await _context.Sellers.FirstOrDefaultAsync(s => s.Username == username);
            
        }

        public async Task<List<Seller>> GetRangeAsync(int start, int count)
        {
            return await _context.Sellers
                .Skip(start)
                .Take(count)
                .ToListAsync();
        }

        public async Task InsertAsync(Seller entity)
        {
            await _context.Sellers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller entity)
        {
            _context.Sellers.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
