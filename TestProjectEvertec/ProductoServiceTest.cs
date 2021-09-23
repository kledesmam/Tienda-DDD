using Aplicacion.Aplicacion.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentacion;
using System.IO;
using System.Linq;

namespace TestProjectEvertec
{
    [TestClass]
    public class ProductoServiceTest
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
        public void ConsultarProducto_DebeRetornarElementos()
        {
            this.ClassInitialize();
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IProductoService>();

            var result = context.GetProductos();
            Assert.IsTrue(result != null && result.Any());
        }
    }
}
