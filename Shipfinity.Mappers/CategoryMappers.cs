using Shipfinity.Domain.Models;
using Shipfinity.ViewModels.CategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Mappers
{
    public static class CategoryMappers
    {
        public static Category ToCategory(this CategoryCreateViewModel cat)
        {
            return new Category
            {
                Name = cat.Name,
                Products = new List<Product>()
            };
        }
    }
}
