using LoanSystem.Models;
using LoanSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        return _dbContext.Set<Customer>()
            .AsNoTracking()
            .Where(customer => customer.ID == id)
            .Include(customer => customer.Address)
            //.ThenInclude(...) para caso tenha outra propriedade dentro de Address
            .FirstAsync();
    }

    public Task<List<Customer>> GetByNameAsync(string firstName)
    {
        return _dbContext.Set<Customer>()
            .AsNoTracking()
            .Where(customer => customer.FirstName.Contains(firstName))
            .ToListAsync();
    }

    public Task<IEnumerable<Customer>> ListAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }
}
