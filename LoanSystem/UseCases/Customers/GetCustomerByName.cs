using LoanSystem.Models;
using LoanSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoanSystem.UseCases.Customers;

internal class GetCustomerByName
{
    public static async Task Execute(DbContextOptions<CustomDbContext> options)
    {
        Console.Write("Digite o primeiro nome do cliente: ");
        string firstName = Console.ReadLine() ?? throw new ArgumentNullException("Can't be null!");

        var dbContext = new CustomDbContext(options);

        var customerRepository = new CustomerRepository(dbContext);

        List<Customer> customers = await customerRepository.GetByNameAsync(firstName);

        foreach (var customer in customers)
        {
            Console.WriteLine(customer.FirstName + " " + customer.LastName);
        }

    }
}

