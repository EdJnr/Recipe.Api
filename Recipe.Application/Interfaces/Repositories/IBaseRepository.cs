using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();

        Task<T> Get(int id);

        Task<IReadOnlyList<T>> Query(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Expression<Func<T, T>>? select = null,
            Expression<Func<T, object>>[]? includes = null
        );

        void Create(T entity);

        Task Update(int id, T entity);

        void Delete(int id);
    }
}
