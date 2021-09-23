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
        /// <summary>
        /// Método encargado de consumir el servicio expuesto por la pasarela de pagos para crear un solicitud
        /// de pago y obtener el requestId y la url para el pago.
        /// </summary>
        /// <param name="orden">Orden a ser procesada</param>
        /// <param name="parametrosPasarela">Listado con los parametros necesarios para conectar con la pasarela</param>
        /// <returns>Objeto que contiene el estado de la petición, la url de pago y el requestId</returns>
        RedirectResponse CrearPagoPasarela(Orden orden, List<ParametroDetalle> parametrosPasarela);
        
        /// <summary>
        /// Método encargado de obtener la información de una transacción en la pasarela de pagos a tráves del
        /// RequestId
        /// </summary>
        /// <param name="requestId">RequestId del cual se desea obtener la información</param>
        /// <param name="parametrosPasarela">Listado con los parametros necesarios para conectar con la pasarela</param>
        /// <returns></returns>
        RedirectInformation ConsultarTransaccionPasarela(int requestId, List<ParametroDetalle> parametrosPasarela);
    }
}
