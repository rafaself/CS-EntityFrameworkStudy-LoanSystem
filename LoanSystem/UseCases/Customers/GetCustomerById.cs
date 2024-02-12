using LoanSystem.Models;
using LoanSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoanSystem.UseCases.Customers;

public static class GetCustomerById
{
    public static async Task Execute(DbContextOptions<CustomDbContext> options)
    {
        Console.Write("Digite o ID do cliente: ");
        var customerIdTemp = Console.ReadLine() ?? throw new InvalidOperationException("Can't be null!");
        int customerId = int.Parse(customerIdTemp);

        await using var context = new CustomDbContext(options);

        var customerRepository = new CustomerRepository(context);

        Customer customer = await customerRepository.GetByIdAsync(customerId);

        Console.WriteLine(customer.FirstName);
        Console.WriteLine(customer.LastName);
        Console.WriteLine(customer.Address!.FullAddress);

    }
}
