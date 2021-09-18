using Domain.Entidades;
using Domain.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class ProductoRepository : IProductoRepository
    {
        private EvertecContext context;
        public ProductoRepository(EvertecContext context)
        {
            this.context = context;
        }

        public void Create(Producto entity)
        {
            context.Productos.Add(entity);
        }

        public void Delete(int id)
        {
            context.Productos.Remove(context.Productos.Find(id));
        }

        public List<Producto> Get()
        {
            return context.Productos.ToList();
        }

        public Producto GetById(int id)
        {
            return context.Productos.Find(id);
        }

        public void Update(Producto entity)
        {
            var _entity = context.Productos.Find(entity.IdProducto);
            _entity.Codigo = entity.Codigo;
            _entity.Nombre = entity.Nombre;
            context.Productos.Update(_entity);
            context.SaveChanges();
        }
    }
}
