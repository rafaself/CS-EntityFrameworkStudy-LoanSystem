namespace LoanSystem.Models;

public class Loan
{
    public int ID { get; set; }
    public decimal Fee { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime StartDate {  get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public ICollection<LoanBook>? LoansBooks { get; set; }

}
