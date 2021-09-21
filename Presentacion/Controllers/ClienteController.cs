using Aplicacion.Aplicacion.Services.Interface;
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
            var cliente = clienteService.GetClienteByEmail(mail);
            if (cliente == null)
                return NotFound();
            return Ok(JsonConvert.SerializeObject(cliente));
        }

        
    }
}
