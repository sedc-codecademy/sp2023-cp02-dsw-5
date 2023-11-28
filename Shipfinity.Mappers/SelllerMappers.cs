using Shipfinity.Domain.Enums;
using Shipfinity.Domain.Models;
using Shipfinity.DTOs.SellerDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Mappers
{
    public static class SelllerMappers
    {
        public static Seller ToSeller(this SellerRegisterDto dto)
        {
            return new Seller
            {
                Username = dto.Username.Trim(),
                Email = dto.Email.Trim(),
                Name = dto.Name.Trim(),
                Address = dto.Address?.Trim(), 
                PhoneNumber = dto.PhoneNumber?.Trim(), 
                Role = Roles.Seller
            };
        }

        public static SellerLoginResponseDto ToLoginResponse(this Seller seller, string token)
        {
            return new SellerLoginResponseDto
            {
                Id = seller.Id,
                Username = seller.Username,
                Email = seller.Email,
                Role = Roles.Seller,
                Token = token
            };
        }
    }
}
