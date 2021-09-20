using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.ObjetosExternos
{
    public class Auth
    {
        public string Login { get; set; }
        public string TranKey { get; set; }
        public string Nonce { get; set; }
        public string Seed { get; set; }
    }
}
