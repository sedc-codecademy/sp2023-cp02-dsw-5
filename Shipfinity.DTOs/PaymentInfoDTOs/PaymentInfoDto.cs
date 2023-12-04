using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DTOs.PaymentInfoDTOs
{
    public class PaymentInfoDto
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; } 
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
    }
}
