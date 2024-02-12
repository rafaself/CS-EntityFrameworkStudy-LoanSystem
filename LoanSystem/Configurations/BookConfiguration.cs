using LoanSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanSystem.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    void IEntityTypeConfiguration<Book>.Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasMany<LoanBook>(book => book.LoansBooks)
            .WithOne(loanBook => loanBook.Book);
    }
}
