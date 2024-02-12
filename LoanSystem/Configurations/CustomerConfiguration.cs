using LoanSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanSystem.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasOne<Address>(customer => customer.Address)
            .WithOne(address => address.Customer);

        builder.HasMany<Loan>(customer => customer.Loans)
            .WithOne(loans => loans.Customer);
    }
}
