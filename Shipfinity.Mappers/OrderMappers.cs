﻿using Shipfinity.Domain.Models;
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
                CustomerId = order.CustomerId?? 0,
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
    }
}
