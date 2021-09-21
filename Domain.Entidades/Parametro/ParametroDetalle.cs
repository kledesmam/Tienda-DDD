using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ParametroDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdParametroDetalle { get; set; }
        public int IdParametro { get; set; }

        [ForeignKey("IdParametro")]
        public virtual Parametro Parametro { get; set; }
        [MaxLength(100)]
        public string Etiqueta { get; set; }
        [MaxLength(500)]
        public string Valor { get; set; }
        [MaxLength(100)]
        public string ValorExterno { get; set; }

        public ParametroDetalleDto ConvertirDto()
        {
            return new ParametroDetalleDto()
            {
                IdParametroDetalle = this.IdParametroDetalle,
                Etiqueta = this.Etiqueta,
                IdParametro = this.IdParametro,
                Nombre = this.Parametro.Nombre,
                Valor = this.Valor,
                ValorExterno = this.ValorExterno
            };
        }
    }
}
