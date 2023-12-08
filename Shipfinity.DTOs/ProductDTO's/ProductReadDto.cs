namespace Shipfinity.DTOs.ProductDTO_s
{
    public class ProductReadDto
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }
            public int CategoryId { get; set; }
            public string? ImageUrl { get; set; }
            public double Rating { get; set; }
    }
}
