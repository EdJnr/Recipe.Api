using Recipe.Application.Interfaces.Repositories;
using Recipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<RecipesEntity> Recipes { get; }

        IBaseRepository<IngredientsEntity> Ingredients { get; }

        IBaseRepository<CommentsEntity> Comments { get; }

        IBaseRepository<DifficultyLevelsEntity> DifficultyLevels { get; }

        Task<int> SaveAsync();

        void Dispose();
    }
}
