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
        Orden CrearOrden(OrdenInput ordenInput);
        bool PagarOrden(int id);
        Orden CrearPago(int id);
        IEnumerable<OrdenDto> ObtenerOrdenes(int id = 0);
    }
}
