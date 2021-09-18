using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ParametroDetalleDto
    {
        public int IdParametroDetalle { get; set; }
        public int IdParametro { get; set; }
        public string Etiqueta { get; set; }
        public string Valor { get; set; }
        public string ValorExterno { get; set; }
        public string Nombre { get; set; }
    }
}
