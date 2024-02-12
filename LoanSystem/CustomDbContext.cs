using LoanSystem.Configurations;
using LoanSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LoanSystem;

internal class CustomDbContext : DbContext
{

    // Vai criar a tabela Loans que vai se referenciada pela estrutura da classe Loan
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        string connectionString = "User ID=root;Password=rafa123;Host=localhost;Port=5432;Database=entitystudy;";

        optionsBuilder
            .UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.ApplyConfiguration(new AddressConfiguration());
        //modelBuilder.ApplyConfiguration(new CustomerConfiguration());

        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomDbContext).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

}
