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
    public class CommentsEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string AddedBy { get; set; } = string.Empty;

        [ForeignKey(nameof(RecipesEntity))]
        public int RecipeId { get; set; }

        [JsonIgnore]
        public RecipesEntity? Recipe { get; set; }
    }
}
