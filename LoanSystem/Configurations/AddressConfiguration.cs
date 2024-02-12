using LoanSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanSystem.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasOne<Customer>(address => address.Customer)
            .WithOne(customer => customer.Address)
            .HasForeignKey<Address>(address => address.CustomerID);
    }
}
