using System.Linq.Expressions;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Errors;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id)
            ?? throw new EntityNotFoundException(id);

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> Get()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> pred)
    {
        return await _context.Set<TEntity>().Where(pred).ToListAsync();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id) ?? throw new EntityNotFoundException(id);
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
