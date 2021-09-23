using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Servicios.Interface
{
    public interface IOrdenService
    {
        Orden CrearOrden(OrdenInput ordenInput);
        Orden RegenerarPagoPasarela(int id);
        Orden RefrescarEstadoPago(int id);
    }
}
