using DataAccesLayer.Context;
using DataAccesLayer.Interface;
using Infrastructure.DataAccess;
using ModelLayer.Entities;

namespace DataAccesLayer.Repositories
{
    public class CategoryRepository : BaseRepository<Category, int, ECommerceDbContext>, ICategoryRepository
    {
        public async Task<Category> GetByNameAsync(string categoryName)
        {
            return await GetAsync(x => x.Name == categoryName);
        }
    }
}
