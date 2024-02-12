using LoanSystem.Models;

namespace LoanSystem.Repositories.Interfaces;

public interface ICostumerRepository  
{
    void Create(Customer customer, Address address);
    Task<Customer> GetByIdAsync(int id);
    Task<List<Customer>> GetByNameAsync(string firstName);
    Task<IEnumerable<Customer>> ListAsync(int page, int pageSize);
}
