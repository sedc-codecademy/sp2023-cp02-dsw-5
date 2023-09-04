using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DTOs.ProductDTO_s
{
    public class ProductCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [Range(0, 999999)]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }
    }
}
