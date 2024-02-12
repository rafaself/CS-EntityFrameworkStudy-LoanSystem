namespace LoanSystem.Models;

public class Address
{
    public int ID { get; set; }
    public string FullAddress { get; set; } = string.Empty;
    public AddressType Type { get; set; }
    public Customer? Customer { get; set; }
    public int CustomerID { get; set; }
}
