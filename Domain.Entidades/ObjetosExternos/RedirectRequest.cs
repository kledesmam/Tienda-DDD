using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.ObjetosExternos
{
    public class RedirectRequest
    {
        public Auth Auth { get; set; }
        public string Locale { get; set; }
        public Buyer Buyer { get; set; }
        public Payment Payment { get; set; }
        public string Expiration { get; set; }
        public string ReturnUrl { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
    }
}
