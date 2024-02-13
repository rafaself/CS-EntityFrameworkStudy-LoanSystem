using LoanSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Models;

public class Customer : IHaveId
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Address? Address { get; set; }
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
