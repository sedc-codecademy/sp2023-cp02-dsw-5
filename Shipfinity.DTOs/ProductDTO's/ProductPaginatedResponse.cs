namespace Shipfinity.DTOs.ProductDTO_s
{
    public class ProductPaginatedResponse
    {
        public int Count { get; set; }
        public List<ProductReadDto> Products { get; set; }
    }
}
