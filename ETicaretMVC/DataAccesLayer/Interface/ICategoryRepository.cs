using Infrastructure.DataAccess.Interface;
using ModelLayer.Entities;

namespace DataAccesLayer.Interface
{
    public interface ICategoryRepository:IRepository<Category, int>
    {
        Task<Category> GetByNameAsync(string categoryName);
    }
}
