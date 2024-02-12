using LoanSystem.Models;
using LoanSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoanSystem.UseCases.Customers;

internal class ListAllCustomers
{
    public static async Task Execute(DbContextOptions<CustomDbContext> options)
    {
        var dbContext = new CustomDbContext(options);

        var customerRepository = new CustomerRepository(dbContext);

        List<Customer> allCustomers = await customerRepository.ListAllCustomersAsync(); 

        foreach(var customer in allCustomers)
        {
            Console.WriteLine(customer.FirstName + " " + customer.LastName);
        }

    }
}
