using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Configuracion
{
    public class ClienteConfiguracion : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasData(new Cliente
            {
                IdCliente = 1,
                IdParametroDetalle = 1,
                Apellido = "Ledesma",
                Nombre = "Carlos",
                NumeroIdentificacion = 94557038,
                Celular = "3002211445",
                Email = "ingcaledesma@gmail.com"                
            }
            );
        }
    }
}
