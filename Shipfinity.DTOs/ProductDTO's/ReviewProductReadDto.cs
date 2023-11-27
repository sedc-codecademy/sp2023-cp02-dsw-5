using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DTOs.ProductDTO_s
{
    public class ReviewProductReadDto
    {
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int ProductId { get; set; }
    }
}
