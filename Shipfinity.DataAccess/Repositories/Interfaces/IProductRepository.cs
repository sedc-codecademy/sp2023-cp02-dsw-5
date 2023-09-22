﻿using Shipfinity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllByCategoryIdAsync(int categoryId);
        Task<List<Product>> GetRangeOrderedByPrice(int price, int start, int count);


    }
}
