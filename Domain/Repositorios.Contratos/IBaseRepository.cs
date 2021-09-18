using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios.Contratos
{
    public interface IBaseRepository
    {
        IEnumerable<T> Get<T>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "") where T : class;
        T GetByID<T>(object id) where T : class;
        void Insert<T>(T entity) where T : class;
        void Delete(object id);
        void Update<T>(T entityToUpdate) where T : class;
    }
}
