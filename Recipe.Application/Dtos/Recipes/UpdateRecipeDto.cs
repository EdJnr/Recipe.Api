using System.ComponentModel.DataAnnotations;

namespace Recipe.Application.Dtos.Recipes
{
    public class UpdateRecipeDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
        public int PreparationTime { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
        public int DifficultyLevelId { get; set; }

    }
}
