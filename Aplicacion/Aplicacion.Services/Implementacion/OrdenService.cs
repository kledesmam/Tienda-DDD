using Aplicacion.Aplicacion.Services.Interface;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainService = Domain.Domain.Servicios.Interface;
using DomainRepository = Domain.Repositorios.Contratos;

namespace Aplicacion.Aplicacion.Services.Implementacion
{
    public class OrdenService : IOrdenService
    {
        DomainService.IOrdenService ordenService;
        DomainRepository.IOrdenRepository ordenRepository;
        DomainRepository.IUnitOfWork unitOfWork;

        public OrdenService(DomainService.IOrdenService ordenService, DomainRepository.IOrdenRepository ordenRepository, DomainRepository.IUnitOfWork unitOfWork)
        {
            this.ordenService = ordenService;
            this.ordenRepository = ordenRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Método encargado de crear una orden y registrar una solicitud de pago en la pasarela
        /// </summary>
        /// <param name="ordenInput">Objeto que contiene las propiedades necesarias para crear una orden</param>
        /// <returns>Retorna Dto con la información de la orden</returns>
        public OrdenDto CrearOrden(OrdenInput ordenInput)
        {
            try
            {
                var orden = ordenService.CrearOrden(ordenInput);
                unitOfWork.Save();
                return orden != null ? orden.ConvertirDto() : null;
            }
            catch
            {
                throw;
            }
            
        }

        /// <summary>
        /// Método encargado de volver a generar una solicitud de pago en la pasarela.
        /// Esta solicitud solo se vuelve a generar cuando el pago se encuentra en estado REJECTED
        /// </summary>
        /// <param name="id">Consecutivo de la orden</param>
        /// <returns>Retorna Dto con la información de la orden</returns>
        public OrdenDto RegenerarPagoPasarela(int id)
        {
            try
            {
                var orden = ordenService.RegenerarPagoPasarela(id);
                unitOfWork.Save();
                return orden != null ? orden.ConvertirDto() : null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Método encargado de obtener el listado de ordenes registradas en el sistema.
        /// </summary>
        /// <param name="id">Parametro opcional. Consecutivo de la Orden. Se usa cuando se requiere consultar una orden especifica</param>
        /// <returns>Retorna listado con la información de las ordenes</returns>
        public IEnumerable<OrdenDto> ObtenerOrdenes(int id = 0)
        {
            List<Orden> ordens = new List<Orden>();
            if (id > 0) 
            {
                var _orden = ordenRepository.GetById(id);
                if (_orden != null)
                    ordens.Add(_orden);
            }
            else
            {
                ordens = ordenRepository.Get();
            }

            List<OrdenDto> ordenDtos = new List<OrdenDto>();
            foreach (var item in ordens)
            {
                ordenDtos.Add(item.ConvertirDto());
            }

            return ordenDtos;
        }

        /// <summary>
        /// Método encargado de consultar el estado de la transacción asociado a la orden en la pasarela.
        /// Si el estado de la orden cambio a Payed o Rejected se actualiza el estado de la orden.
        /// </summary>
        /// <param name="id">Consecutivo de la orden</param>
        /// <returns>Retorna Dto con la información de la orden</returns>
        public OrdenDto RefrescarEstadoPago(int id)
        {
            try
            {
                var orden = ordenService.RefrescarEstadoPago(id);
                unitOfWork.Save();
                return orden != null ? orden.ConvertirDto() : null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Método encargado de consultar las ordenes que pertenecen a un cliente
        /// </summary>
        /// <param name="idCliente">Consecutivo que representa al cliente a consultar</param>
        /// <returns>Retorna listado con la información de las ordenes</returns>
        public IEnumerable<OrdenDto> ObtenerOrdenesPorIdCliente(int idCliente)
        {
            List<Orden> ordens = new List<Orden>();
            List<OrdenDto> ordenDtos = new List<OrdenDto>();

            ordens = ordenRepository.GetByIdCliente(idCliente);            
            foreach (var item in ordens)
            {
                ordenDtos.Add(item.ConvertirDto());
            }

            return ordenDtos;
        }
    }
}
