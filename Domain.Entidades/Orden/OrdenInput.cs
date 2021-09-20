using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class OrdenInput
    {
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public double Valor { get; set; }
    }
}
