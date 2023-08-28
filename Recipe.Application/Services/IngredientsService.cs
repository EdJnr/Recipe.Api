using AutoMapper;
using Recipe.Application.Dtos.Ingredients;
using Recipe.Application.Interfaces;
using Recipe.Application.Interfaces.Services;
using Recipe.Domain.Entities;

namespace Recipe.Application.Services
{
    public class IngredientsService : IIngredients
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IngredientsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddIngredient(CreateIngredientDto dto)
        {
            var model = _mapper.Map<IngredientsEntity>(dto);

            _unitOfWork.Ingredients.Create(model);

            var result = await _unitOfWork.SaveAsync();

            return result;
        }

        public async Task<int> DeleteIngredient(int id)
        {
            _unitOfWork.Ingredients.Delete(id);

            var result = await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<IReadOnlyList<GetIngredientDto>> GetAllIngredients(string? search)
        {
            var fromDb = (search == null) ?
            await _unitOfWork.Ingredients.GetAll()
            :
            await _unitOfWork.Ingredients.Query
            (
                filter: e => e.Name.Trim().ToLower().Contains(search.Trim().ToLower())
            );

            var result = _mapper.Map<IReadOnlyList<GetIngredientDto>>(fromDb);
            return result;
        }

        public async Task<GetIngredientDto> GetIngredientById(int id)
        {
            var fromDb = await _unitOfWork.Ingredients.Get(id);

            var result = _mapper.Map<GetIngredientDto>(fromDb);
            return result;
        }

        public async Task<int> UpdateIngredient(int id, UpdateIngredientDto dto)
        {
            var model = _mapper.Map<IngredientsEntity>(dto);

            await _unitOfWork.Ingredients.Update(id, model);
            var result = await _unitOfWork.SaveAsync();

            return result;
        }
    }
}
