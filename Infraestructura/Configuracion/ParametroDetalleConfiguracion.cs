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
    public class ParametroDetalleConfiguracion : IEntityTypeConfiguration<ParametroDetalle>
    {
        public void Configure(EntityTypeBuilder<ParametroDetalle> builder)
        {
            builder.ToTable("ParametroDetalle");
            builder.HasData
                (
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 1,
                        IdParametro = 1,
                        Etiqueta = "CC",
                        Valor = "Cédula Ciudadanía",
                        ValorExterno = "CC"
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 2,
                        IdParametro = 1,
                        Etiqueta = "CE",
                        Valor = "Cédula Extranjería",
                        ValorExterno = "CE"
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 3,
                        IdParametro = 1,
                        Etiqueta = "TI",
                        Valor = "Tarjeta de Identidad",
                        ValorExterno = "TI"
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 4,
                        IdParametro = 1,
                        Etiqueta = "NIT",
                        Valor = "Número de Identificación Tributaria",
                        ValorExterno = "TI"
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 5,
                        IdParametro = 2,
                        Etiqueta = "ESTADO-CREATED",
                        Valor = "CREATED",
                        ValorExterno = "CREATED"
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 6,
                        IdParametro = 2,
                        Etiqueta = "ESTADO-PAYED",
                        Valor = "PAYED",
                        ValorExterno = "PAYED"
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 7,
                        IdParametro = 2,
                        Etiqueta = "ESTADO-REJECTED",
                        Valor = "REJECTED",
                        ValorExterno = "REJECTED"
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 8,
                        IdParametro = 3,
                        Etiqueta = "PASARELA-LOGIN",
                        Valor = "6dd490faf9cb87a9862245da41170ff2",
                        ValorExterno = string.Empty
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 9,
                        IdParametro = 3,
                        Etiqueta = "PASARELA-TRANKEY",
                        Valor = "024h1IlD",
                        ValorExterno = string.Empty
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 10,
                        IdParametro = 3,
                        Etiqueta = "PASARELA-URL-BASE",
                        Valor = "https://test.placetopay.com/redirection/api/session/",
                        ValorExterno = string.Empty
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 11,
                        IdParametro = 3,
                        Etiqueta = "PASARELA-LOCALE",
                        Valor = "en_CO",
                        ValorExterno = string.Empty
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 12,
                        IdParametro = 3,
                        Etiqueta = "PASARELA-CURRENCY",
                        Valor = "COP",
                        ValorExterno = string.Empty
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 13,
                        IdParametro = 3,
                        Etiqueta = "PASARELA-DIAS-EXPIRA",
                        Valor = "5",
                        ValorExterno = string.Empty
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 14,
                        IdParametro = 3,
                        Etiqueta = "PASARELA-AGENTE",
                        Valor = "PlacetoPay Sandbox",
                        ValorExterno = string.Empty
                    },
                    new ParametroDetalle
                    {
                        IdParametroDetalle = 15,
                        IdParametro = 3,
                        Etiqueta = "PASARELA-URL-RETORNO",
                        Valor = "https://localhost:44342/api/orden",
                        ValorExterno = string.Empty
                    }
                );
        }
    }
}
