using Domain.Entidades;
using Domain.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;
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
            return context.Clientes
                .Include(c => c.TipoIdentificacion)
                .ToList();
        }

        public Cliente GetById(int id)
        {
            return context.Clientes
                .Include(c => c.TipoIdentificacion)
                .SingleOrDefault(c => c.IdCliente == id);
        }

        public Cliente GetClienteByEmail(string email)
        {
            return context.Clientes
                .Include(c => c.TipoIdentificacion)
                .SingleOrDefault(x => x.Email.ToUpper().Equals(email.ToUpper()));
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
