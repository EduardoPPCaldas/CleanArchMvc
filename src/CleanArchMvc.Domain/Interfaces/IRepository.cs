namespace CleanArchMvc.Domain.Interfaces;

public interface IRepository<T>
{
    Task<List<T>> Get();

    Task<List<T>> Get(Func<T, bool> pred);

    Task<T> GetById(int id);

    Task<T> Create(T entity);

    Task<T> Update(T entity);

    bool Delete(int id);
}
