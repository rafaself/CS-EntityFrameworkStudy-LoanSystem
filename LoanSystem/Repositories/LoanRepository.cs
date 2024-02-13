using LoanSystem.Models;
using LoanSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoanSystem.Repositories;

public class LoanRepository : ILoanRepository
{

    CustomDbContext _dbContext;

    public LoanRepository(CustomDbContext customDbContext)
    {
        _dbContext = customDbContext;
    }

    public async Task Create(Loan loan, int customerId, IEnumerable<int> booksIds)
    {
        loan.CustomerId = customerId;

        foreach(var bookId in booksIds)
        {
            var loanBook = new LoanBook
            {
                Loan = loan,
                BookId = bookId
            };

            _dbContext.Add(loanBook);
        }

        await _dbContext.SaveChangesAsync();

    }
}
