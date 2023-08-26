using Recipe.Application.Interfaces;
using Recipe.Application.Interfaces.Repositories;
using Recipe.Domain.Entities;
using Recipe.Infrastructure.Persistence.Contexts;
using Recipe.Infrastructure.Persistence.Repositories;

namespace Recipe.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDatabaseContext _context;

        public UnitOfWork(ApplicationDatabaseContext context)
        {
            _context= context;
        }


        public IBaseRepository<RecipesEntity> Recipes => new BaseRepository<RecipesEntity>(_context);

        public IBaseRepository<IngredientsEntity> Ingredients => new BaseRepository<IngredientsEntity>(_context);

        public IBaseRepository<CommentsEntity> Comments => new BaseRepository<CommentsEntity>(_context);

        public IBaseRepository<DifficultyLevelsEntity> DifficultyLevels => new BaseRepository<DifficultyLevelsEntity>(_context);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveAsync()
        {
            var results = await _context.SaveChangesAsync();
            return results;
        }
    }
}
