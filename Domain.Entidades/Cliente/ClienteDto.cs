using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public int IdTipoIdentificacion { get; set; }                
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double NumeroIdentificacion { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string TipoIdentificacion { get; set; }
    }
}
