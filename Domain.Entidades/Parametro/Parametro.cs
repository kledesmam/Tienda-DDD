using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Parametro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdParametro { get; set; }
        [MaxLength(200)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Etiqueta { get; set; }
        public virtual List<ParametroDetalle> parametroDetalles { get; set; }
    }
}
