using System.ComponentModel.DataAnnotations;

namespace Shipfinity.DTOs.ProductDTO_s
{
    public class ReviewProductDto
    {
        public string Comment { get; set; }
        [Required]
        public int Rating { get; set; }
        public int CustomerId { get; set; }
    }
}
