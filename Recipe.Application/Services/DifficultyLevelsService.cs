using AutoMapper;
using Recipe.Application.Dtos.DifficultyLevels;
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
    public class DifficultyLevelsService : IDifficultyLevels
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DifficultyLevelsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddDifficultyLevel(CreateDifficultyLevelDto dto)
        {
            var model = _mapper.Map<DifficultyLevelsEntity>(dto);

            _unitOfWork.DifficultyLevels.Create(model);
            var result = await _unitOfWork.SaveAsync();

            return result;
        }

        public async Task<int> DeleteDifficultyLevel(int id)
        {
            _unitOfWork.DifficultyLevels.Delete(id);

            var result = await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<IReadOnlyList<GetDifficultyLevelDto>> GetAllDifficultyLevels(string? search)
        {
            var fromDb = search == null ?
            await _unitOfWork.DifficultyLevels.GetAll()
            :
            await _unitOfWork.DifficultyLevels.Query
            (
                filter:(e)=> e.Name.ToLower().Trim().Contains(search.ToLower().Trim())
            );;

            var results = _mapper.Map<IReadOnlyList<GetDifficultyLevelDto>>(fromDb);
            return results;
        }

        public async Task<GetDifficultyLevelDto> GetDifficultyLevelById(int id)
        {
            var fromDb = await _unitOfWork.DifficultyLevels.Get(id);

            var result = _mapper.Map<GetDifficultyLevelDto>(fromDb);
            return result;
        }

        public async Task<int> UpdateDifficultyLevel(int id, UpdateDifficultyLevelDto dto)
        {
            var model = _mapper.Map<DifficultyLevelsEntity>(dto);
            await _unitOfWork.DifficultyLevels.Update(id, model);

            var result = await _unitOfWork.SaveAsync();
            return result;
        }

    }
}
