using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class MagnitudException: Exception
    {
        public MagnitudException() { }
        public MagnitudException(string message): base(message) { }
        public MagnitudException(string message, Exception innerException): base(message, innerException) { }
    }
}
