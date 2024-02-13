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

    public async void Create(Loan loan, int customerId, IEnumerable<int> booksIds)
    {
        loan.CustomerId = customerId;

        foreach(var bookId in booksIds)
        {
            var loanBook = new LoanBook
            {
                Loan = loan,
                BookId = bookId
            };

            _customDbContext.Add(loanBook);
        }

        await _customDbContext.SaveChangesAsync();

    }
}
