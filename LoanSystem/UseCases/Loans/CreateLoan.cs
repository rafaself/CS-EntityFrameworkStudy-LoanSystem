using LoanSystem.Models;
using LoanSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoanSystem.UseCases.Loans;

public class CreateLoan
{
    public static async Task Execute(DbContextOptions<CustomDbContext> options)
    {
        await using var context = new CustomDbContext(options);

        var repository = new LoanRepository(context);

        Console.WriteLine("Digite o ID do consumidor: ");
        string customerIdTemp = Console.ReadLine() ?? throw new InvalidOperationException("Can't be null!");
        int customerId = int.Parse(customerIdTemp);

        var loan = new Loan
        {
            Fee = .3m,
            StartDate = DateTime.UtcNow,
            ReturnDate = DateTime.UtcNow.AddDays(7)
        };

        int bookId;
        var booksIds = new List<int>();

        do
        {
            Console.Write("Digite o ID do livro ou 0 para sair: ");
            var bookIdTemp = Console.ReadLine() ?? throw new InvalidOperationException("Can't be null!");
            bookId = int.Parse(bookIdTemp);
            if (bookId > 0)
            {
                booksIds.Add(bookId);
            }

        } while (bookId > 0);

        await repository.Create(loan, customerId, booksIds);

    }
}
