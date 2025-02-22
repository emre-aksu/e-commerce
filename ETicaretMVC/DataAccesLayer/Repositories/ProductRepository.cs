using DataAccesLayer.Context;
using DataAccesLayer.Interface;
using Infrastructure.DataAccess;
using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class ProductRepository : BaseRepository<Product, int, ECommerceDbContext>, IProductRepository
    {
        public async Task<List<Product>> GetByCategory(int categoryId)
        {
            return await GetAllAsync(x => x.CategoryId == categoryId);
        }

        public async Task<List<Product>> GetByPrice(decimal min, decimal max, bool inclusive = false)
        {

            if (inclusive)

                return await GetAllAsync(x => x.Price >= min && x.Price <= max);

            return await GetAllAsync(x => x.Price > min && x.Price < max);
        }
    }
}
