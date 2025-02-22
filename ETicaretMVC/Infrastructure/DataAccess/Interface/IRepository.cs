using Infrastructure.Model;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Interface
{
    public interface IRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] navProp);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] navProp);

        Task<TEntity> GetByIdAsync(TId id, params string[] navProp);

        Task<TEntity> InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TId id);
    }
}
