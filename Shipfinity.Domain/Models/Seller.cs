using System.ComponentModel.DataAnnotations;

namespace Shipfinity.Domain.Models
{
    public class Seller : BaseUser
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}
