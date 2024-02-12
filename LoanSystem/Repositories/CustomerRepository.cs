using LoanSystem.Models;
using LoanSystem.Repositories.Interfaces;

namespace LoanSystem.Repositories;

public class CustomerRepository : ICostumerRepository
{

    private CustomDbContext _dbContext;

    public CustomerRepository(CustomDbContext context)
    {
        _dbContext = context;
    }

    public void Create(Customer customer, Address address)
    {
        _dbContext.Add(customer);
        _dbContext.Add(address);
    }

    public Task<Customer> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> GetByNameAsync(string firstName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> ListAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }
}
