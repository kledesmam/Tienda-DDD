using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios.Contratos
{
    public interface IParametroDetalleRepository : IBaseRepository<ParametroDetalle> 
    {
        ParametroDetalle GetParametroDetalleByEtiqueta(string etiquetaParametro, string etiquetaDetalle);
    }
}
