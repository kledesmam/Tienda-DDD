using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class OrdenLog
    {
        [Key]
        public int IdOrdenLog { get; set; }
        public int IdOrden { get; set; }
        public Orden Orden { get; set; }
        public string RequestId { get; set; }
        public string UrlPago { get; set; }
        public string ReferenciaPago { get; set; }
        public string Observacion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
