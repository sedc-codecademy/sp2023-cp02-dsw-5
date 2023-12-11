using Shipfinity.Domain.Models;
using Shipfinity.DTOs.OrderDTOs;
using System.Runtime.CompilerServices;

namespace Shipfinity.Mappers
{
    public static class OrderMappers
    {
        public static OrderReadDto MapToReadDto(Order order)
        {
            return new OrderReadDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId ?? 0,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                AddressId = order.AddressId
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

        public static OrderSellerListDto ToSellerOrderList(this Order order)
        {
            return new OrderSellerListDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Status = order.Status.ToString(),
                TotalPrice = order.TotalPrice,
                Address = $"{order.Address.AddressLine} / {order.Address.City} / {order.Address.Country}"
            };
        }

        public static OrderDetailsDto ToOrderDetails(this Order order)
        {
            return new OrderDetailsDto
            {
                Id = order.Id,
                Email = order.Email,
                Address = new()
                {
                    Id = order.AddressId,
                    AddressLine = order.Address.AddressLine,
                    City = order.Address.City,
                    Country = order.Address.Country,
                    ZipCode = order.Address.ZipCode
                },
                Products = order.ProductOrders
                .Select(p => new OrderProductListDto
                {
                    Name = p.Product.Name,
                    Price = p.Product.Price,
                    DiscountPercentage = p.Product.DiscountPercentage
                })
                .ToList()
            };
        }
    }
}