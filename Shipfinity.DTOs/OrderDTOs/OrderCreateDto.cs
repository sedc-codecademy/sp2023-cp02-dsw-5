using Shipfinity.Domain.Enums;
using Shipfinity.DTOs.AddressDTOs;
using Shipfinity.DTOs.PaymentInfoDTOs;
using System.ComponentModel.DataAnnotations;

namespace Shipfinity.DTOs.OrderDTOs
{
    public class OrderCreateDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        public AddressInputDto Address { get; set; }

        public OrderProductDto[] OrderDetails { get; set; }

        public PaymentInfoDto PaymentInfo { get; set; } = new();   
    }
}
