using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Parametro
    {
        public int IdParametro { get; set; }
        public string Nombre { get; set; }
        public string Etiqueta { get; set; }
        public List<ParametroDetalle> parametroDetalles { get; set; }
    }
}
