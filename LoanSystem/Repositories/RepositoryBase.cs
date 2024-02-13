
using LoanSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoanSystem.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{

    protected CustomDbContext Context;

    protected RepositoryBase(CustomDbContext context)
    {
        Context = context;
    }

    public virtual void Add(TEntity entity)
    {
        if(entity is null) throw new ArgumentNullException(nameof(entity));
        Context.Add(entity);
    }

    public Task<TEntity> GetByIdAsync (int id)
    {
        return Context.Set<TEntity>()
            .AsNoTracking()
            .Where(content => content.Id)
    }

}
