using Recipe.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Entities
{
    public class RecipesEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int PreparationTime { get; set; }

        public int DifficultyLevelId { get; set; }

        public DifficultyLevelsEntity? DifficultyLevel { get; set; }

        public int AverageRating { get; set; }

        public int NumberOfRatings { get; set; }

    }
}
