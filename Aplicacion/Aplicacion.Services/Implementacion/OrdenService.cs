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

        public Orden CrearOrden(OrdenInput ordenInput)
        {
            try
            {
                var orden = ordenService.CrearOrden(ordenInput);
                unitOfWork.Save();
                return orden;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public Orden CrearPago(int id)
        {
            try
            {
                var orden = ordenService.CrearPago(id);
                unitOfWork.Save();
                return orden;
            }
            catch (Exception)
            {
                throw;
            }
        }

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

        public bool PagarOrden(int id)
        {
            return ordenService.PagarOrden(id);
        }
    }
}
