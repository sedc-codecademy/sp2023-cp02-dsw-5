using System.ComponentModel.DataAnnotations;

namespace Shipfinity.DTOs.ProductDTO_s
{
    public class ProductUpdateDto
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

        [Required]
        [Range(0, 100)]
        public int DiscountPercentage { get; set; }
    }
}
