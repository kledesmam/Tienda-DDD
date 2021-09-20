using Domain.Entidades;
using Domain.Entidades.ObjetosExternos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios.Contratos
{
    public interface IClienteRest
    {
        RedirectResponse CrearPagoPasarela(Orden orden, List<ParametroDetalle> parametrosPasarela);
        RedirectInformation ConsultarTransaccionPasarela(int requestId, List<ParametroDetalle> parametrosPasarela);
    }
}
