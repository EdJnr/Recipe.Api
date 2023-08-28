using Recipe.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recipe.Domain.Entities
{
    public class IngredientsEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Quantity { get; set; }

        public string UnitOfMeasure { get; set; } = string.Empty;

        [ForeignKey(nameof(RecipesEntity))]
        public int RecipeId { get; set; }

        [JsonIgnore]
        public RecipesEntity? Recipe { get; set; }

    }
}
