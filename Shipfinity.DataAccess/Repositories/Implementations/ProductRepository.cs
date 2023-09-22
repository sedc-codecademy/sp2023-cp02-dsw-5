﻿using Microsoft.EntityFrameworkCore;
using Shipfinity.DataAccess.Context;
using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.DataAccess.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<List<Product>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<List<Product>> GetRangeAsync(int start, int count)
        {
            return await _context.Products
                .Include(p => p.Seller)
                .Skip(start)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<Product>> GetRangeOrderedByPrice(int price, int start, int count)
        {
            return await _context.Products
                .Include(p => p.Seller)
                .OrderBy(p => p.Price)
                .Skip(start)
                .Take(count)
                .ToListAsync();
        }

        public async Task InsertAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
