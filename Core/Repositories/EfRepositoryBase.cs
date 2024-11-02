using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Repositories;

public class EfRepositoryBase<TContext, TEntity, TKey> : IAsyncRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, new()
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public IQueryable<TEntity> Query() => Context.Set<TEntity>().AsNoTracking();

    public async Task<TEntity?> AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        IQueryable<TEntity> queryable = Query();

        return await queryable.AnyAsync(predicate);
    }

    public async Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
    {
        IQueryable<TEntity> queryable = Query();

        return await queryable.Where(predicate).ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        IQueryable<TEntity> queryable = Query();
        return await queryable.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        IQueryable<TEntity> queryable = Query();
        return await queryable.ToListAsync();
    }

    public async Task<TEntity?> RemoveAsync(TEntity entity)
    {
        Context.Remove(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        Context.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }
}
