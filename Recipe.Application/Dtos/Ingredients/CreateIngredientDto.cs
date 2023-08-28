using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Dtos.Ingredients
{
    public class CreateIngredientDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Recipe Id must be greater than 0")]
        public int RecipeId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public decimal Quantity { get; set; }

        [Required]
        public string UnitOfMeasure { get; set; } = string.Empty;
    }
}
