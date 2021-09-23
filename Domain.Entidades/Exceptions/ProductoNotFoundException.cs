using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.Exceptions
{
    public class ProductoNotFoundException : Exception
    {
        public ProductoNotFoundException() { }

        public ProductoNotFoundException(string message)
            : base(message)
        { }
    }
}
