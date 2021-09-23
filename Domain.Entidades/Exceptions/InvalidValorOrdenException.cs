using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.Exceptions
{
    public class InvalidValorOrdenException: Exception
    {
        public InvalidValorOrdenException() { }

        public InvalidValorOrdenException(string message)
            : base(message)
        { }
    }
}
