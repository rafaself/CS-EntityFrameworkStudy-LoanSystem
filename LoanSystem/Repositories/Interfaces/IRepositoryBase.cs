namespace LoanSystem.Repositories.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    void Add(TEntity entity);
}
