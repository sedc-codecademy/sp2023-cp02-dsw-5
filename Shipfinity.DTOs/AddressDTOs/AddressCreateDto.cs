namespace Shipfinity.DTOs.AddressDTOs
{
    public class AddressInputDto
    {
        public int? Id { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
