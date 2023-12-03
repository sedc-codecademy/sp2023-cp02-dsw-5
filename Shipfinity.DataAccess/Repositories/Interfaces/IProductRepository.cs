using Shipfinity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<int> GetCount(int categoryId = 0);
        Task<List<Product>> GetAllByCategoryIdAsync(int categoryId);
        Task<List<Product>> GetRangeOrderedByPrice(int price, int start, int count);
        Task<List<Product>> GetRangeByCategoryId(int categoryId, int start, int count);
        Task UpdateProductPhotoUrlAsync(int productId, string photoUrl);
        Task<List<Product>> SearchProductsAsync(string keyword);
        Task AddProductReviewAsync(ReviewProduct reviewProduct);
        Task<List<Product>> GetProductsOnSaleAsync();
        Task<List<Product>> GetProductsBySellerIdAsync(int sellerId);
        Task<List<ReviewProduct>> GetProductReviewsByProductIdAsync(int productId);
    }
}
