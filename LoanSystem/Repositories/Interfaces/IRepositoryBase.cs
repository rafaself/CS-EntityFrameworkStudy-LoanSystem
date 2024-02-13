using LoanSystem.Models.Interfaces;

namespace LoanSystem.Repositories.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : class, IHaveId
{
    void Add(TEntity entity);
}
