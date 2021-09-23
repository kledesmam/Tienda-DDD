using Domain.Domain.Servicios.Interface;
using Domain.Entidades;
using Domain.Entidades.ObjetosExternos;
using Domain.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Servicios.Implementacion
{
    public class OrdenService : IOrdenService
    {
        IParametroService parametroService;
        IOrdenRepository ordenRepository;
        IClienteRepository clienteRepository;
        IProductoRepository productoRepository;
        IClienteRest clienteRest;
        IOrdenLogRepository ordenLogRepository;
        public OrdenService(IOrdenRepository ordenRepository, 
            IClienteRepository clienteRepository, 
            IProductoRepository productoRepository,
            IParametroService parametroService,
            IClienteRest clienteRest,
            IOrdenLogRepository ordenLogRepository)
        {
            this.ordenRepository = ordenRepository;
            this.clienteRepository = clienteRepository;
            this.productoRepository = productoRepository;
            this.parametroService = parametroService;
            this.clienteRest = clienteRest;
            this.ordenLogRepository = ordenLogRepository;
        }

        public Orden CrearOrden(OrdenInput ordenInput)
        {
            if (ordenInput == null)
                throw new Exception("No se envio información de la Orden");

            Cliente cliente = clienteRepository.GetById(ordenInput.IdCliente);
            if (cliente == null)
                throw new Exception("Cliente no existe");
            Producto producto = productoRepository.GetById(ordenInput.IdProducto);
            if (producto == null)
                throw new Exception("Producto no existe");
            if (ordenInput.Valor <= 0)
                throw new Exception("Valor debe ser mayor a cero");

            var orden = RegistrarOrden(ordenInput, cliente, producto);

            return orden;
        }

        private Orden RegistrarOrden(OrdenInput ordenInput, Cliente cliente, Producto producto)
        {
            var estadosOrden = parametroService.ObtenerEstadosOrden();

            Orden orden = new Orden()
            {
                IdCliente = cliente.IdCliente,
                IdProducto = producto.IdProducto,
                IdParametroDetalle = estadosOrden.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_ESTADO_CREATED)).IdParametroDetalle,
                Valor = ordenInput.Valor,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                ReferenciaPago = (cliente.NumeroIdentificacion.ToString() + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Replace("-", "").Replace(":", "").Replace(" ", ""),
                RequestId = string.Empty,
                UrlPago = string.Empty
            };

            ordenRepository.Create(orden);

            orden.Cliente = cliente;
            CrearPagoPasarela(estadosOrden, orden);

            return orden;
        }

        private void CrearPagoPasarela(List<ParametroDetalle> estadosOrden, Orden orden)
        {
            var parametrosPasarela = parametroService.ObtenerParametrosPasarelaPagos();

            var response = clienteRest.CrearPagoPasarela(orden, parametrosPasarela);

            orden.RequestId = response.RequestId.ToString();
            orden.UrlPago = response.ProcessUrl;
            orden.FechaModificacion = DateTime.Now;

            RegistrarOrdenLog(orden, response.Status.Status, response.Status.Reason, response.Status.Message, 
                estadosOrden.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_ESTADO_CREATED)).Valor);
        }

        private void RegistrarOrdenLog(Orden orden, string statusResponse, string reaseonResponse, string messageResponse, string estadoOrden)
        {
            string respuestaPasarela = string.Format("{0} - {1} - {2} - {3}", estadoOrden, statusResponse, reaseonResponse, messageResponse);

            OrdenLog ordenLog = new OrdenLog()
            {
                Orden = orden,
                Fecha = DateTime.Now,
                Observacion = respuestaPasarela,
                ReferenciaPago = orden.ReferenciaPago,
                RequestId = orden.RequestId,
                UrlPago = orden.UrlPago
            };

            ordenLogRepository.Create(ordenLog);
        }

        public Orden RegenerarPagoPasarela(int id)
        {
            var orden = ordenRepository.GetById(id);
            if (orden == null)
                throw new Exception(string.Format("Orden [{0}] no existe", id));

            var parametrosPasarela = parametroService.ObtenerParametrosPasarelaPagos();
            var response = clienteRest.ConsultarTransaccionPasarela(int.Parse(orden.RequestId), parametrosPasarela);

            if (!response.Status.Status.Equals("REJECTED"))
                throw new Exception("Estado de la transacción no permite la acción solicitada");

            var estadosOrden = parametroService.ObtenerEstadosOrden();
            CrearPagoPasarela(estadosOrden, orden);
            ordenRepository.Update(orden);

            return orden;
        }

        public Orden RefrescarEstadoPago(int id)
        {
            ParametroDetalle estadoOrden = null;
            var orden = ordenRepository.GetById(id);
            if (orden == null)
                throw new Exception(string.Format("Orden [{0}] no existe", id));

            var parametrosPasarela = parametroService.ObtenerParametrosPasarelaPagos();
            var response = clienteRest.ConsultarTransaccionPasarela(int.Parse(orden.RequestId), parametrosPasarela);

            var estadosOrden = parametroService.ObtenerEstadosOrden();

            estadoOrden = estadosOrden.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_ESTADO_CREATED));

            if (response.Status.Status.Equals("REJECTED"))
                estadoOrden = estadosOrden.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_ESTADO_REJECTED));
            if (response.Status.Status.Equals("APPROVED"))
                estadoOrden = estadosOrden.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_ESTADO_PAYED));

            orden.IdParametroDetalle = estadoOrden.IdParametroDetalle;
            orden.FechaModificacion = DateTime.Now;

            RegistrarOrdenLog(orden, response.Status.Status, response.Status.Reason, response.Status.Message, estadoOrden.Valor);
            ordenRepository.Update(orden);

            return orden;
        }
    }
}
