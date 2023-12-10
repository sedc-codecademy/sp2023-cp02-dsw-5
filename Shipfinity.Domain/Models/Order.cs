using Shipfinity.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shipfinity.Domain.Models
{
    public class Order : BaseEntity
    {
        public Customer? Customer { get; set; }

        public int? CustomerId { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<ProductOrder> ProductOrders { get; set; } = new();
        public double TotalPrice { get; set; }
        public string Email { get; set; }   
        public PaymentInfo PaymentInfo { get; set; }
        public int PaymentInfoId { get; set; }
        public bool IsDeleted { get; set; } 

    }
}
