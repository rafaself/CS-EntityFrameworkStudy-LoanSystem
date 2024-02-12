﻿namespace LoanSystem.Models;

internal class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
}
