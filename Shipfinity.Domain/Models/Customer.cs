using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Domain.Models
{
    public class Customer : BaseUser
    {
        public Address? Address { get; set; }
        public int? AddressId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new();
        public List<ReviewProduct> ReviewProducts { get; set; } = new();
    }
}
