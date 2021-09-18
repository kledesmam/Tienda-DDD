using Domain.Entidades;
using Domain.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class ParametroDetalleRepository : IParametroDetalleRepository
    {
        private EvertecContext context;
        public ParametroDetalleRepository(EvertecContext context)
        {
            this.context = context;
        }

        public void Create(ParametroDetalle entity)
        {
            context.ParametroDetalles.Add(entity);
        }

        public void Delete(int id)
        {
            context.ParametroDetalles.Remove(context.ParametroDetalles.Find(id));
        }

        public List<ParametroDetalle> Get()
        {
            return context.ParametroDetalles.ToList();
        }

        public ParametroDetalle GetById(int id)
        {
            return context.ParametroDetalles.Find(id);
        }

        public ParametroDetalle GetParametroDetalleByEtiqueta(string etiquetaParametro, string etiquetaDetalle)
        {
            return context.ParametroDetalles.Where(x => x.Etiqueta.ToUpper().Equals(etiquetaDetalle.ToUpper()) &&
            x.Parametro.Etiqueta.ToUpper().Equals(etiquetaParametro.ToUpper()))
                .FirstOrDefault();
        }

        public List<ParametroDetalle> GetParametroDetalleByEtiquetaParametro(string etiquetaParametro)
        {
            return context.ParametroDetalles.Where(x => x.Parametro.Etiqueta.ToUpper().Equals(etiquetaParametro.ToUpper())).ToList();
        }

        public void Update(ParametroDetalle entity)
        {
            var _entity = context.ParametroDetalles.Find(entity.IdParametroDetalle);
            _entity.Etiqueta = entity.Etiqueta;
            _entity.IdParametro = entity.IdParametro;
            _entity.Valor = entity.Valor;
            _entity.ValorExterno = entity.ValorExterno;
            context.ParametroDetalles.Update(_entity);
            context.SaveChanges();
        }
    }
}
