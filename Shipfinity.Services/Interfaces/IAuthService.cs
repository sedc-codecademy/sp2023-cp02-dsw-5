using Shipfinity.DTOs.CustomerDTOs;
using Shipfinity.DTOs.UserDTOs;

namespace Shipfinity.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterCustomer(CustomerRegisterDto dto);
        Task<CustomerLoginResponseDto> LoginCustomer(UserLoginDto dto);
    }
}
