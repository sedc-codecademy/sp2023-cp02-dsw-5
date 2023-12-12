using Shipfinity.DTOs.CustomerDTOs;
using Shipfinity.DTOs.SellerDTO_s;
using Shipfinity.DTOs.UserDTOs;

namespace Shipfinity.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterCustomer(CustomerRegisterDto dto);
        Task RegisterSeller(SellerRegisterDto dto);
        Task<bool> InitialAdmin(SellerRegisterDto dto);
        Task<CustomerLoginResponseDto> LoginCustomer(UserLoginDto dto);
        Task<SellerLoginResponseDto> LoginSeller(UserLoginDto dto);
    }
}
