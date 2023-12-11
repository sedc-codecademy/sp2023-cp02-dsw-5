using Shipfinity.DTOs.AddressDTOs;

namespace Shipfinity.DTOs.OrderDTOs
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public AddressInputDto Address { get; set; }
        public List<OrderProductListDto> Products { get; set; }
        public string Email { get; set; }
    }
}
