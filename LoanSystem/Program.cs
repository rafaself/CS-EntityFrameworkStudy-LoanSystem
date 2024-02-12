using LoanSystem;
using LoanSystem.Models;
using LoanSystem.Repositories;
using Microsoft.EntityFrameworkCore;

var contextOptions = new DbContextOptionsBuilder<CustomDbContext>()
    .UseNpgsql("User ID=root;Password=rafa123;Host=localhost;Port=5432;Database=entitystudy;")
    .Options;

await using var context = new CustomDbContext(contextOptions);

var repository = new CustomerRepository(context);

var customerToBeCreated = new Customer
{
    FirstName = "Rafael",
    LastName = "Fontenele"
};

var addressToBeCreated = new Address
{
    Customer = customerToBeCreated,
    Type = AddressType.Street,
    FullAddress = "Rua 3232"
};

repository.Create(customerToBeCreated, addressToBeCreated);
await context.SaveChangesAsync();

//Pode ser substituido pelo using
await context.DisposeAsync();