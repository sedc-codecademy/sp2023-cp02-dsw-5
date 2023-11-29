using Shipfinity.Domain.Enums;
using Shipfinity.Domain.Models;
using Shipfinity.DTOs.CustomerDTOs;

namespace Shipfinity.Mappers
{
    public static class CustomerMappers
    {
        public static Customer ToCustomer(this CustomerRegisterDto dto)
        {
            return new Customer
            {
                Username = dto.Username.Trim(),
                Email = dto.Email.Trim(),
                FirstName = dto.FirstName.Trim(),
                LastName = dto.LastName.Trim(),
                Role = Roles.Customer
            };
        }

        public static CustomerLoginResponseDto ToLoginResponse(this Customer customer, string token)
        {
            return new CustomerLoginResponseDto
            {
                Id = customer.Id,
                Username = customer.Username,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Role = Roles.Customer,
                Token = token
            };
        }
    }
}
