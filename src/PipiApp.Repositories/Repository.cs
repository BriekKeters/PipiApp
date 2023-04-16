using PipiApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using PipiApp.Models;
using System;
using System.Linq.Expressions;
using PipiApp.Data;

namespace PipiApp.Repositories;
public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly PipiAppDbContext _dbContext;
    private readonly DbSet<T> _modelDbSet;

    public Repository(PipiAppDbContext ctx)
    {
        _dbContext = ctx ?? throw new ArgumentNullException();
        _modelDbSet = _dbContext.Set<T>();
    }
    public void Add(T entity)
    {
        _modelDbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        Update(entity);
    }

    public IQueryable<T> GetAll()
    {
        return _modelDbSet;
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await _modelDbSet.Where(predicate).ToListAsync();
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return _modelDbSet.Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<int> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _modelDbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }
}