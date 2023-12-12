using Shipfinity.DTOs.OrderDTOs;

namespace Shipfinity.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderReadDto>> GetAllOrdersAsync();
        Task<OrderReadDto> GetOrderByIdAsync(int id);
        Task<List<OrderSellerListDto>> GetBySellerIdAsync(int sellerId);
        Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderCreateDto, int customerId);
        Task UpdateOrderAsync(int id, OrderUpdateDto orderUpdateDto);
        Task DeleteOrderByIdAsync(int id);
        Task<List<OrderReadDto>> GetOrderByUserIdAsync(int userId);
        Task<List<OrderReadDto>> GetOrderByProductIdAsync(int productId);
        Task<string> ShipOrderAsync(int orderId);
        Task<OrderDetailsDto> GetOrderDetailsAsync(int orderId);
        Task<string> DeliverOrder(int orderId);
    }
}
