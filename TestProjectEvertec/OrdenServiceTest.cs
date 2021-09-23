using Aplicacion.Aplicacion.Services.Interface;
using Domain.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentacion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectEvertec
{
    [TestClass]
    public class OrdenServiceTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        //[ClassInitialize]
        public void ClassInitialize()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            _scopeFactory = services.AddLogging().BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void CrearOrden_ProductoNoExistente()
        {
            this.ClassInitialize();
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IOrdenService>();

            OrdenInput ordenInput = new OrdenInput()
            {
                IdCliente = 1,
                IdProducto=-1,
                Valor = 10000
            };

            Assert.ThrowsException<Exception>(() => context.CrearOrden(ordenInput));
        }

        [TestMethod]
        public void CrearOrden_ParametroEntradaNulo()
        {
            this.ClassInitialize();
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IOrdenService>();

            OrdenInput ordenInput = null;

            Assert.ThrowsException<Exception>(() => context.CrearOrden(ordenInput));
        }

        [TestMethod]
        public void CrearOrden_ClienteNoExiste()
        {
            this.ClassInitialize();
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IOrdenService>();

            OrdenInput ordenInput = new OrdenInput()
            {
                IdCliente = -1,
                IdProducto = 0,
                Valor = 10000
            };

            Assert.ThrowsException<Exception>(() => context.CrearOrden(ordenInput));
        }

        [TestMethod]
        public void CrearOrden_ValorNegativo()
        {
            this.ClassInitialize();
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IOrdenService>();

            OrdenInput ordenInput = new OrdenInput()
            {
                IdCliente = 1,
                IdProducto = 1,
                Valor = -10000
            };

            Assert.ThrowsException<Exception>(() => context.CrearOrden(ordenInput));
        }

        [TestMethod]
        public void CrearOrden_Exitoso()
        {
            this.ClassInitialize();
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IOrdenService>();

            OrdenInput ordenInput = new OrdenInput()
            {
                IdCliente = 1,
                IdProducto = 1,
                Valor = 10000
            };

            var resultado = context.CrearOrden(ordenInput);
            Assert.IsTrue(resultado != null && resultado.IdOrden > 0);
        }
    }
}
