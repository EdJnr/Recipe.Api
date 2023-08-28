using Recipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Dtos.Recipes
{
    public class CreateRecipeDto
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Preparation time must be greater than 0")]
        public int PreparationTime { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Difficulty level Id must be greater than 0")]
        public int DifficultyLevelId { get; set; }

    }
}
