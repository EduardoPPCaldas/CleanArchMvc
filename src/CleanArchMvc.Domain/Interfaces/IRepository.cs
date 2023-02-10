using System.Linq.Expressions;

namespace CleanArchMvc.Domain.Interfaces;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> Get();

    Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> pred);

    Task<TEntity> GetById(int id);

    Task<TEntity> Create(TEntity entity);

    Task<TEntity> Update(TEntity entity);

    Task Delete(int id);
}
