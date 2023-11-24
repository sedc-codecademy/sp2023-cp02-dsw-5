using Shipfinity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Domain.Models
{
    public class Address : BaseEntity
    {
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Order> Orders { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
    }
}
