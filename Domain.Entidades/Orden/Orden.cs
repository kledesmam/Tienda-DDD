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

        public OrdenDto ConvertirDto()
        {
            return new OrdenDto()
            {
                IdOrden = this.IdOrden,
                IdCliente = this.IdCliente,
                IdParametroDetalle = this.IdParametroDetalle,
                IdProducto = this.IdProducto,
                ReferenciaPago = this.ReferenciaPago,
                RequestId = this.RequestId,
                UrlPago = this.UrlPago,
                Valor = this.Valor,
                FechaCreacion = this.FechaCreacion,
                FechaModificacion = this.FechaModificacion,
                EstadoOrden = this.Estado != null ? this.Estado.Valor : string.Empty,
                ApellidoCliente = this.Cliente.Apellido,
                NombreCliente = this.Cliente.Nombre,
                EmailCliente = this.Cliente.Email,
                IdentificacionCliente = this.Cliente.NumeroIdentificacion.ToString(),
                TipoIdentificacionCliente = this.Cliente.TipoIdentificacion.Valor,
                CodigoProducto = this.Producto.Codigo,
                NombreProducto = this.Producto.Nombre
            };
        }
    }
}
