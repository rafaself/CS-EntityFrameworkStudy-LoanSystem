﻿using LoanSystem.Models;

namespace LoanSystem.Repositories.Interfaces;

public interface ILoanRepository
{
    void Create(Loan loan, int customerId, IEnumerable<int> booksId);
}
