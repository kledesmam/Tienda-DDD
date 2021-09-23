using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.Exceptions
{
    public class ObjectValueInvalidException: Exception
    {
        public ObjectValueInvalidException() { }

        public ObjectValueInvalidException(string message)
            : base(message)
        { }
    }
}
