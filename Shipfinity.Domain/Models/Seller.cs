using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Domain.Models
{
    public class Seller : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}
