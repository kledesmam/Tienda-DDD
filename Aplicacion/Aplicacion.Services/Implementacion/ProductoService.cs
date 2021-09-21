using Aplicacion.Aplicacion.Services.Interface;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainRepository = Domain.Repositorios.Contratos;

namespace Aplicacion.Aplicacion.Services.Implementacion
{
    public class ProductoService : IProductoService
    {
        DomainRepository.IProductoRepository productoRepository;

        public ProductoService(DomainRepository.IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }
        public List<ProductoDto> GetProductos()
        {
            List<ProductoDto> productoDtos = new List<ProductoDto>();
            var productos = productoRepository.Get();

            foreach (var item in productos)
            {
                productoDtos.Add(item.ConvertirDto());
            }

            return productoDtos;
        }
    }
}
