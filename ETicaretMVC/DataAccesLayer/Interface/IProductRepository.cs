using Infrastructure.DataAccess.Interface;
using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interface
{
    public interface IProductRepository : IRepository<Product, int>
    {
        Task<List<Product>> GetByCategory(int categoryId);
        Task<List<Product>> GetByPrice(decimal min, decimal max, bool inclusive = false);
    }
}
