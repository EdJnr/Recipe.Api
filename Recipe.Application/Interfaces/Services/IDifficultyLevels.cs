using Recipe.Application.Dtos.DifficultyLevels;

namespace Recipe.Application.Interfaces.Services
{
    public interface IDifficultyLevels
    {
        Task<IReadOnlyList<GetDifficultyLevelDto>> GetAllDifficultyLevels(string? search);

        Task<GetDifficultyLevelDto> GetDifficultyLevelById(int id);

        Task<int> AddDifficultyLevel(CreateDifficultyLevelDto dto);

        Task<int> UpdateDifficultyLevel(int id, UpdateDifficultyLevelDto dto);

        Task<int> DeleteDifficultyLevel(int id);
    }
}
