using OnlineWSModel.Dtos.CategoryDtos;

namespace OnlineWS.Business.Contracts
{
    public interface IUserCategoryManager
    {
        Task<List<CategoryGetDto>> GetAllCategories(params string[] includeList);
    }
}
