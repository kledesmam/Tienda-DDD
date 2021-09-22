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
        OrdenDto CrearOrden(OrdenInput ordenInput);        
        OrdenDto RegenerarPagoPasarela(int id);
        OrdenDto RefrescarEstadoPago(int id);
    }
}
