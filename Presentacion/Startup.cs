using Infraestructura;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DomainRepositories = Domain.Repositorios.Contratos;
using AplicacionService = Aplicacion.Aplicacion.Services;
using DomainService = Domain.Domain.Servicios;

namespace Presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterServices(IServiceCollection services /*, IConfigurationRoot configuration*/)
        {
            //Proporciona los Cors para aceptar las peticiones de un origen diferente a la URL que expone el API
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            });

            //Entrada unica para la configuración
            //services.AddSingleton(configuration);

            //Aplicacion
            services.AddScoped<AplicacionService.Interface.IParametroService, AplicacionService.Implementacion.ParametroService>();
            services.AddScoped<AplicacionService.Interface.IProductoService, AplicacionService.Implementacion.ProductoService>();
            services.AddScoped<AplicacionService.Interface.IClienteService, AplicacionService.Implementacion.ClienteService>();

            //Domain
            services.AddScoped<DomainService.Interface.IParametroService, DomainService.Implementacion.ParametroService>();

            //Infraestructura
            services.AddScoped<DomainRepositories.IParametroRepository, Infraestructura.Repositorios.ParametroRepository>();
            services.AddScoped<DomainRepositories.IParametroDetalleRepository, Infraestructura.Repositorios.ParametroDetalleRepository>();
            services.AddScoped<DomainRepositories.IClienteRepository, Infraestructura.Repositorios.ClienteRepository>();
            services.AddScoped<DomainRepositories.IOrdenRepository, Infraestructura.Repositorios.OrdenRepository>();
            services.AddScoped<DomainRepositories.IProductoRepository, Infraestructura.Repositorios.ProductoRepository>();
            services.AddScoped<DomainRepositories.IUnitOfWork, Infraestructura.Repositorios.UnitOfWork>();

            //Context
            services.AddDbContext<EvertecContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EvertecConnection")));
        }
    }
}
