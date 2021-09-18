using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Aplicacion.Services.Interface
{
    public interface IClienteService
    {
        Cliente GetClienteByEmail(string email);
        void Create(Cliente cliente);
    }
}
