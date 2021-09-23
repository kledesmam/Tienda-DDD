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
        /// <summary>
        /// Método encargado de crear una orden y registrar una solicitud de pago en la pasarela
        /// </summary>
        /// <param name="ordenInput">Objeto que contiene las propiedades necesarias para crear una orden</param>
        /// <returns>Retorna Dto con la información de la orden</returns>
        OrdenDto CrearOrden(OrdenInput ordenInput);

        /// <summary>
        /// Método encargado de volver a generar una solicitud de pago en la pasarela.
        /// Esta solicitud solo se vuelve a generar cuando el pago se encuentra en estado REJECTED
        /// </summary>
        /// <param name="id">Consecutivo de la orden</param>
        /// <returns>Retorna Dto con la información de la orden</returns>
        OrdenDto RegenerarPagoPasarela(int id);

        /// <summary>
        /// Método encargado de obtener el listado de ordenes registradas en el sistema.
        /// </summary>
        /// <param name="id">Parametro opcional. Consecutivo de la Orden. Se usa cuando se requiere consultar una orden especifica</param>
        /// <returns>Retorna listado con la información de las ordenes</returns>
        IEnumerable<OrdenDto> ObtenerOrdenes(int id = 0);

        /// <summary>
        /// Método encargado de consultar el estado de la transacción asociado a la orden en la pasarela.
        /// Si el estado de la orden cambio a Payed o Rejected se actualiza el estado de la orden.
        /// </summary>
        /// <param name="id">Consecutivo de la orden</param>
        /// <returns>Retorna Dto con la información de la orden</returns>
        OrdenDto RefrescarEstadoPago(int id);

        /// <summary>
        /// Método encargado de consultar las ordenes que pertenecen a un cliente
        /// </summary>
        /// <param name="idCliente">Consecutivo que representa al cliente a consultar</param>
        /// <returns>Retorna listado con la información de las ordenes</returns>
        IEnumerable<OrdenDto> ObtenerOrdenesPorIdCliente(int idCliente);
    }
}
