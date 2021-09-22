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
    public class ClienteController : ControllerBase
    {
        IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        // GET api/cliente/{mail}
        [HttpGet("{mail}")]
        public ActionResult GetByMail(string mail)
        {
            try
            {
                var cliente = clienteService.GetClienteByEmail(mail);
                if (cliente == null)
                    return NotFound();
                return Ok(JsonConvert.SerializeObject(cliente));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails() { Detail = ex.Message });
            }            
        }

        [HttpPost]
        public ActionResult Post(ClienteDto clienteDto)
        {
            try
            {
                clienteService.Create(clienteDto);

                return Ok(JsonConvert.SerializeObject(new GenericResponse() { Status=true, Message="OK" }));
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails() { Detail = ex.Message });
            }            
        }
    }
}
