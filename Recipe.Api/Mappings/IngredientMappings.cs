using AutoMapper;
using Recipe.Application.Dtos.Ingredients;
using Recipe.Domain.Entities;

namespace Recipe.Api.Mappings
{
    public class IngredientMappings : Profile
    {
         public IngredientMappings()
         {
            CreateMap<CreateIngredientDto, IngredientsEntity>().ReverseMap();  

            CreateMap<GetIngredientDto, IngredientsEntity>().ReverseMap();  

            CreateMap<UpdateIngredientDto, IngredientsEntity>().ReverseMap();  
         }
    }
}
