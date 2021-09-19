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
    public class ParametroConfiguracion : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.ToTable("Parametro");
            builder.HasData
                (
                    new Parametro
                    {
                        IdParametro = 1,
                        Etiqueta = "TIPOS-DOCUMENTOS",
                        Nombre = "Tipos de Documento de identidad"
                    },
                    new Parametro
                    {
                        IdParametro = 2,
                        Etiqueta = "ESTADOS-ORDEN",
                        Nombre = "Estado Orden"
                    },
                    new Parametro
                    {
                        IdParametro = 3,
                        Etiqueta = "PASARELA-PAGOS",
                        Nombre = "Parametros pasarela pagos"
                    }
                );
        }
    }
}
