using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.Exceptions
{
    public class ClienteExisteException: Exception
    {
        public ClienteExisteException() { }

        public ClienteExisteException(string message)
            : base(message)
        { }
    }
}
