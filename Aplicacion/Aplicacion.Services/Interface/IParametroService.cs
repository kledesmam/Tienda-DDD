using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Aplicacion.Services.Interface
{
    public interface IParametroService
    {
        List<ParametroDetalle> ObtenerTiposDocumentos();
        List<ParametroDetalle> ObtenerEstadosOrden();
        List<ParametroDetalle> ObtenerParametrosPasarelaPagos();
    }
}
