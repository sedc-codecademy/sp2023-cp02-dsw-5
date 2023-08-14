using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Shared.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException(int id) : base($"Category with id:[{id}] was not found") { }
    }
}
