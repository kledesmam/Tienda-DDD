using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.Exceptions
{
    public class PasarelaPagoException : Exception
    {
        public PasarelaPagoException() { }

        public PasarelaPagoException(string message)
            : base(message)
        { }
    }
}
