using Shipfinity.Domain.Enums;
using Shipfinity.Domain.Models;
using Shipfinity.DTOs.PaymentInfoDTOs;
using System.ComponentModel.DataAnnotations;

namespace Shipfinity.DTOs.OrderDTOs
{
    public class OrderCreateDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int AddressId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Range(0, 999999)]
        public double TotalPrice { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public PaymentInfoDto PaymentInfo { get; set; } = new();   
    }
}
