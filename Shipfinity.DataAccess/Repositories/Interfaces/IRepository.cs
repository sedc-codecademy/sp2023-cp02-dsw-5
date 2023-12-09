using Shipfinity.Domain.Models;

namespace Shipfinity.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetRangeAsync(int start, int count);
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
    }
}
