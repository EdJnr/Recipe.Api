using Microsoft.EntityFrameworkCore;
using Recipe.Application.Interfaces.Repositories;
using Recipe.Infrastructure.Persistence.Contexts;
using System.Linq.Expressions;

namespace Recipe.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDatabaseContext _dbContext;
        private readonly DbSet<T> _db;

        public BaseRepository(ApplicationDatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _db = dbContext.Set<T>();
        }

        public void Create(T entity)
        {
            _db.Add(entity);
        }

        public void Delete(int id)
        {
            var model = _db.Find(id);

            if (model != null)
            {
                _db.Remove(model);
            }
        }

        public async Task<T> Get(int id)
        {
            var model = await _db.FindAsync(id);

            return model;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            var result =  await _db.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<IReadOnlyList<T>> Query(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            Expression<Func<T, T>>? select = null, 
            Expression<Func<T, object>>[]? includes = null
            )
        {
            IQueryable<T> query = _db;

            if (select != null)
            {
                query = query.Select( select );
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                orderBy(query);
            }


            var results = await query.AsNoTracking().ToListAsync();
            return results;
        }

        public async Task Update(int id, T entity)
        {
            var model = await _db.FindAsync(id);

            if (model != null)
            {
                _db.Update(model);
            }
        }
    }
}
