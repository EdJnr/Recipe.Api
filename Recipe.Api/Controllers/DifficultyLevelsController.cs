using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Api.Responses;
using Recipe.Application.Dtos.DifficultyLevels;
using Recipe.Application.Interfaces.Services;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DifficultyLevelsController : ControllerBase
    {
        string ItemName = "Difficulty Level";
        private readonly IDifficultyLevels _;

        public DifficultyLevelsController(IDifficultyLevels difficultyLevels)
        {
            _ = difficultyLevels;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllDifficultyLevels(string? search)
        {
            var results = await _.GetAllDifficultyLevels(search);
            return Ok(results);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDifficultyLevel(int id)
        {
            var result = await _.GetDifficultyLevelById(id);

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
        public async Task<IActionResult> AddDifficultyLevel([FromBody] CreateDifficultyLevelDto dto)
        {
            await _.AddDifficultyLevel(dto);
            return Accepted(ControllerResponses.Created(ItemName));
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDifficultyLevel(int id, [FromBody] UpdateDifficultyLevelDto dto)
        {
            if (id != dto.Id) return BadRequest("Id In route must match with id in the body");

            var result = await _.UpdateDifficultyLevel(id, dto);

            return result == 0 ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Accepted(ControllerResponses.Updated(ItemName, id));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDifficultyLevel(int id)
        {
           var result = await _.DeleteDifficultyLevel(id);
           return result == 0 ? NotFound(ControllerResponses.NotFound(ItemName, id)) : Ok(ControllerResponses.Deleted(ItemName, id));
        }
    }
}
