using AutoMapper;
using Recipe.Application.Dtos.Recipes;
using Recipe.Domain.Entities;

namespace Recipe.Api.Mappings
{
    public class RecipeMappings : Profile
    {
        public RecipeMappings()
        {
            CreateMap<GetRecipeDto, RecipesEntity>().ReverseMap();

            CreateMap<CreateRecipeDto, RecipesEntity>().ReverseMap();

            CreateMap<UpdateRecipeDto, RecipesEntity>().ReverseMap();
        }
    }
}
