using AutoMapper;
using Recipe.Application.Dtos.DifficultyLevels;
using Recipe.Domain.Entities;

namespace Recipe.Api.Mappings
{
    public class DifficultyLevelsMappings : Profile
    {
        public DifficultyLevelsMappings()
        {
            CreateMap<GetDifficultyLevelDto, DifficultyLevelsEntity>().ReverseMap();

            CreateMap<CreateDifficultyLevelDto, DifficultyLevelsEntity>().ReverseMap();

            CreateMap<UpdateDifficultyLevelDto, DifficultyLevelsEntity>().ReverseMap();
        }
    }
}
