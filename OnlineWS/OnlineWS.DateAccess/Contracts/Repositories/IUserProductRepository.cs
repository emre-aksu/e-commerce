using BaseLib.DataAccess.Contracts;
using OnlineWSModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineWS.DateAccess.Contracts.Repositories
{
    public interface IUserProductRepository:IRepository<Product,int>
    {
    }
}
