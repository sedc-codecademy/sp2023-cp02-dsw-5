using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using Shipfinity.DTOs.CustomerDTOs;
using Shipfinity.DTOs.UserDTOs;
using Shipfinity.Mappers;
using Shipfinity.Services.Helpers;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shipfinity.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;
        public AuthService(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
            _configuration = configuration;
        }

        public async Task<CustomerLoginResponseDto> LoginCustomer(UserLoginDto dto)
        {
            Customer customer = await _customerRepository.GetByUsernameAsync(dto.Username);
            if (customer == null)
            {
                throw new BadCredentialsException();
            }

            if (!customer.VerifyPassword(dto.Password))
            {
                throw new BadCredentialsException();
            }
            string token = GenerateToken(customer);
            return customer.ToLoginResponse(token);
        }

        public async Task RegisterCustomer(CustomerRegisterDto dto)
        {
            if (string.IsNullOrEmpty(dto.Username) || string.IsNullOrEmpty(dto.Password) || string.IsNullOrEmpty(dto.Email))
            {
                throw new UserRegisterException("Username password and email are required fields");
            }

            if (await _customerRepository.GetByUsernameAsync(dto.Username.Trim()) != null)
            {
                throw new UserRegisterException("Username is already taken");
            }

            Customer customer = dto.ToCustomer();
            AuthHelper.HashPassword(dto.Password, out byte[] hash, out byte[] salt);
            customer.PasswordHash = hash;
            customer.PasswordSalt = salt;
        }

        private string GenerateToken(BaseUser user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            Claim[] claims = new Claim[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:Expire"])),
                SigningCredentials = credentials,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
