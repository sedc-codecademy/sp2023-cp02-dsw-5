using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        Recived,
        Shipped,
        Delivered,
        Canceled
    }
}
