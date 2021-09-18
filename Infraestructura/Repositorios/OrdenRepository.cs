using Domain.Entidades;
using Domain.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class OrdenRepository : IOrdenRepository
    {
        private EvertecContext context;
        public OrdenRepository(EvertecContext context)
        {
            this.context = context;
        }

        public void Create(Orden entity)
        {
            context.Ordenes.Add(entity);
        }

        public void Delete(int id)
        {
            context.Ordenes.Remove(context.Ordenes.Find(id));
        }

        public List<Orden> Get()
        {
            return context.Ordenes.ToList();
        }

        public Orden GetById(int id)
        {
            return context.Ordenes.Find(id);
        }

        public void Update(Orden entity)
        {
            var _entity = context.Ordenes.Find(entity.IdOrden);
            _entity.ReferenciaPago = entity.ReferenciaPago;
            _entity.RequestId = entity.RequestId;
            _entity.UrlPago = entity.UrlPago;
            _entity.FechaModificacion = new DateTime();
            context.Ordenes.Update(_entity);
            context.SaveChanges();
        }
    }
}
