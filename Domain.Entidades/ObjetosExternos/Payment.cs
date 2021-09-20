using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.ObjetosExternos
{
    public class Payment
    {
        public string Reference { get; set; }
        public string Description { get; set; }
        public Amount Amount { get; set; }
        public bool AllowPartial { get; set; }
    }

    public class Amount
    {
        public string Currency { get; set; }
        public string Total { get; set; }
    }
}