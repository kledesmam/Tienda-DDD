using Domain.Entidades;
using Domain.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class ParametroRepository : IParametroRepository        
    {
        private EvertecContext context;
        public ParametroRepository(EvertecContext context)
        {
            this.context = context;
        }

        public void Create(Parametro entity)
        {
            context.Parametros.Add(entity);
        }

        public void Delete(int id)
        {
            context.Parametros.Remove(context.Parametros.Find(id));
        }

        public List<Parametro> Get()
        {
            return context.Parametros.ToList();
        }

        public Parametro GetById(int id)
        {
            return context.Parametros.Find(id);
        }

        public Parametro GetParametroByEtiqueta(string etiquetaParametro)
        {
            return context.Parametros.Where(x => x.Etiqueta.ToUpper().Equals(etiquetaParametro.ToUpper()))
                .FirstOrDefault();
        }

        public void Update(Parametro entity)
        {
            var _entity = context.Parametros.Find(entity.IdParametro);
            _entity.Etiqueta = entity.Etiqueta;
            _entity.Nombre = entity.Nombre;
            context.Parametros.Update(_entity);
            context.SaveChanges();
        }
    }
}
