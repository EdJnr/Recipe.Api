using Recipe.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Domain.Entities
{
    public class RecipesEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int PreparationTime { get; set; }

        [ForeignKey("DifficultyLevelsEntity")]
        public int DifficultyLevelId { get; set; }

        public DifficultyLevelsEntity? DifficultyLevel { get; set; }

        public IReadOnlyCollection<CommentsEntity>? Comments { get; set; }

        public IReadOnlyCollection<IngredientsEntity>? Ingredients { get; set; }

    }
}
