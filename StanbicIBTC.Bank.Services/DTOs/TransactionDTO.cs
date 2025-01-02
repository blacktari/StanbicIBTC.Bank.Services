using System;

public class TransactionDTO
{
    public string TransactionId { get; set; }
    public string AccountNumber { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Channel { get; set; }
}
