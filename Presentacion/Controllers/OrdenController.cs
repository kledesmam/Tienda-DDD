using Aplicacion.Aplicacion.Services.Interface;
using Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        IOrdenService ordenService;
        public OrdenController(IOrdenService ordenService)
        {
            this.ordenService = ordenService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var ordens = ordenService.ObtenerOrdenes();            
            return Ok(JsonConvert.SerializeObject(ordens));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var ordens = ordenService.ObtenerOrdenes(id);
            if (!ordens.Any())
                return NotFound();
            return Ok(JsonConvert.SerializeObject(ordens.FirstOrDefault()));
        }

        [HttpPost]
        public ActionResult Post(OrdenInput ordenInput)
        {
            try
            {
                var orden = ordenService.CrearOrden(ordenInput);
                if (orden == null)
                    return NotFound();
                return Ok(JsonConvert.SerializeObject(orden));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails() {  Detail = ex.Message });
            }
        }

        [HttpPut("regenerate-pay/{id}")]
        public ActionResult RegenerarPagoPasarela(int id)
        {
            try
            {
                var orden = ordenService.RegenerarPagoPasarela(id);
                if (orden == null)
                    return NotFound();
                return Ok(JsonConvert.SerializeObject(orden));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails() { Detail = ex.Message });
            }
        }

        [HttpPut("refresh-status-pay/{id}")]
        public ActionResult RefrescarEstadoPago(int id)
        {
            try
            {
                var orden = ordenService.RefrescarEstadoPago(id);
                if (orden == null)
                    return NotFound();
                return Ok(JsonConvert.SerializeObject(orden));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails() { Detail = ex.Message });
            }
        }

        [HttpGet("cliente/{id}")]
        public ActionResult GetOrdenesByIdCliente(int id)
        {
            var ordens = ordenService.ObtenerOrdenesPorIdCliente(id);
            if (!ordens.Any())
                return NotFound();
            return Ok(JsonConvert.SerializeObject(ordens));
        }
    }
}
