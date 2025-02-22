using AutoMapper;
using OnlineWS.Business.Contracts;
using OnlineWS.DateAccess.Contracts.Repositories;
using OnlineWSModel.Dtos.CategoryDtos;
using OnlineWSModel.Entities;

namespace OnlineWS.Business.Implementations
{
    public class UserCategoryManager : IUserCategoryManager
    {
        private readonly  IUserCategoryRepository _usrCatRepo;
        private readonly IMapper _mapper;
        public UserCategoryManager(IUserCategoryRepository usrCatRepo,IMapper mappler)
        {
            _usrCatRepo = usrCatRepo;
            _mapper = mappler;  
        }
        public async Task<List<CategoryGetDto>> GetAllCategories(params string[] includeList)
        {
            List<Category> categories= await _usrCatRepo.GetAllAsycn(includeList);
            List<CategoryGetDto> list = _mapper.Map<List<CategoryGetDto>>(categories);
            return list;
        }
    }
}
