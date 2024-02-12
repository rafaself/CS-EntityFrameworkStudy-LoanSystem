using LoanSystem;
using LoanSystem.Models;
using LoanSystem.Repositories;
using Microsoft.EntityFrameworkCore;


// Inicializando um conjunto de parâmetros que serão utilizados
// para realizar a criação do contexto com o banco dados
var contextOptions = new DbContextOptionsBuilder<CustomDbContext>()
    .UseNpgsql("User ID=root;Password=rafa123;Host=localhost;Port=5432;Database=entitystudy;")
    .Options;

// Criando uma instância do contexto do banco de dados usando as opções de configuração especificadas
await using var context = new CustomDbContext(contextOptions);

// Instanciando o repositório para realizar operações relacionadas aos clientes
var repository = new CustomerRepository(context);

// Criando um objeto Customer que será inserido na tabela de clientes
// Este objeto é mapeado pelo ORM do EF para ser traduzido em linha na tabela
var customerToBeCreated = new Customer
{
    FirstName = "Rafael",
    LastName = "Fontenele"
};

// Criando um objeto Address que será relacionado ao objeto Customer
// criado anteriormente e inserido na tabela de Address
var addressToBeCreated = new Address
{
    Customer = customerToBeCreated,
    Type = AddressType.Street,
    FullAddress = "Rua 3232"
};

// Criando uma consulta (query) para inserir os dados no banco de dados
// por meio do repositório
repository.Create(customerToBeCreated, addressToBeCreated);

// Executando de fato as queries
await context.SaveChangesAsync();

// Fechando a conexão com o banco de dados
await context.DisposeAsync();