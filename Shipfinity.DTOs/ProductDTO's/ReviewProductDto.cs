using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DTOs.ProductDTO_s
{
    public class ReviewProductDto
    {
        public string Comment { get; set; }
        [Required]
        public int Rating { get; set; }
        public int CustomerId { get; set; }
        //Added CustomerId
    }
}
