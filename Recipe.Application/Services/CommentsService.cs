using AutoMapper;
using Recipe.Application.Dtos.Comments;
using Recipe.Application.Interfaces;
using Recipe.Application.Interfaces.Services;
using Recipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Services
{
    public class CommentsService : IComments
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddComment(CreateCommentDto dto)
        {
            var model = _mapper.Map<CommentsEntity>(dto);

            _unitOfWork.Comments.Create(model);
            var result = await _unitOfWork.SaveAsync();

            return result;
        }

        public async Task<int> DeleteComment(int id)
        {
            _unitOfWork.Comments.Delete(id);

            var result = await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<IReadOnlyList<GetCommentDto>> GetAllComments(string? search)
        {
            var fromDb = search == null ?
            await _unitOfWork.Comments.GetAll()
            :
            await _unitOfWork.Comments.Query
            (
                filter : e=> e.Name.Trim().ToLower().Contains(search.Trim().ToLower())
            );

            var result = _mapper.Map<IReadOnlyList<GetCommentDto>>(fromDb);
            return result;
        }

        public async Task<GetCommentDto> GetCommentById(int id)
        {
            var fromDb = await _unitOfWork.Comments.Get(id);

            var result = _mapper.Map<GetCommentDto>(fromDb);
            return result;
        }

        public async Task<int> UpdateComment(int id, UpdateCommentDto dto)
        {
            var model = _mapper.Map<CommentsEntity>(dto);

            await _unitOfWork.Comments.Update(id, model);
            var result = await _unitOfWork.SaveAsync();

            return result;
        }
    }
}
