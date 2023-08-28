using Recipe.Application.Dtos.DifficultyLevels;
using Recipe.Application.Dtos.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Interfaces.Services
{
    public interface IIngredients
    {
        Task<IReadOnlyList<GetIngredientDto>> GetAllIngredients(string? search);

        Task<GetIngredientDto> GetIngredientById(int id);

        Task<int> AddIngredient(CreateIngredientDto dto);

        Task<int> UpdateIngredient(int id, UpdateIngredientDto dto);

        Task<int> DeleteIngredient(int id);
    }
}
