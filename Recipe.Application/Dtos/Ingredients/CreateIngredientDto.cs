using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Dtos.Ingredients
{
    public class CreateIngredientDto
    {
        public string Name { get; set; } = string.Empty;

        public decimal Quantity { get; set; }

        public string UnitOfMeasure { get; set; } = string.Empty;
    }
}
