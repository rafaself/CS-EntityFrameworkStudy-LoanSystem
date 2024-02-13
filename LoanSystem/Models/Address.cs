using LoanSystem.Models.Interfaces;

namespace LoanSystem.Models;

public class Address : IHaveId
{
    public int Id { get; set; }
    public string FullAddress { get; set; } = string.Empty;
    public AddressType Type { get; set; }
    public Customer? Customer { get; set; }
    public int CustomerID { get; set; }
}
