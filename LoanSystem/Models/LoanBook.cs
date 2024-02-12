namespace LoanSystem.Models;

public class LoanBook
{
    public Book? Book { get; set; }
    public int BookId { get; set; }
    public Loan? Loan { get; set; }
    public int LoanId { get; set; }
}
