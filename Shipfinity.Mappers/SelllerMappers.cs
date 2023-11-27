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
                Name = dto.FirstName.Trim() + " " + dto.LastName.Trim(),


                Role = Roles.Seller
            };
        }
    }
}
