using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProducto { get; set; }
        [MaxLength(10)]
        public string Codigo { get; set; }
        [MaxLength(200)]
        public string Nombre { get; set; }

        public double ValorUnitario { get; set; }

        public virtual List<Orden> Ordens { get; set; }

        public ProductoDto ConvertirDto()
        {
            return new ProductoDto()
            {
                IdProducto = this.IdProducto,
                Codigo = this.Codigo,
                Nombre = this.Nombre,
                ValorUnitario = this.ValorUnitario
            };
        }
    }
}
