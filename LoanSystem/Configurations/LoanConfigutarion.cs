
using LoanSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanSystem.Configurations;

internal class LoanConfigutarion : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasOne<Customer>(loan => loan.Customer)
            .WithMany(customer => customer.Loans)
            .HasForeignKey(loan => loan.CustomerId);
    }
}
