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
    public class ParametroService : IParametroService
    {
        DomainService.IParametroService parametroService;
        DomainRepository.IParametroRepository parametroRepository;
        DomainRepository.IParametroDetalleRepository parametroDetalleRepository;

        public ParametroService(DomainService.IParametroService parametroService,
            DomainRepository.IParametroRepository parametroRepository,
            DomainRepository.IParametroDetalleRepository parametroDetalleRepository)
        {
            this.parametroService = parametroService;
            this.parametroRepository = parametroRepository;
            this.parametroDetalleRepository = parametroDetalleRepository;
        }

        public List<ParametroDetalleDto> ObtenerEstadosOrden()
        {
            List<ParametroDetalleDto> parametroDetalleDtos = new List<ParametroDetalleDto>();
            var lista = parametroService.ObtenerEstadosOrden();
            foreach (var item in lista)
            {
                parametroDetalleDtos.Add(item.ConvertirDto());
            }
            return parametroDetalleDtos;
        }

        public List<ParametroDetalleDto> ObtenerParametrosPasarelaPagos()
        {
            List<ParametroDetalleDto> parametroDetalleDtos = new List<ParametroDetalleDto>();
            var lista = parametroService.ObtenerParametrosPasarelaPagos();
            foreach (var item in lista)
            {
                parametroDetalleDtos.Add(item.ConvertirDto());
            }
            return parametroDetalleDtos;
        }

        public List<ParametroDetalleDto> ObtenerTiposDocumentos()
        {
            List<ParametroDetalleDto> parametroDetalleDtos = new List<ParametroDetalleDto>();
            var lista = parametroService.ObtenerTiposDocumentos();
            foreach (var item in lista)
            {
                parametroDetalleDtos.Add(item.ConvertirDto());
            }
            return parametroDetalleDtos;
        }
    }
}
