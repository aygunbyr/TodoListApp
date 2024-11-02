using Core.Models;
using System.Linq.Expressions;

namespace Core.Repositories;

public interface IAsyncRepository<TEntity, TKey> 
    where TEntity : class, IEntity<TKey>, new()
{
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> GetByIdAsync(TKey id);
    Task<TEntity?> UpdateAsync(TEntity entity);
    Task<TEntity?> AddAsync(TEntity entity);
    Task<TEntity?> RemoveAsync(TEntity entity);
}
