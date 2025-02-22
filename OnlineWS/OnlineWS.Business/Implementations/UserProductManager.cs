using AutoMapper;
using OnlineWS.Business.Contracts;
using OnlineWS.DateAccess.Contracts.Repositories;
using OnlineWSModel.Dtos.ProductDtos;
using OnlineWSModel.Entities;

namespace OnlineWS.Business.Implementations
{
    public class UserProductManager : IUserProductManager
    {
        private readonly IUserProductRepository _usrprdrepo;
        private readonly IMapper _mapper;
        public UserProductManager(IUserProductRepository usrprdrepo,IMapper mapper)
        {
            _mapper = mapper;
            _usrprdrepo = usrprdrepo;
        }
        public async Task<List<ProductGetDto>> GetAllProducts(params string[] includeList)
        {
           List<Product> products=await _usrprdrepo.GetAllAsycn(includeList);
            List<ProductGetDto> list = _mapper.Map<List<ProductGetDto>>(products);  
            return list;
        }
    }
}
