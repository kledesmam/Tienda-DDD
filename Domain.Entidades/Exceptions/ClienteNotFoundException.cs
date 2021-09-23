using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.Exceptions
{
    public class ClienteNotFoundException : Exception
    {
        public ClienteNotFoundException() { }

        public ClienteNotFoundException(string message) 
            :base(message)
        { }
    }
}
