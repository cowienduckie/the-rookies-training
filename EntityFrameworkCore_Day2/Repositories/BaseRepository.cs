using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductStore.Data;
using ProductStore.Data.Entities;

namespace ProductStore.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<int>
{
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(ProductStoreContext context)
    {
        _dbSet = context.Set<T>();
    }

    public T Create(T entity)
    {
        return _dbSet.Add(entity).Entity;
    }

    public bool Delete(T entity)
    {
        _dbSet.Remove(entity);

        return true;
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.FirstOrDefault(predicate);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public T Update(T entity)
    {
        return _dbSet.Update(entity).Entity;
    }
}