using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Dtos.Comments
{
    public class CreateCommentDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Recipe Id must be greater than 0")]
        public int RecipeId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? AddedBy { get; set; }
    }
}
