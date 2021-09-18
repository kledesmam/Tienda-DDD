using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios.Contratos
{
    public interface IClienteRepository //: IBaseRepository<Cliente>
    {
        Cliente GetClienteByEmail(string email);
        List<Cliente> Get();
        Cliente GetById(int id);
        void Create(Cliente entity);
        void Update(Cliente entity);
        void Delete(int id);
    }
}
