using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios.Contratos
{
    public interface IOrdenRepository //: IBaseRepository<Orden>
    {
        List<Orden> Get();
        Orden GetById(int id);
        void Create(Orden entity);
        void Update(Orden entity);
        void Delete(int id);
        List<Orden> GetByIdCliente(int idCliente);
    }
}
