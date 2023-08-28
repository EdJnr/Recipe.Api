using AutoMapper;
using Recipe.Application.Dtos.Comments;
using Recipe.Application.Dtos.Recipes;
using Recipe.Application.Interfaces;
using Recipe.Application.Interfaces.Services;
using Recipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Services
{
    public class RecipesService : IRecipe
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecipesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddRecipe(CreateRecipeDto dto)
        {
            if (!await Checks.DifficultyLevelExists(_unitOfWork, dto.DifficultyLevelId))
            {
                throw new ValidationException($"No Difficulty Level Matches the Id {dto.DifficultyLevelId}");
            }

            var model = _mapper.Map<RecipesEntity>(dto);

            _unitOfWork.Recipes.Create(model);
            var result = await _unitOfWork.SaveAsync();

            return result;
        }

        public async Task<int> DeleteRecipe(int id)
        {
            _unitOfWork.Recipes.Delete(id);

            var result = await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<IReadOnlyList<GetRecipeDto>> GetAllRecipes(string? search)
        {
            var fromDb = (search == null) ?
            await _unitOfWork.Recipes.Query(
                includes: new Expression<Func<RecipesEntity, object>>[] { r => r.DifficultyLevel, r=> r.Comments, r=> r.Ingredients}
            )
            :
            await _unitOfWork.Recipes.Query
            (
                filter: e => e.Title.Trim().ToLower().Contains(search.Trim().ToLower()),
                includes: new Expression<Func<RecipesEntity, object>>[] { r => r.DifficultyLevel, r => r.Comments, r=> r.Ingredients }
            );

            var result = _mapper.Map<IReadOnlyList<GetRecipeDto>>(fromDb);
            return result;
        }

        public async Task<GetRecipeDto> GetRecipeById(int id)
        {
            var fromDb = await _unitOfWork.Recipes.Get(id);

            var result = _mapper.Map<GetRecipeDto>(fromDb);
            return result;
        }

        public async Task<int> UpdateRecipe(int id, UpdateRecipeDto dto)
        {
            if (!await Checks.DifficultyLevelExists(_unitOfWork, dto.DifficultyLevelId))
            {
                throw new Exception($"No Difficulty Level Matched the Id {dto.DifficultyLevelId}");
            }

            var model = _mapper.Map<RecipesEntity>(dto);

            await _unitOfWork.Recipes.Update(id, model);
            var result = await _unitOfWork.SaveAsync();

            return result;
        }
    }


   public static class Checks
   {
        //check if difficulty level exists
        public static async Task<bool> DifficultyLevelExists(IUnitOfWork unitOfWork, int id)
        {
            var result = await unitOfWork.DifficultyLevels.Get(id);
            return result == null ? false : true;
        }
   }
}
