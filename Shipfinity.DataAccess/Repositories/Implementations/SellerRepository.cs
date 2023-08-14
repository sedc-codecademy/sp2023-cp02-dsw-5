using Microsoft.EntityFrameworkCore;
using Shipfinity.DataAccess.Context;
using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using Shipfinity.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DataAccess.Repositories.Implementations
{
    public class SellerRepository : ISellerRepository
    {
        private readonly AppDbContext _context;
        public SellerRepository(AppDbContext context)
        {
            _context = context;
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

        public async Task<Seller> GetByIdAsync(int id)
        {
            return await _context.Sellers.FirstOrDefaultAsync(s => s.Id == id);
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
