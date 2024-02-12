using LoanSystem;
using LoanSystem.UseCases.Books;
using LoanSystem.UseCases.Customers;
using Microsoft.EntityFrameworkCore;


// Inicializando um conjunto de parâmetros que serão utilizados
// para realizar a criação do contexto com o banco dados
var contextOptions = new DbContextOptionsBuilder<CustomDbContext>()
    .UseNpgsql("User ID=root;Password=rafa123;Host=localhost;Port=5432;Database=entitystudy;")
    .Options;

int choice;

do
{
    Console.WriteLine("-- Gerenciamento da Biblioteca --");
    Console.WriteLine("1 - Adicionar cliente");
    Console.WriteLine("2 - Adicionar livro");
    Console.WriteLine("3 - Buscar cliente pelo ID");
    Console.WriteLine("4 - Buscar cliente pelo nome");
    Console.WriteLine("0 - Sair do menu");

    Console.Write("\nDigite uma opção: ");
    var tempChoice = Console.ReadLine() ?? throw new InvalidOperationException("Can't be null!");
    choice = int.Parse(tempChoice);

    switch (choice)
    {
        case 1:
            await CreateCustomer.Execute(contextOptions);
            break;
        case 2:
            await CreateBook.Execute(contextOptions);
            break;
        case 3:
            await GetCustomerById.Execute(contextOptions);
            break;     
        case 4:
            await GetCustomerByName.Execute(contextOptions);
            break;
    }

    Console.WriteLine("Operação executada!\n");

} while (choice != 0);