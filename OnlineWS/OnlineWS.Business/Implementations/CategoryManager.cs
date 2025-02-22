using AutoMapper;
using OnlineWS.Business.Contracts;
using OnlineWS.DateAccess.Contracts.Repositories;
using OnlineWSModel.Dtos.CategoryDtos;
using OnlineWSModel.Entities;

namespace OnlineWS.Business.Implementations
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddCategorry(CategoryPostDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            await _categoryRepository.InsertAsync(entity);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<List<CategoryGetDto>> GetAllCategories(params string[] includeList)
        {
            List<Category> categories = await _categoryRepository.GetAllAsycn(includeList);
            List<CategoryGetDto> list = _mapper.Map<List<CategoryGetDto>>(categories);
            return list;
        }

        public async Task<CategoryGetDto> GetById(int id, params string[] includeList)
        {
            Category category = await _categoryRepository.GetByIdAsync(id, includeList);
            CategoryGetDto dto = _mapper.Map<CategoryGetDto>(category);
            return dto;
        }

        public async Task UpdateCategory(CategoryPutDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            await _categoryRepository.UpdateAsync(entity);
        }
    }
}
