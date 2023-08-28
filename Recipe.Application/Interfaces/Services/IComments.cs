using Recipe.Application.Dtos.Comments;
using Recipe.Application.Dtos.DifficultyLevels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Interfaces.Services
{
    public interface IComments
    {
        Task<IReadOnlyList<GetCommentDto>> GetAllComments(string? search);

        Task<GetCommentDto> GetCommentById(int id);

        Task<int> AddComment(CreateCommentDto dto);

        Task<int> UpdateComment(int id, UpdateCommentDto dto);

        Task<int> DeleteComment(int id);
    }
}
