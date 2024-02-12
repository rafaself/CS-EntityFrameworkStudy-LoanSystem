using LoanSystem.Models;
using LoanSystem.Repositories.Interfaces;

namespace LoanSystem.Repositories;

internal class CustomerRepository : ICostumerRepository
{

    private CustomDbContext _dbContext;

    public CustomerRepository(CustomDbContext context)
    {
        _dbContext = context;
    }

    public void Create(Customer customer)
    {
        _dbContext.Add(customer);   
    }
}
