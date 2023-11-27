using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Domain.Models
{
    public class ReviewProduct : BaseEntity
    {
        public string Comment { get; set; }
        [Required]
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
