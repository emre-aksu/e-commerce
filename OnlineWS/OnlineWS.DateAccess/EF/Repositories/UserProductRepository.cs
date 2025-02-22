using BaseLib.DataAccess.Implementations.EF;
using OnlineWS.DateAccess.Contracts.Repositories;
using OnlineWS.DateAccess.EF.Contexts;
using OnlineWSModel.Entities;

namespace OnlineWS.DateAccess.EF.Repositories
{
    public class UserProductRepository:BaseRepository<Product,int,ECommerceContext>,IUserProductRepository
    {
    }
}
