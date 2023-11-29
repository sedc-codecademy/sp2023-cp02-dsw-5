namespace Shipfinity.DTOs.CustomerDTOs
{
    public class CustomerLoginResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role {  get; set; }
        public string Token { get; set; }
    }
}
