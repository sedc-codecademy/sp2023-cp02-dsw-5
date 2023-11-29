using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.DTOs.OrderDTOs;
using Shipfinity.Mappers;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            var newOrder = OrderMappers.MapToOrder(orderCreateDto);
            await _orderRepository.InsertAsync(newOrder);
            return OrderMappers.MapToReadDto(newOrder);
        }

        public async Task DeleteOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null) throw new OrderNotFoundException(id);

            await _orderRepository.DeleteByIdAsync(id);
        }

        public async Task<List<OrderReadDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Select(OrderMappers.MapToReadDto).ToList();
        }

        public async Task<OrderReadDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null) throw new OrderNotFoundException(id);

            return OrderMappers.MapToReadDto(order);
        }

        public async Task<List<OrderReadDto>> GetOrderByProductIdAsync(int productId)
        {
            var orders = await _orderRepository.GetAllByProductIdAsync(productId);

            if (!orders.Any()) throw new OrderNotFoundException(productId);

            return orders.Select(OrderMappers.MapToReadDto).ToList();
        }

        public async Task<List<OrderReadDto>> GetOrderByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetAllByUserIdAsync(userId);

            if(!orders.Any()) throw new OrderNotFoundException(userId);

            return orders.Select(OrderMappers.MapToReadDto).ToList();
        }

        public async Task UpdateOrderAsync(int id, OrderUpdateDto orderUpdateDto)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);

            if (existingOrder == null) throw new OrderNotFoundException(id);

            OrderMappers.ApplyUpdateFromDto(existingOrder, orderUpdateDto);
            await _orderRepository.UpdateAsync(existingOrder);
        }
    }
}
