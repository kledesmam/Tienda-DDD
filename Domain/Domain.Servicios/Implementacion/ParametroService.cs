using Domain.Domain.Servicios.Interface;
using Domain.Entidades;
using Domain.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Servicios.Implementacion
{
    public class ParametroService : IParametroService
    {
        IParametroRepository parametroRepository;
        IParametroDetalleRepository parametroDetalleRepository;

        public ParametroService(IParametroRepository parametroRepository, IParametroDetalleRepository parametroDetalleRepository)
        {
            this.parametroRepository = parametroRepository;
            this.parametroDetalleRepository = parametroDetalleRepository;
        }

        public List<ParametroDetalle> ObtenerEstadosOrden()
        {
            return this.parametroDetalleRepository.GetParametroDetalleByEtiquetaParametro(Constantes.ETIQUETA_PARAMETRO_ESTADOS_ORDEN);
        }

        public List<ParametroDetalle> ObtenerParametrosPasarelaPagos()
        {
            return this.parametroDetalleRepository.GetParametroDetalleByEtiquetaParametro(Constantes.ETIQUETA_PARAMETRO_PASARELA_PAGOS);
        }

        public List<ParametroDetalle> ObtenerTiposDocumentos()
        {
            return this.parametroDetalleRepository.GetParametroDetalleByEtiquetaParametro(Constantes.ETIQUETA_PARAMETRO_TIPOS_DOCUMENTO);
        }
    }
}
