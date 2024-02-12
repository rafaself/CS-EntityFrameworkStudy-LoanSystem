using LoanSystem.Models;
using LoanSystem.Repositories.Interfaces;

namespace LoanSystem.Repositories;

internal class BookRepository : RepositoryBase<Book>, IBookRepository
{
    protected BookRepository(CustomDbContext context) : base(context)
    {
    }
}
