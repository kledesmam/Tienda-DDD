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
    public class ParametroDetalleController : ControllerBase
    {
        IParametroService parametroService;
        public ParametroDetalleController(IParametroService parametroService)
        {
            this.parametroService = parametroService;
        }

        [HttpGet("tipos-documentos")]
        public ActionResult GetTiposDocumento()
        {
            var tiposDocumentos = parametroService.ObtenerTiposDocumentos();
            return Ok(JsonConvert.SerializeObject(tiposDocumentos));
        }
    }
}
