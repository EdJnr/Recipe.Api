using Recipe.Domain.Entities;

namespace Recipe.Application.Dtos.Recipes
{
    public class GetRecipeDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public int PreparationTime { get; set; }

        public DifficultyLevelsEntity? DifficultyLevel { get; set; }

        public IReadOnlyCollection<CommentsEntity>? Comments { get; set; }

        public IReadOnlyCollection<IngredientsEntity>? Ingredients { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
