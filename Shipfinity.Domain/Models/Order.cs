using Shipfinity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Domain.Models
{
    public class Order : BaseEntity
    {
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public int CustomerId { get; set; }
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
