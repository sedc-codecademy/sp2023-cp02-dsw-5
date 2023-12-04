using Shipfinity.DTOs.PaymentInfoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.DTOs.OrderDTOs
{
    public class OrderPaymentDto:OrderCreateDto
    {
        public PaymentInfoDto PaymentInfo { get; set; }
    }
}
