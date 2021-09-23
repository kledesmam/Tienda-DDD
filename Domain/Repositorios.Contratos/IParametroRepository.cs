using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios.Contratos
{
    public interface IParametroRepository
    {
        Parametro GetParametroByEtiqueta(string etiquetaParametro);
        List<Parametro> Get();
        Parametro GetById(int id);
        void Create(Parametro entity);
        void Update(Parametro entity);
        void Delete(int id);
    }
}
