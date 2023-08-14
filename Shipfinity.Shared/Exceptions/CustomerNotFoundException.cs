using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Shared.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(int id) : base($"Customer with id: {id} not found")
        {}
    }
}
