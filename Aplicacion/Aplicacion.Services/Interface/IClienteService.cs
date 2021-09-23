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
        /// <summary>
        /// Método encargado de obtener un cliente por el email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        ClienteDto GetClienteByEmail(string email);

        /// <summary>
        /// Metodo encargado de crear un cliente. Si el email ya esta registrado no permite la creación.
        /// </summary>
        /// <param name="cliente"></param>
        void Create(ClienteDto cliente);
    }
}
