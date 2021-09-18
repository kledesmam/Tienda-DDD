using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios.Contratos
{
    public interface IParametroDetalleRepository //: IBaseRepository<ParametroDetalle> 
    {
        ParametroDetalle GetParametroDetalleByEtiqueta(string etiquetaParametro, string etiquetaDetalle);
        List<ParametroDetalle> Get();
        ParametroDetalle GetById(int id);
        void Create(ParametroDetalle entity);
        void Update(ParametroDetalle entity);
        void Delete(int id);
        List<ParametroDetalle> GetParametroDetalleByEtiquetaParametro(string etiquetaParametro);
    }
}
