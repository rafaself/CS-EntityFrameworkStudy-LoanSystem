using LoanSystem.Models;

namespace LoanSystem.Repositories.Interfaces;

public interface ILoanRepository
{
    Task Create(Loan loan, int customerId, IEnumerable<int> booksId);
}
