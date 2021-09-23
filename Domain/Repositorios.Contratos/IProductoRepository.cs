using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios.Contratos
{
    public interface IProductoRepository
    {
        List<Producto> Get();
        Producto GetById(int id);
        void Create(Producto entity);
        void Update(Producto entity);
        void Delete(int id);
    }
}
