using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class OrdenDto
    {
        public int IdOrden { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int IdParametroDetalle { get; set; }
        public double Valor { get; set; }        
        public string RequestId { get; set; }
        public string UrlPago { get; set; }
        public string ReferenciaPago { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string EstadoOrden { get; set; }
                
    }
}
