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
            .Where(customer => customer.Id == id)
            .Include(customer => customer.Address)
            //.ThenInclude(...) para caso tenha outra propriedade dentro de Address
            .FirstAsync();
    }

    public Task<List<Customer>> GetByNameAsync(string name)
    {
        return _dbContext.Set<Customer>()
            .AsNoTracking()
            .Where(customer => customer.FirstName.Contains(name) || customer.LastName.Contains(name))
            .Where(customer => customer.Id >= 0) // Ao invés de usar AND
            .ToListAsync();
    }

    public async Task<List<Customer>> ListAllCustomersAsync(int page = 0, int pageSize = 100)
    {

        var customersSet = _dbContext.Set<Customer>()
            .AsNoTracking()
            .OrderBy(customer => customer.Id);

        var customersCount = await customersSet
            .CountAsync();

        if (customersCount == 0) throw new InvalidOperationException("No customers founded.");

        return await customersSet
            .Skip(pageSize * (page - 1))
            .Take(pageSize)
            .ToListAsync();
    }
}
