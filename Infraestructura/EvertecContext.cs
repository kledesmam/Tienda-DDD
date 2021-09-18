using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class EvertecContext : DbContext
    {
        public EvertecContext(DbContextOptions<EvertecContext> options) : base(options) { }
        public EvertecContext() { }

        /// <summary>
        /// Obiete la cadena de conexión del archivo appsettings.json del proyecto de arranque de la capa de presentación
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // get the configuration from the app settings
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("EvertecConnection"));
            }

        }

        /// <summary>
        /// Crea modelo al cual se le puede hacer operaciones de Query o Persistencia
        /// esta relacionado con una tabla en la base de datos
        /// </summary>
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<ParametroDetalle> ParametroDetalles { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenLog> OrdenLogs { get; set; }

        /// <summary>
        /// Esta encargado de mapear los atributos de la indentidad 
        /// con los nombre de columna de la base de datos.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orden>().Property(x => x.IdOrden).UseIdentityColumn();
            modelBuilder.Entity<OrdenLog>().Property(x => x.IdOrdenLog).UseIdentityColumn();
            modelBuilder.Entity<Cliente>().Property(x => x.IdCliente).UseIdentityColumn();
            modelBuilder.Entity<Parametro>().Property(x => x.IdParametro).UseIdentityColumn();
            modelBuilder.Entity<ParametroDetalle>().Property(x => x.IdParametroDetalle).UseIdentityColumn();
            modelBuilder.Entity<Producto>().Property(x => x.IdProducto).UseIdentityColumn();

            base.OnModelCreating(modelBuilder);
        }
    }
}
