using LoanSystem.Models;
using LoanSystem.Repositories.Interfaces;

namespace LoanSystem.Repositories;

public class LoanRepository : ILoanRepository
{

    CustomDbContext _customDbContext;

    public LoanRepository(CustomDbContext customDbContext)
    {
        _customDbContext = customDbContext;
    }

    public void Create(Loan loan, IEnumerable<int> booksId)
    {
        throw new NotImplementedException();
    }
}
