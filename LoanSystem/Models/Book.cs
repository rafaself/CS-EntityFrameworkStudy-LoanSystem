using LoanSystem.Models.Interfaces;

namespace LoanSystem.Models;

public class Book : IHaveId
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public ICollection<LoanBook>? LoansBooks { get; set; }
}
