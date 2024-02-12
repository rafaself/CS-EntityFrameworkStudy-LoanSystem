using LoanSystem.Models;
using LoanSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoanSystem.UseCases.Books;

public static class CreateBook
{
    public static async Task Execute(DbContextOptions<CustomDbContext> options)
    {
        Console.Write("Digite o nome do livro: ");
        var bookTitle = Console.ReadLine() ?? throw new InvalidOperationException("Can't be null!");

        await using var context = new CustomDbContext(options);

        var bookRepository = new BookRepository(context);

        var bookToBeCreated = new Book
        {
            Title = bookTitle,
            IsAvailable = true
        };

        bookRepository.Add(bookToBeCreated);

        await context.SaveChangesAsync();
    }
}
