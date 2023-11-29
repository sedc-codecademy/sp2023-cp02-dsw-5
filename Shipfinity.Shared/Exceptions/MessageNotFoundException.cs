using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Shared.Exceptions
{
    public class MessageNotFoundException : Exception
    {
        public MessageNotFoundException(int id) : base($"Message with id:[{id}] was not found") { }
    }
}
