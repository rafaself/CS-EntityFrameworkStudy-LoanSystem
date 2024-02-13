using LoanSystem;
using LoanSystem.UseCases.Books;
using LoanSystem.UseCases.Customers;
using LoanSystem.UseCases.Loans;
using Microsoft.EntityFrameworkCore;


// Inicializando um conjunto de parâmetros que serão utilizados
// para realizar a criação do contexto com o banco dados
var contextOptions = new DbContextOptionsBuilder<CustomDbContext>()
    .UseNpgsql("User ID=root;Password=rafa123;Host=localhost;Port=5432;Database=entitystudy;")
    .Options;

int choice;

// #TODO
// Validar paginação, não pode ser negativo ou 0
// Organizar melhor o que der no código
// Implementar testes

do
{
    Console.WriteLine("-- Gerenciamento da Biblioteca --");
    Console.WriteLine("1 - Adicionar cliente");
    Console.WriteLine("2 - Adicionar livro");
    Console.WriteLine("3 - Buscar cliente pelo ID");
    Console.WriteLine("4 - Buscar cliente pelo nome");
    Console.WriteLine("5 - Listar todos os clientes");
    Console.WriteLine("6 - Buscar livro pelo ID");
    Console.WriteLine("7 - Adicionar Empréstimo");
    Console.WriteLine("0 - Sair do menu");

    Console.Write("\nDigite uma opção: ");
    var tempChoice = Console.ReadLine() ?? throw new InvalidOperationException("Can't be null!");
    choice = int.Parse(tempChoice);
    Console.WriteLine();

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
        case 5:
            await ListAllCustomers.Execute(contextOptions);
            break; 
        case 6:
            await GetBookById.Execute(contextOptions);
            break;        
        case 7:
            await CreateLoan.Execute(contextOptions);
            break;
    }

    Console.WriteLine("Operação executada!\n");

} while (choice != 0);