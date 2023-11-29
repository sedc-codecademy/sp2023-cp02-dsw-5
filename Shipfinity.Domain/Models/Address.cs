using System.ComponentModel.DataAnnotations;

namespace Shipfinity.Domain.Models
{
    public class Address : BaseEntity
    {
        [MaxLength(100)]
        public string AddressLine { get; set; }
        [MaxLength(10)]
        public string ZipCode { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        public List<Order> Orders { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
    }
}
