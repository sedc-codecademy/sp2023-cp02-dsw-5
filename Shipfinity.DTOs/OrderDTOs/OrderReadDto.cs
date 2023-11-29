using Shipfinity.Domain.Enums;
using Shipfinity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DTOs.OrderDTOs
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public int AddressId { get; set; }
    }
}
