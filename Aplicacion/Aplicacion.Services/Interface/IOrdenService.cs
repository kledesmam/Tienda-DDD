using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Aplicacion.Services.Interface
{
    public interface IOrdenService
    {
        OrdenDto CrearOrden(OrdenInput ordenInput);        
        OrdenDto RegenerarPagoPasarela(int id);
        IEnumerable<OrdenDto> ObtenerOrdenes(int id = 0);
        OrdenDto RefrescarEstadoPago(int id);

        IEnumerable<OrdenDto> ObtenerOrdenesPorIdCliente(int idCliente);
    }
}
