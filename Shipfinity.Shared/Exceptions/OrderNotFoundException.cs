using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Shared.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(int id) : base($"Order with id: {id} not found") { }
    }
}
