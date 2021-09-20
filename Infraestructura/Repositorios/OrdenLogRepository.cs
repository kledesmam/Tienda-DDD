using Domain.Entidades;
using Domain.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class OrdenLogRepository : IOrdenLogRepository
    {
        private EvertecContext context;
        public OrdenLogRepository(EvertecContext context)
        {
            this.context = context;
        }
        public void Create(OrdenLog entity)
        {
            context.OrdenLogs.Add(entity);
        }
    }
}
