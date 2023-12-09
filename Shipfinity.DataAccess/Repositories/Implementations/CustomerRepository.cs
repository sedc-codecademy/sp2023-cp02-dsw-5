using Microsoft.EntityFrameworkCore;
using Shipfinity.DataAccess.Context;
using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.DataAccess.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(int id)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new CustomerNotFoundException(id);
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> GetByUsernameAsync(string username)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Username == username);
        }

        public async Task<List<Customer>> GetRangeAsync(int start, int count)
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .Skip(start)
                .Take(count)
                .ToListAsync();
        }

        public async Task InsertAsync(Customer entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer entity)
        {
            _context.Customers.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
