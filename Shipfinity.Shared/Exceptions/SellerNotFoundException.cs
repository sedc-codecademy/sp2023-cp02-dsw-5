using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Shared.Exceptions
{
    public class SellerNotFoundException : Exception
    {
        public SellerNotFoundException(int id) :base($"Seller with id: {id} not found")
        {}
    }
}
