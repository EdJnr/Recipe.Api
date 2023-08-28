using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Dtos.Ingredients
{
    public class GetIngredientDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Quantity { get; set; }

        public string? UnitOfMeasure { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
