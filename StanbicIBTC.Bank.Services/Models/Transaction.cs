using System;

public class Transaction
{
    public Guid Id { get; set; } // Unique identifier for the transaction
    public string AccountNumber { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string Type { get; set; } // Debit or Credit
    public string Description { get; set; }
    public string Status { get; set; } // Pending, Successful, Failed
    public string Reference { get; set; } // External reference for reconciliation
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public string Channel { get; set; } // ATM, Mobile App, etc.
}
