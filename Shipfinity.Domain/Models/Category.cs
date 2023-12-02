using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Domain.Models
{
    public class Category : BaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(20)]
        public string DisplayName { get; set; } = string.Empty;
        public List<Product> Products { get; set; }
    }
}
