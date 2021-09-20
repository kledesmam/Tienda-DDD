using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.ObjetosExternos
{
    public class RedirectInformation
    {
        public Estado Status { get; set; }                
        public RedirectRequest Request { get; set; }
        public int RequestId { get; set; }
    }
}
