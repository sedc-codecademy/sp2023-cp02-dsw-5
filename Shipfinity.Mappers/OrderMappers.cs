using Shipfinity.Domain.Models;
using Shipfinity.DTOs.OrderDTOs;

namespace Shipfinity.Mappers
{
    public class OrderMappers
    {
        public static OrderReadDto MapToReadDto(Order order)
        {
            return new OrderReadDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                AddressId = order.AddressId
            };
        }

        public static Order MapToOrder(OrderCreateDto orderCreateDto)
        {
            return new Order
            {
                CustomerId = orderCreateDto.CustomerId,
                OrderDate = orderCreateDto.OrderDate,
                TotalPrice = orderCreateDto.TotalPrice,
                Status = orderCreateDto.Status,
                AddressId = orderCreateDto.AddressId
            };
        }

        public static void ApplyUpdateFromDto(Order order, OrderUpdateDto orderUpdateDto)
        {
            order.CustomerId = orderUpdateDto.CustomerId;
            order.OrderDate = orderUpdateDto.OrderDate;
            order.TotalPrice = orderUpdateDto.TotalPrice;
            order.Status = orderUpdateDto.Status;
            order.AddressId = orderUpdateDto.AddressId;
        }
    }
}
