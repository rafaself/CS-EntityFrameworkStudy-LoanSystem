using LoanSystem.Models;
using LoanSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoanSystem.UseCases.Books;

public class GetBookById
{
    public static async Task Execute(DbContextOptions<CustomDbContext> options)
    {

        Console.Write("Digite o Id do livro: ");
        string bookIdTemp = Console.ReadLine() ?? throw new InvalidOperationException("Can't be null!");
        int bookId = int.Parse(bookIdTemp);

        await using var context = new CustomDbContext(options);

        var repository = new BookRepository(context);

        Book book = await repository.GetByIdAsync(bookId);

        Console.WriteLine(book.Id);
        Console.WriteLine(book.Title);

    }
}
