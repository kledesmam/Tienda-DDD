using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("IdOrden")]
        public virtual Orden Orden { get; set; }
        [MaxLength(200)]
        public string RequestId { get; set; }
        [MaxLength(200)]
        public string UrlPago { get; set; }
        [MaxLength(200)]
        public string ReferenciaPago { get; set; }
        public string Observacion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
