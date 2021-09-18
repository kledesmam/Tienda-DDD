using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public int IdParametroDetalle { get; set; }
        public ParametroDetalle TipoIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double NumeroIdentificacion { get; set; }        
        public string Email { get; set; }
        public string Celular { get; set; }
        public List<Orden> Ordens { get; set; }
    }
}
