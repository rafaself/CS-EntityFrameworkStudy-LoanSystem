
using LoanSystem.Repositories.Interfaces;

namespace LoanSystem.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
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

}
