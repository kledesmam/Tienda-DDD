using Domain.Entidades;
using Domain.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private EvertecContext context;
        public ClienteRepository(EvertecContext context)
        {
            this.context = context;
        }

        public void Create(Cliente entity)
        {
            context.Clientes.Add(entity);
        }

        public void Delete(int id)
        {
            context.Clientes.Remove(context.Clientes.Find(id));
        }

        public List<Cliente> Get()
        {
            return context.Clientes.ToList();
        }

        public Cliente GetById(int id)
        {
            return context.Clientes.Find(id);
        }

        public Cliente GetClienteByEmail(string email)
        {
            return context.Clientes.Where(x => x.Email.ToUpper().Equals(email.ToUpper())).FirstOrDefault();
        }

        public void Update(Cliente entity)
        {
            var _entity = context.Clientes.Find(entity.IdCliente);
            _entity.Apellido = entity.Apellido;
            _entity.Celular = entity.Celular;
            _entity.Email = entity.Email;
            _entity.Nombre = entity.Nombre;
            _entity.NumeroIdentificacion = entity.NumeroIdentificacion;
            _entity.IdParametroDetalle = entity.IdParametroDetalle;
            context.Clientes.Update(_entity);
            context.SaveChanges();
        }
    }
}
