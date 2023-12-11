using Microsoft.EntityFrameworkCore;
using Shipfinity.DataAccess.Context;
using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.DataAccess.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteByIdAsync(int id)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                throw new OrderNotFoundException(id);
            }
            order.IsDeleted=true;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Address)
                .Include(o => o.ProductOrders)
                .ThenInclude(po => po.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetRangeAsync(int start, int count)
        {
            return await _context.Orders
                .Skip(start)
                .Take(count)
                .ToListAsync();
        }

        public async Task InsertAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.ProductOrders)
                .ThenInclude(po => po.Product)
                .Where(o => o.CustomerId == userId)
                .ToListAsync();
        }

        public async Task<List<Order>> GetAllByProductIdAsync(int productId)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.ProductOrders)
                .ThenInclude(po => po.Product)
                .Where(o => o.ProductOrders.Any(po => po.ProductId == productId))
                .ToListAsync();
        }

        public async Task<PaymentInfo> GetMatching(string CardNumber, string ExpirationDate)
        {
            return await _context.PaymentInfos.FirstOrDefaultAsync(x => x.CardNumber == CardNumber && x.ExpirationDate == ExpirationDate);
        }

        public async Task<int> CreateAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<List<Order>> GetAllBySellerAsync(int sellerId)
        {
            return await _context.Orders
                .Include(o => o.Address)
                .Include(o => o.Customer)
                .Include(o => o.ProductOrders)
                .ThenInclude(po => po.Product)
                .Where(o => o.ProductOrders.Any(p => p.Product.SellerId == sellerId))
                .ToListAsync();
        }
    }
}
