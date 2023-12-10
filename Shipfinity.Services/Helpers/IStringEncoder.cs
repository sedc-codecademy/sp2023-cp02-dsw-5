using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Services.Helpers
{
    public interface IStringEncoder
    {
        string Encode(string value);
        string Decode(string value);
    }
}
