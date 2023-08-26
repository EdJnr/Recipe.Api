using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Dtos.DifficultyLevels
{
    public class UpdateDifficultyLevelDto
    {
        [Required]
        [Range(1, int.MaxValue)]    
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
