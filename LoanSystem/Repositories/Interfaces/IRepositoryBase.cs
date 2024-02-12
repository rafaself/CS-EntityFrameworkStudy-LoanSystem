namespace LoanSystem.Repositories.Interfaces;

public interface IRepositoryBase<TEntity>
{
    void Add(TEntity entity);
}
