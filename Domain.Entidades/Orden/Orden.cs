using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Orden
    {
        [Key]
        public int IdOrden { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int IdParametroDetalle { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }
        public double Valor { get; set; }
        [MaxLength(200)]
        public string RequestId { get; set; }
        [MaxLength(200)]
        public string UrlPago { get; set; }
        [MaxLength(200)]
        public string ReferenciaPago { get; set; }

        [ForeignKey("IdParametroDetalle")]
        public virtual ParametroDetalle Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual List<OrdenLog> OrdenLogs { get; set; }
    }
}
