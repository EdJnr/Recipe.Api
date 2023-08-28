using Recipe.Application.Dtos.Comments;
using Recipe.Application.Dtos.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Interfaces.Services
{
    public interface IRecipe
    {
        Task<IReadOnlyList<GetRecipeDto>> GetAllRecipes(string? search);

        Task<GetRecipeDto> GetRecipeById(int id);

        Task<int> AddRecipe(CreateRecipeDto dto);

        Task<int> UpdateRecipe(int id, UpdateRecipeDto dto);

        Task<int> DeleteRecipe(int id);
    }
}
