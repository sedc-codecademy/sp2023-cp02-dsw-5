namespace Shipfinity.DTOs.ProductDTO_s
{
    public class ReviewProductReadDto
    {
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
