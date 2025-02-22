using BaseLib.Model;
using System.Linq.Expressions;

namespace BaseLib.DataAccess.Contracts
{

    public interface IRepository<TEntity,TId>
        where TEntity:BaseEntity<TId>
    {
      
        Task<List<TEntity>> GetAllAsycn(params string[] includeList);

        Task<List<TEntity>> FilterAsycn(Expression<Func<TEntity,bool>> predicate,params string[] includeList);

        Task<TEntity> GetAsync(Expression<Func<TEntity,bool>>predicate,params string[] includeList);
        Task<TEntity> GetByIdAsync(TId id, params string[] includeList);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TId id);


    }
}
