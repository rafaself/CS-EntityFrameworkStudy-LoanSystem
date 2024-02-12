using LoanSystem.Models;
using LoanSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace LoanSystem.UseCases;

public static class CreateCustomer
{
    public static async Task Execute(DbContextOptions<CustomDbContext> options)
    {
        Console.WriteLine("Digite o nome: ");
        var firstName = Console.ReadLine() ?? throw new InvalidOperationException("Can't be null");


        Console.WriteLine("Digite o sobrenome: ");
        var lastName = Console.ReadLine() ?? throw new InvalidOperationException("Can't be null");

        Console.WriteLine("Digite o nome da rua: ");
        var fullAddress = Console.ReadLine() ?? throw new InvalidOperationException("Can't be null");

        // Criando uma instância do contexto do banco de dados usando as opções de configuração especificadas
        await using var context = new CustomDbContext(options);

        // Instanciando o repositório para realizar operações relacionadas aos clientes
        var userRepository = new CustomerRepository(context);

        // Criando um objeto Customer que será inserido na tabela de clientes
        // Este objeto é mapeado pelo ORM do EF para ser traduzido em linha na tabela
        var customerToBeCreated = new Customer
        {
            FirstName = firstName,
            LastName = lastName
        };

        // Criando um objeto Address que será relacionado ao objeto Customer
        // criado anteriormente e inserido na tabela de Address
        var addressToBeCreated = new Address
        {
            Customer = customerToBeCreated,
            Type = AddressType.Street,
            FullAddress = fullAddress
        };

        // Criando uma consulta (query) para inserir os dados no banco de dados
        // por meio do repositório
        userRepository.Create(customerToBeCreated, addressToBeCreated);

        // Executando de fato as queries
        await context.SaveChangesAsync();

        // Fechando a conexão com o banco de dados
        // Nesse caso não é necessário por estar no contexto do using
        // await context.DisposeAsync();

    }
}
