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
    public class ProductoController : ControllerBase
    {
        IProductoService productoService;
        public ProductoController(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        // GET api/producto
        [HttpGet]
        public ActionResult Get()
        {
            var productos = productoService.GetProductos();
            if (productos.Count < 1)
                return NotFound();
            return Ok(JsonConvert.SerializeObject(productos));
        }
    }
}
