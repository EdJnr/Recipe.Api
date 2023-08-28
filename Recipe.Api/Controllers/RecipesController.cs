using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Api.Responses;
using Recipe.Application.Dtos.Recipes;
using Recipe.Application.Interfaces.Services;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        string ItemName = "Recipe";
        private readonly IRecipe _;

        public RecipesController(IRecipe recipes)
        {
            _ = recipes;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllRecipes(string? search)
        {
            var results = await _.GetAllRecipes(search);
            return Ok(results);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            var result = await _.GetRecipeById(id);

            if (result == null)
            {
                return NotFound(ControllerResponses.NotFound(ItemName, id));
            }

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddRecipe([FromBody] CreateRecipeDto dto)
        {
            await _.AddRecipe(dto);
            return Accepted(ControllerResponses.Created(ItemName));
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRecipe(int id, [FromBody] UpdateRecipeDto dto)
        {
            if (id != dto.Id) return BadRequest("Id In route must match with id in the body");

            var result = await _.UpdateRecipe(id, dto);

            return result == 0 ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Accepted(ControllerResponses.Updated(ItemName, id));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var result = await _.DeleteRecipe(id);
            return result == 0 ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Ok(ControllerResponses.Deleted(ItemName, id));
        }
    }
}
