using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using DomainService = Aplicacion
using DomainRepositories = Domain.Repositorios.Contratos;

namespace Presentacion.IoD
{
    /// <summary>
    /// Esta encargado de mapear y realizar la inyecci�n dependencias. 
    /// </summary>
    public class DependencyInjection
    {
        public void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            //Proporciona los Cors para aceptar las peticiones de un origen diferente a la URL que expone el API
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            });

            //Entrada unica para la configuración
            services.AddSingleton(configuration);

            //Aplicacion

            //Domain


            //Infraestructura
            //services.AddScoped<DomainRepositories.IParametroRepository, Infraestructura.Repositorios.Parametro>();
        }
    }
}
