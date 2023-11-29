using Shipfinity.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderReadDto>> GetAllOrdersAsync();
        Task<OrderReadDto> GetOrderByIdAsync(int id);
        Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderCreateDto);
        Task UpdateOrderAsync(int id, OrderUpdateDto orderUpdateDto);
        Task DeleteOrderByIdAsync(int id);
        Task<List<OrderReadDto>> GetOrderByUserIdAsync(int userId);
        Task<List<OrderReadDto>> GetOrderByProductIdAsync(int productId);
    }
}
