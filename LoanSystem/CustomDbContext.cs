using LoanSystem.Configurations;
using LoanSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LoanSystem;

public class CustomDbContext : DbContext
{

    // O DbSet é usado para realizar consultas nas tabelas e salvar entidades no banco de dados.
    // É necessário configurar um DbSet para cada modelo para que o Entity Framework mapeie
    // esses modelos para tabelas no banco de dados durante as migrações e operações de banco de dados.
    private DbSet<Loan>? Loans { get; set; }
    private DbSet<Book>? Books { get; set; }
    private DbSet<Customer>? Customers { get; set; }
    private DbSet<Address>? Addresses { get; set; }
    private DbSet<LoanBook>? LoansBooks { get; set; }

    public CustomDbContext()
    {

    }   
    
    public CustomDbContext(DbContextOptions<CustomDbContext> options):base(options)
    {

    }

    // O método OnConfiguring é chamado automaticamente pelo Entity Framework Core
    // durante a configuração do contexto do banco de dados.
    // Ele é usado para configurar as opções de conexão com o banco de dados,
    // como a string de conexão.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        // Cada banco de dados possui um tipo de connection string diferente
        // Utilizando Postgres
        string connectionString = "User ID=root;Password=rafa123;Host=localhost;Port=5432;Database=entitystudy;";

        // Configurando a conexão com um banco de dados Postgres
        optionsBuilder
            .UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // O método OnModelCreating é chamado automaticamente pelo Entity Framework Core
        // durante a criação do modelo de banco de dados.
        // Ele é usado para configurar o modelo de banco de dados, incluindo a
        // aplicação de configurações de entidades.
        base.OnModelCreating(modelBuilder);

        // Como implementar manualmente cada configuração separadamente
        // modelBuilder.ApplyConfiguration(new AddressConfiguration());
        // modelBuilder.ApplyConfiguration(new CustomerConfiguration());

        // Uma maneira otimizada de aplicar todas as configurações
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomDbContext).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

}
