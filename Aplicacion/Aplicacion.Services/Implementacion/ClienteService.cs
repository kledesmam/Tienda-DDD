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
        DomainRepository.IUnitOfWork unitOfWork;

        public ClienteService(DomainRepository.IClienteRepository clienteRepository,
            DomainRepository.IUnitOfWork unitOfWork)
        {
            this.clienteRepository = clienteRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Metodo encargado de crear un cliente. Si el email ya esta registrado no permite la creación.
        /// </summary>
        /// <param name="cliente"></param>
        public void Create(ClienteDto cliente)
        {
            if (cliente == null)
                throw new Exception("Información del cliente no se envio");
            if(cliente.IdTipoIdentificacion <= 0)
                throw new Exception("Tipo de identificación no válido");
            if (cliente.NumeroIdentificacion <= 0)
                throw new Exception("Número de identificación no válido");
            if (string.IsNullOrWhiteSpace(cliente.Email))
                throw new Exception("Correo no válido");

            var _clienteDtoVal = this.GetClienteByEmail(cliente.Email);
            if (_clienteDtoVal != null)
                throw new Exception("Ya existe un cliente registrado con el correo enviado");

            Cliente _cliente = new Cliente();
            _cliente.Apellido = cliente.Apellido;
            _cliente.Celular = cliente.Celular;
            _cliente.Email = cliente.Email;
            _cliente.IdParametroDetalle = cliente.IdTipoIdentificacion;
            _cliente.Nombre = cliente.Nombre;
            _cliente.NumeroIdentificacion = cliente.NumeroIdentificacion;

            clienteRepository.Create(_cliente);
            unitOfWork.Save();
        }

        /// <summary>
        /// Método encargado de obtener un cliente por el email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public ClienteDto GetClienteByEmail(string email)
        {            
            var cliente = clienteRepository.GetClienteByEmail(email);
            
            return cliente != null ? cliente.ConvertirDto() : null;
        }
    }
}
