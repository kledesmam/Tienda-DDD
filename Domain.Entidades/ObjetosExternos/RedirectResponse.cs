using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.ObjetosExternos
{
    public class RedirectResponse
    {
        public Estado Status { get; set; }
        public int RequestId { get; set; }
        public string ProcessUrl { get; set; }
    }
}
