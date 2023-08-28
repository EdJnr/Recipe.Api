using AutoMapper;
using Recipe.Application.Dtos.Comments;
using Recipe.Domain.Entities;

namespace Recipe.Api.Mappings
{
    public class CommentMappings : Profile
    {
        public CommentMappings()
        {
            CreateMap<GetCommentDto, CommentsEntity>().ReverseMap();

            CreateMap<CreateCommentDto, CommentsEntity>().ReverseMap();

            CreateMap<UpdateCommentDto, CommentsEntity>().ReverseMap();
        }
    }
}
