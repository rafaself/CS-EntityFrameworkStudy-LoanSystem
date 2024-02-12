using LoanSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanSystem.Configurations;

internal class LoanBookConfiguration : IEntityTypeConfiguration<LoanBook>
{
    public void Configure(EntityTypeBuilder<LoanBook> builder)
    {
        builder.HasKey(loanBook => new { loanBook.BookId, loanBook.LoanId});

        builder.HasOne<Book>(loanBook => loanBook.Book)
            .WithMany(book => book.LoansBooks)
            .HasForeignKey(loanBook => loanBook.BookId);

        builder.HasOne<Loan>(loanBook => loanBook.Loan)
            .WithMany(loan => loan.LoansBooks)
            .HasForeignKey(loanBook => loanBook.LoanId);
    }
}
