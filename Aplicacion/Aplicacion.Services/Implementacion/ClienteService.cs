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
    public class ClienteService : IClienteService
    {
        DomainRepository.IClienteRepository clienteRepository;

        public ClienteService(DomainRepository.IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }
        public void Create(Cliente cliente)
        {
            clienteRepository.Create(cliente);
        }

        public ClienteDto GetClienteByEmail(string email)
        {            
            var cliente = clienteRepository.GetClienteByEmail(email);
            
            return cliente != null ? cliente.ConvertirDto() : null;
        }
    }
}
