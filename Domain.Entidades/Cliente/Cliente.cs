using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("IdParametroDetalle")]
        public virtual ParametroDetalle TipoIdentificacion { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Apellido { get; set; }
        public double NumeroIdentificacion { get; set; }
        [MaxLength(120)]
        public string Email { get; set; }
        [MaxLength(40)]
        public string Celular { get; set; }
        public virtual List<Orden> Ordens { get; set; }
    }
}
