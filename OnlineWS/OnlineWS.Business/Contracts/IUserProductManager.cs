using OnlineWSModel.Dtos.ProductDtos;

namespace OnlineWS.Business.Contracts
{
    public interface IUserProductManager
    {
        Task<List<ProductGetDto>> GetAllProducts(params string[] includeList);
    }
}
