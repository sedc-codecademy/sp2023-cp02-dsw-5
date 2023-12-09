﻿using Shipfinity.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shipfinity.DTOs.OrderDTOs
{
    public class OrderUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Range(0, 999999)]
        public double TotalPrice { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public int AddressId { get; set; }
    }
}
